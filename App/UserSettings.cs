using System.ComponentModel;
using System.Text.Json;

namespace MOM
{
	public class UserSettings
	{
		public string? DatabaseHost { get; set; }

		public int? DatabasePort { get; set; }

		public string? DatabaseUsername { get; set; }

		[PasswordPropertyText(true)]
		public string? DatabasePassword { get; set; }

		private static readonly JsonSerializerOptions _serializerOptions = new()
		{
			WriteIndented = true,
		};

		public static async Task<UserSettings> LoadAsync(CancellationToken cancellationToken = default)
		{
			cancellationToken.ThrowIfCancellationRequested();

			string file = Program.GetSavedFile("settings.json");
			if (File.Exists(file))
			{
				string json = await File.ReadAllTextAsync(file, cancellationToken);
				return JsonSerializer.Deserialize<UserSettings>(json) ?? new();
			}
			else return new();
		}

		public async Task SaveAsync(CancellationToken cancellationToken = default)
		{
			cancellationToken.ThrowIfCancellationRequested();

			string json = JsonSerializer.Serialize(this, _serializerOptions);
			string file = GetFilePath();
			if (Path.GetDirectoryName(file) is string directory)
			{
				Directory.CreateDirectory(directory);
			}
			await File.WriteAllTextAsync(file, json, cancellationToken);
		}

		private static string GetFilePath()
		{
			return Program.GetSavedFile("settings.json");
		}
	}
}
