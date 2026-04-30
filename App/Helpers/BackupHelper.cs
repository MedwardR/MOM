using Serilog;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MOM.Helpers;

internal class BackupHelper
{
	public static string GetBackupDestination(UserSettings settings)
	{
		string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		return Path.Combine(settings.BackupDirectory!, $"{timestamp}.dump.encrypted");
	}

	public static async Task BackupAsync(UserSettings settings, string path, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		Log.Information($"Create database backup at: {path}");

		using var process = new Process();
		process.StartInfo.FileName = "pg_dump";
		process.StartInfo.Arguments = string.Join(' ', [
			"-h", settings.DatabaseHost,
			"-U", settings.DatabaseUsername,
			"-d", "mom",
			"-F", "c",
			"-v",
			"-f", path,
		]);
		process.StartInfo.Environment["PGPASSWORD"] = SecurityHelper.Decrypt(settings.DatabasePassword);
		process.StartInfo.CreateNoWindow = true;
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError = true;
		process.EnableRaisingEvents = true;

		cancellationToken.ThrowIfCancellationRequested();
		process.Start();
		await process.WaitForExitAsync(cancellationToken);

		if (process.HasExited)
		{
			if (process.ExitCode != 0)
			{
				string stdout = await process.StandardOutput.ReadToEndAsync(cancellationToken);
				string stderr = await process.StandardError.ReadToEndAsync(cancellationToken);
				var innerException = new Exception($"stdout: {stdout}{Environment.NewLine}stderr: {stderr}");
				throw new Exception("Backup process did not exit successfully", innerException);
			}
			else Log.Information("Backup successful!");
		}
		else
		{
			try
			{
				process.Kill();
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error killing cancelled backup process");
			}
		}
	}

	public static async Task EncryptAsync(string inputPath, string outputPath, string password)
	{
		byte[] salt = RandomNumberGenerator.GetBytes(16);

		using var key = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
		using var aes = Aes.Create();
		aes.Key = key.GetBytes(32);
		aes.GenerateIV();

		using var input = File.OpenRead(inputPath);
		using var output = File.Create(outputPath);

		await output.WriteAsync(salt);
		await output.WriteAsync(aes.IV);

		using var crypto = new CryptoStream(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
		await input.CopyToAsync(crypto);
		await crypto.FlushFinalBlockAsync();
	}

	public static async Task DecryptAsync(string inputPath, string outputPath, string password)
	{
		using var input = File.OpenRead(inputPath);

		byte[] salt = new byte[16];
		input.ReadExactly(salt);

		byte[] iv = new byte[16];
		input.ReadExactly(iv);

		using var key = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
		using var aes = Aes.Create();
		aes.Key = key.GetBytes(32);
		aes.IV = iv;

		using var crypto = new CryptoStream(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
		using var output = File.Create(outputPath);
		await crypto.CopyToAsync(output);
	}
}
