using MOM.Forms;
using Serilog;

namespace MOM
{
    internal static class Program
    {
		public static Version Version { get => Version.Parse("1.0.3"); }
		public static bool DevelopmentMode { get; private set; }

		private static frmMain? _mainForm;

		[STAThread]
        private static void Main(string[] args)
        {
			ApplicationConfiguration.Initialize();

			DevelopmentMode = args.Contains("debug", StringComparer.OrdinalIgnoreCase);

			if (args.Contains("tools", StringComparer.OrdinalIgnoreCase))
			{
				Application.Run(new frmTools());
			}
			else
			{
				Application.ThreadException += (s, e) =>
				{
					HandleException(e.Exception, "An unhandled exception occurred");
				};
				AppDomain.CurrentDomain.UnhandledException += (s, e) =>
				{
					HandleException(e.ExceptionObject as Exception, "An unhandled exception occurred");
				};

				InitializeLogger();
				Log.Information("Application start");

				_mainForm = new frmMain();
				Application.Run(_mainForm);
				_mainForm.LogOut();

				Log.Information("Application close");
				CloseLogger();
			}
        }

		private static void InitializeLogger()
		{
			var logFile = GetLogFile();
			var loggerConfiguration = new LoggerConfiguration();
			loggerConfiguration.MinimumLevel.Debug();
			loggerConfiguration.WriteTo.File(logFile);
			Log.Logger = loggerConfiguration.CreateLogger();
		}

		public static void CloseLogger()
		{
			Log.CloseAndFlush();
		}

		private static string GetLogFile()
		{
			return GetSavedFile(Path.Combine("logs", $"log-{DateTime.Now:yyyy-MM-dd}.txt"));
		}

		public static string GetSavedFile(string fileName)
		{
			string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			return Path.Combine(localAppData, "MOM", fileName);
		}

		private static void HandleException(Exception? ex, string context)
		{
			Log.Fatal(ex, context);
			try
			{
				using var frm = new frmError(ex);
				frm.ShowDialog();
			}
			catch (Exception e)
			{
				Log.Fatal(e, "An error occurred while displaying the error form");
			}
			_mainForm?.LogOut();
			CloseLogger();
			Environment.Exit(1);
		}
	}
}
