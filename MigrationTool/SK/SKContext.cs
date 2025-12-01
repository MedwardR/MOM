using Microsoft.EntityFrameworkCore;
using MigrationTool.SK.Models;

namespace MigrationTool.SK;

internal class SKContext : DbContext
{
	public DbSet<Family> Families { get; set; }
	public DbSet<Individual> Individuals { get; set; }

	public override int SaveChanges(bool acceptAllChangesOnSuccess)
	{
		throw new InvalidOperationException("Writing back to the SK database is a bad idea");
	}

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
	{
		throw new InvalidOperationException("Writing back to the SK database is a bad idea");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Family>().HasKey(f => f.FAMILY_ID);
		modelBuilder.Entity<Family>().ToTable("csFAMILY");
	}
}
