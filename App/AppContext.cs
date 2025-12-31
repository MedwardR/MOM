using DataCommon.Models;
using DataCommon.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using MOM.Helpers;
using Npgsql;
using System.Security.Authentication;

namespace MOM
{
	public class AppContext(UserSettings settings) : DbContext
	{
		public User? AuthenticatedUser { get; private set; }
		public UserSettings UserSettings { get; } = settings;

		public DbSet<Household> Households { get; set; }
		public DbSet<Individual> Individuals { get; set; }
		public DbSet<User> Users { get; set; }

		public void AssignAuthenticatedUser(User user)
		{
			if (AuthenticatedUser is null)
			{
				AuthenticatedUser = user;
			}
			else throw new InvalidOperationException("An authenticated user is already assigned");
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			var t = UserSettings.SaveAsync();
			SetAuditFields();
			int result = base.SaveChanges(acceptAllChangesOnSuccess);
			t.GetAwaiter().GetResult();
			return result;
		}

		public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			var t = UserSettings.SaveAsync(cancellationToken);
			SetAuditFields();
			int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
			await t;
			return result;
		}

		public bool EntityHasChanges(object entity)
		{
			var entry = Entry(entity);

			if (entry.State != EntityState.Unchanged)
			{
				return true;
			}
			else
			{
				entry.DetectChanges();

				bool result = false;
				foreach (var property in entry.OriginalValues.Properties)
				{
					var original = entry.OriginalValues[property];
					var current = entry.CurrentValues[property];

					if (!Equals(original, current))
					{
						result = true;
						break;
					}
				}
				return result;
			}
		}

		public void RevertChanges()
		{
			foreach (var entry in ChangeTracker.Entries())
			{
				RevertEntry(entry);
			}
		}

		public void RevertEntity(object entity)
		{
			var entry = Entry(entity);
			RevertEntry(entry);
		}

		private static void RevertEntry(EntityEntry entry)
		{
			if (entry.State == EntityState.Modified)
			{
				entry.CurrentValues.SetValues(entry.OriginalValues);
				entry.State = EntityState.Unchanged;
			}
			else if (entry.State == EntityState.Added)
			{
				entry.State = EntityState.Detached;
			}
			else if (entry.State == EntityState.Deleted)
			{
				entry.State = EntityState.Unchanged;
			}
		}

		private void SetAuditFields()
		{
			if (AuthenticatedUser is not null)
			{
				foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
				{
					if (entry.State == EntityState.Added)
					{
						entry.Entity.CreatedAt = DateTime.UtcNow;
						entry.Entity.CreatedBy = AuthenticatedUser.Id;
					}
					else if (entry.State == EntityState.Modified)
					{
						entry.Entity.ModifiedAt = DateTime.UtcNow;
						entry.Entity.ModifiedBy = AuthenticatedUser.Id;
					}
					else if (entry.State == EntityState.Deleted)
					{
						entry.Entity.Active = false;
						entry.State = EntityState.Modified;
					}
				}
			}
			else throw new AuthenticationException("Authenticated user is required to set audit fields");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionStringBuilder = new NpgsqlConnectionStringBuilder
			{
				Database = "mom",
				Host = UserSettings.DatabaseHost,
				Port = UserSettings.DatabasePort ?? 5432,
				Username = UserSettings.DatabaseUsername,
				Password = SecurityHelper.Decrypt(UserSettings.DatabasePassword)
			};
			string connectionString = connectionStringBuilder.ToString();

			optionsBuilder.UseNpgsql(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(user =>
			{
				user.HasIndex(u => u.Username).IsUnique();
				user.Property(u => u.IsLoggedIn).HasDefaultValue(false);
			});
			modelBuilder.Entity<Household>(household =>
			{
				household.OwnsOne(h => h.Address);
			});
			modelBuilder.Entity<Individual>(individual =>
			{
				individual.Property(i => i.Child).HasDefaultValue(false);
			});
			foreach (var type in modelBuilder.Model.GetEntityTypes())
			{
				if (typeof(AuditableEntity).IsAssignableFrom(type.ClrType))
				{
					modelBuilder.Entity(type.Name, entity =>
					{
						entity.Property<DateTime>(nameof(AuditableEntity.CreatedAt))
							.HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

						entity.Property<bool>(nameof(AuditableEntity.Active))
							.HasDefaultValue(true);
					});
				}
			}
		}

		public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
		{
			public AppContext CreateDbContext(string[] args)
			{
				var settings = UserSettings.LoadAsync().GetAwaiter().GetResult();
				return new AppContext(settings);
			}
		}
	}
}
