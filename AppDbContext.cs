using Microsoft.EntityFrameworkCore;
using MOM.Models;

namespace MOM
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<Household> Households { get; set; }

		public static AppDbContext CreateAutomatically()
		{
			var postgresOptions = CreateOptionsForPostgreSQL();
			return new AppDbContext(postgresOptions);
		}

		private static DbContextOptions<AppDbContext> CreateOptionsForPostgreSQL()
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
			}
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			string connectionString = connectionStringBuilder.ToString();
			optionsBuilder.UseNpgsql(connectionString);
			return optionsBuilder.Options;
		}
	}
}
