using MOM.Helpers;
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

	public async Task<bool> IsConfiguredAsync()
	{
		try
		{
			if (Directory.Exists(_settings.BackupDirectory))
			{
				using var process = new Process();
				process.StartInfo.FileName = "pg_dump";
				process.StartInfo.Arguments = "--version";
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = true;

				var tcs = new TaskCompletionSource();
				process.Exited += (s, e) => tcs.TrySetResult();
				process.Start();

				var timeoutTask = Task.Delay(5000);
				var completedTask = await Task.WhenAny(tcs.Task, timeoutTask);

				if (completedTask != timeoutTask)
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

					return false;
				}
			}
			else return false;
		}
		catch
		{
			return false;
		}
	}

	private async void frmBackup_Load(object sender, EventArgs e)
	{
		if (await IsConfiguredAsync())
		{
			string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

			using var process = new Process();
			process.StartInfo.FileName = "pg_dump";
			process.StartInfo.Arguments = string.Join(' ', [
				"-h", _settings.DatabaseHost,
				"-U", _settings.DatabaseUsername,
				"-d", "mom",
				"-F", "c",
				"-v",
				"-f", Path.Combine(_settings.BackupDirectory!, $"{timestamp}.backup"),
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

			await Task.Delay(5000, _cts.Token); // Debug only

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
