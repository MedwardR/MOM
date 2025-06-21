using MOM.Forms;
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
        private static void Main(string[] args)
        {
			ApplicationConfiguration.Initialize();

			if (args.Length > 0)
			{
				if (args[0] == "tools") Application.Run(new frmTools());
			}
			else
			{
				Application.ThreadException += (s, e) =>
				{
					HandleException(e.Exception, "An unhandled UI exception occurred");
				};
				AppDomain.CurrentDomain.UnhandledException += (s, e) =>
				{
					HandleException(e.ExceptionObject as Exception, "An unhandled non-UI exception occurred");
				};

				InitializeLogger();

				Log.Information("Application start");
				Application.Run(new frmMain());

				Log.Information("Application close" + Environment.NewLine);
				Log.CloseAndFlush();
			}
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
			try
			{
				Application.Exit();
			}
			catch (Exception e)
			{
				Log.Fatal(e, "An error occurred while closing the app");
				Environment.Exit(1);
			}
		}
	}
}
