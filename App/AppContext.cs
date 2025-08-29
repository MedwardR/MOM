using Microsoft.EntityFrameworkCore;
using MOM.Models;
using MOM.Models.Abstract;
using System.Security.Authentication;

namespace MOM
{
	public class AppContext : DbContext
	{
		public User? AuthenticatedUser { get; private set; }

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
			SetAuditFields();
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			SetAuditFields();
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		private void SetAuditFields()
		{
			if (AuthenticatedUser is not null)
			{
				foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
				{
					if (entry.State == EntityState.Added)
					{
						entry.Entity.CreatedAt = DateTime.Now;
						entry.Entity.CreatedBy = AuthenticatedUser.Id;
					}
					else if (entry.State == EntityState.Modified)
					{
						entry.Entity.ModifiedAt = DateTime.Now;
						entry.Entity.ModifiedBy = AuthenticatedUser.Id;
					}
				}
			}
			else throw new AuthenticationException("Authenticated user is required to set audit fields");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionStringBuilder = new Npgsql.NpgsqlConnectionStringBuilder
			{
				Database = "mom",
			};
			if (Program.DevelopmentMode)
			{
				connectionStringBuilder.Host = "localhost";
				connectionStringBuilder.Port = 5432;
				connectionStringBuilder.Username = "postgres";
				connectionStringBuilder.Password = "postgres";
			}
			else
			{
				connectionStringBuilder.Host = Environment.GetEnvironmentVariable("MOM_DB_HOST");
				connectionStringBuilder.Port = int.Parse(Environment.GetEnvironmentVariable("MOM_DB_PORT") ?? "5432");
				connectionStringBuilder.Username = Environment.GetEnvironmentVariable("MOM_DB_USERNAME");
				connectionStringBuilder.Password = Environment.GetEnvironmentVariable("MOM_DB_PASSWORD");
			}
			string connectionString = connectionStringBuilder.ToString();
			optionsBuilder.UseNpgsql(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(entity =>
			{
				entity.HasIndex(u => u.Username).IsUnique();
				entity.Property(u => u.IsLoggedIn).HasDefaultValue(false);
				entity.Property(u => u.IsActive).HasDefaultValue(true);
				entity.Property(u => u.CreatedAt).HasDefaultValueSql("now()");
			});
			modelBuilder.Entity<Individual>().OwnsOne(i => i.Address);
			modelBuilder.Entity<Household>().OwnsOne(h => h.Address);
		}
	}
}
