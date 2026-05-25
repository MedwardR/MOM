using DataCommon.Models;
using DataCommon.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MigrationTool.MOM;

public class MOMContext(string host, int port, string username, string password) : DbContext
{
	public DbSet<Household> Households { get; set; }
	public DbSet<Individual> Individuals { get; set; }
	public DbSet<User> Users { get; set; }

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
