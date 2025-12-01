using DataCommon.Models;
using DataCommon.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;

namespace MigrationTool.MOM
{
	public class MOMContext(string host, int port, string username, string password) : DbContext
	{
		public DbSet<Household> Households { get; set; }
		public DbSet<Individual> Individuals { get; set; }
		public DbSet<User> Users { get; set; }

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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionStringBuilder = new NpgsqlConnectionStringBuilder
			{
				Database = "mom",
				Host = host,
				Port = port,
				Username = username,
				Password = password,
			};
			string connectionString = connectionStringBuilder.ToString();

			optionsBuilder.UseNpgsql(connectionString);
			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(entity =>
			{
				entity.HasIndex(u => u.Username).IsUnique();
				entity.Property(u => u.IsLoggedIn).HasDefaultValue(false);
			});
			modelBuilder.Entity<Household>().OwnsOne(h => h.Address);

			foreach (var type in modelBuilder.Model.GetEntityTypes())
			{
				if (typeof(AuditableEntity).IsAssignableFrom(type.ClrType))
				{
					modelBuilder.Entity(type.Name)
						.Property<DateTime>(nameof(AuditableEntity.CreatedAt))
						.HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

					modelBuilder.Entity(type.Name)
						.Property<bool>(nameof(AuditableEntity.Active))
						.HasDefaultValue(true);
				}
			}
		}
	}
}
