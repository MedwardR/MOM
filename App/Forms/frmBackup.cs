using MOM.Helpers;
using Serilog;
using System.Diagnostics;

namespace MOM.Forms;

public partial class frmBackup : Form
{
	private readonly UserSettings _settings;
	private readonly CancellationTokenSource _cts;

	public frmBackup(UserSettings settings)
	{
		_settings = settings;
		_cts = new();
		InitializeComponent();
	}

	public bool IsConfigured()
	{
		try
		{
			Log.Information("Checking if backup is configured...");

			if (Directory.Exists(_settings.BackupDirectory))
			{
				using var process = new Process();
				process.StartInfo.FileName = "pg_dump";
				process.StartInfo.Arguments = "--version";
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = false;
				process.StartInfo.RedirectStandardError = false;
				process.EnableRaisingEvents = false;

				process.Start();
				process.WaitForExit(5000);

				if (process.HasExited)
				{
					return process.ExitCode == 0;
				}
				else
				{
					try
					{
						if (!process.HasExited)
						{
							process.Kill(true);
						}
					}
					catch { }
					throw new TimeoutException("Process took too long to complete: pg_dump --version");
				}
			}
			else
			{
				Log.Information($"Backup directory does not exist: {_settings.BackupDirectory}");
				return false;
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex, "An error occurred while checking backup configuration");
			return false;
		}
	}

	private async void frmBackup_Load(object sender, EventArgs e)
	{
		string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		string path = Path.Combine(_settings.BackupDirectory!, $"{timestamp}.backup");

		Log.Information($"Backing up database to: {path}");

		using var process = new Process();
		process.StartInfo.FileName = "pg_dump";
		process.StartInfo.Arguments = string.Join(' ', [
			"-h", _settings.DatabaseHost,
			"-U", _settings.DatabaseUsername,
			"-d", "mom",
			"-F", "c",
			"-v",
			"-f", path,
		]);
		process.StartInfo.Environment["PGPASSWORD"] = SecurityHelper.Decrypt(_settings.DatabasePassword);
		process.StartInfo.CreateNoWindow = true;
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError = true;
		process.EnableRaisingEvents = true;

		const int timeout = 60000; // 60 seconds

		var tcs = new TaskCompletionSource();
		process.Exited += (s, e) => tcs.TrySetResult();
		process.Start();

		var progressTask = InterpolateProgressBarAsync(progressBar1, timeout, _cts.Token);

		var timeoutTask = Task.Delay(timeout, _cts.Token);
		using var completedTask = await Task.WhenAny(tcs.Task, timeoutTask);

		if (completedTask != timeoutTask)
		{
			if (process.ExitCode == 0)
			{
				Close();
			}
			else
			{
				string stdout = await process.StandardOutput.ReadToEndAsync(_cts.Token);
				string stderr = await process.StandardError.ReadToEndAsync(_cts.Token);
				var innerException = new Exception($"stdout: {stdout}{Environment.NewLine}stderr: {stderr}");
				throw new Exception("The backup process failed", innerException);
			}
		}
		else
		{
			try
			{
				if (!process.HasExited)
				{
					process.Kill(true);
				}
			}
			catch { }

			string stdout = await process.StandardOutput.ReadToEndAsync(_cts.Token);
			string stderr = await process.StandardError.ReadToEndAsync(_cts.Token);
			var innerException = new Exception($"stdout: {stdout}{Environment.NewLine}stderr: {stderr}");
			throw new Exception("The backup process timed out", innerException);
		}
	}

	private static async Task InterpolateProgressBarAsync(ProgressBar progress, int duration, CancellationToken cancellationToken)
	{
		try
		{
			progress.Minimum = 0;
			progress.Maximum = duration;

			var sw = Stopwatch.StartNew();

			while (sw.ElapsedMilliseconds < duration)
			{
				cancellationToken.ThrowIfCancellationRequested();

				progress.Value = (int)sw.ElapsedMilliseconds;
				await Task.Delay(100, cancellationToken);
			}

			progress.Value = duration;
		}
		catch
		{
			cancellationToken.ThrowIfCancellationRequested();
			throw;
		}
	}

	private void frmBackup_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (!_cts.IsCancellationRequested)
		{
			_cts.Cancel();
		}
		_cts.Dispose();
	}
}
