using MigrationTool.MOM;
using MigrationTool.SK;
using System.CommandLine;

namespace MigrationTool;

internal class Program
{
	private static void Main(string[] args)
	{
		var arguments = Arguments.Parse(args);
		
		using var mom = new MOMContext(
			arguments.DatabaseHost,
			arguments.DatabasePort,
			arguments.DatabaseUsername,
			arguments.DatabasePassword);
		using var sk = new SKContext(arguments.SKBackupPath);

		SKImporter.Import(mom, sk);
	}

	private class Arguments
	{
		public required string DatabaseHost { get; init; }
		public required int DatabasePort { get; init; }
		public required string DatabaseUsername { get; init; }
		public required string DatabasePassword { get; init; }
		public required string SKBackupPath { get; init; }

		public static Arguments Parse(string[] args)
		{
			var host = new Option<string>("Hostname", "--hostname", "--host", "-h") { Required = true };
			var port = new Option<int?>("Port", "--port") { Required = false };
			var user = new Option<string>("Username", "--username", "--user", "-u") { Required = true };
			var password = new Option<string>("Password", "--password", "--pass", "-p") { Required = true };
			var sk = new Option<string>("Source", "--sk") { Required = true };

			var command = new RootCommand("MOM Migration Tool")
			{
				host,
				port,
				user,
				password,
				sk,
			};
			var result = command.Parse(args);

			return new Arguments
			{
				DatabaseHost = result.GetRequiredValue(host),
				DatabasePort = result.GetValue(port) ?? 5432,
				DatabaseUsername = result.GetRequiredValue(user),
				DatabasePassword = result.GetRequiredValue(password),
				SKBackupPath = result.GetRequiredValue(sk),
			};
		}
	}
}
