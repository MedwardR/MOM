using MOM.Helpers;
using Serilog;
using System.Diagnostics;
using System.Text;

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

			if (!string.IsNullOrWhiteSpace(_settings.BackupDirectory))
			{
				if (!string.IsNullOrWhiteSpace(_settings.BackupPassword))
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
					Log.Information("No backup password configured");
					return false;
				}
			}
			else
			{
				Log.Information("No backup directory configured");
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
		string destination = Path.Combine(_settings.BackupDirectory!, $"{timestamp}.dump.encrypted");
		string temp = Path.GetTempFileName();
		try
		{
			const int timeout = 60000;
			if (!Debugger.IsAttached) _cts.CancelAfter(timeout);

			var timeoutTask = InterpolateProgressBarAsync(progressBar1, timeout, _cts.Token);
			await BackupHelper.BackupAsync(_settings, temp, _cts.Token);

			string password = SecurityHelper.Decrypt(_settings.BackupPassword);
			await BackupHelper.EncryptAsync(temp, destination, password);
		}
		catch (Exception ex)
		{
			try
			{
				if (File.Exists(destination))
				{
					File.Delete(destination);
				}
			}
			catch (Exception inner)
			{
				Log.Error(inner, "Error deleting files from unsuccessful backup");
			}
			if (ex is not OperationCanceledException)
			{
				Log.Error(ex, "Error occurred during backup");
				var message = new StringBuilder();
				message.AppendLine("Warning: backup not created due to the following error:");
				message.AppendLine();
				message.Append(ex.Message);
				MessageBox.Show(message.ToString(), "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		finally
		{
			try
			{
				if (File.Exists(temp))
				{
					File.Delete(temp);
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error deleting backup temp files");
			}
			Close();
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
