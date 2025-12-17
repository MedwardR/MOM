using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MigrationTool.SK.Models;

namespace MigrationTool.SK;

internal class SKContext(string path) : DbContext
{
	public DbSet<Family> Families { get; set; }
	public DbSet<Individual> Individuals { get; set; }
	public DbSet<Reference> References { get; set; }

	public override int SaveChanges(bool acceptAllChangesOnSuccess)
	{
		throw new InvalidOperationException("Writing back to the SK database is a bad idea");
	}

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
	{
		throw new InvalidOperationException("Writing back to the SK database is a bad idea");
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionStringBuilder = new SqliteConnectionStringBuilder()
		{
			DataSource = path,
		};
		string connectionString = connectionStringBuilder.ToString();

		optionsBuilder.UseSqlite(connectionString);
		optionsBuilder.UseLazyLoadingProxies();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Family>(entity =>
		{
			entity.HasKey(f => f.FAMILY_ID);
			entity.ToTable("csFAMILY");
		});
		modelBuilder.Entity<Individual>(entity =>
		{
			entity.HasKey(i => i.IND_ID);
			entity.ToTable("csIND");
		});
	}
}
