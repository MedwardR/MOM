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

        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
			InitializeLogger();
			Application.Run(new frmLogin());
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

		public static string GetSavedFile(string filename)
		{
			string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			return Path.Combine(programFiles, Name, filename);
		}
	}
}
