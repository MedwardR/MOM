using Microsoft.EntityFrameworkCore;
using MOM.Models;

namespace MOM
{
	public class AppDbContext : DbContext
	{
		public DbSet<Household> Households { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionStringBuilder = new Npgsql.NpgsqlConnectionStringBuilder
			{
				Database = "mom",
			};
			if (Program.IsDevelopmentEnvironment)
			{
				connectionStringBuilder.Port = 5432;
				connectionStringBuilder.Host = "localhost";
				connectionStringBuilder.Username = "postgres";
				connectionStringBuilder.Password = "postgres";
			}
			else
			{
				// use real server
				throw new NotImplementedException();
			}
			string connectionString = connectionStringBuilder.ToString();
			optionsBuilder.UseNpgsql(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(entity =>
			{
				entity.HasIndex(u => u.Username).IsUnique();
			});
		}
	}
}
