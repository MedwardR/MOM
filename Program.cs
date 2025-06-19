using Serilog;

namespace MOM
{
    internal static class Program
    {
		public static string Name { get => "MOM"; }
		public static int Version { get => 1; }

		public static bool IsDevelopmentEnvironment
		{
			get
			{
				string debugFile = GetSavedFile("debug");
				return File.Exists(debugFile);
			}
		}

		public static string GetSavedFile(string filename)
		{
			string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			return Path.Combine(programFiles, Name, filename);
		}

		[STAThread]
        private static void Main()
        {
			Application.ThreadException += (s, e) =>
			{
				HandleException(e.Exception, "An unhandled UI exception occurred");
			};
			AppDomain.CurrentDomain.UnhandledException += (s, e) =>
			{
				HandleException(e.ExceptionObject as Exception, "An unhandled non-UI exception occurred");
			};

            ApplicationConfiguration.Initialize();
			InitializeLogger();

			Log.Information("Application start");
			Application.Run(new frmMain());

			Log.Information("Application close" + Environment.NewLine);
			Log.CloseAndFlush();
        }

		private static void InitializeLogger()
		{
			var logFile = GetSavedFile("logs/log.txt");
			var loggerConfiguration = new LoggerConfiguration();
			loggerConfiguration.MinimumLevel.Debug();
			loggerConfiguration.WriteTo.File(logFile, rollingInterval: RollingInterval.Day);
			Log.Logger = loggerConfiguration.CreateLogger();
		}

		private static void HandleException(Exception? ex, string context)
		{
			Log.Error(ex, context);
			try
			{
				using var frm = new frmError(ex);
				frm.ShowDialog();
			}
			catch (Exception ex)
			{

			}
		}
	}
}
