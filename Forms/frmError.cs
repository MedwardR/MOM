using Serilog;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace MOM
{
	public partial class frmError : Form
	{
		private readonly string _title;
		private readonly string _body;

		public frmError(Exception? ex)
		{
			InitializeComponent();

			var builder = new StringBuilder();
			if (ex is not null)
			{
				builder.AppendLine("Message:");
				builder.AppendLine(ex.Message);
				builder.AppendLine();
				builder.AppendLine("Stack trace:");
				builder.AppendLine(ex.StackTrace);
			}
			else
			{
				builder.AppendLine("No exception data");
			}

			_title = "Unhandled Exception";
			_body = builder.ToString();

			tbErrorMessage.Text = _body;
		}

		private void llSubmitBugReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["title"] = _title;
			query["body"] = _body;
			var builder = new UriBuilder("https://github.com/MedwardR/MOM/issues/new")
			{
				Query = query.ToString()
			};
			var startInfo = new ProcessStartInfo
			{
				FileName = builder.ToString(),
				UseShellExecute = true
			};
			Process.Start(startInfo);
		}

		private void btnCloseProgram_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			try
			{
				Application.Exit();
			}
			catch (Exception ex)
			{
				Log.Error(ex, "An error occurred while closing the app");
				Environment.Exit(1);
			}
		}

		private void btnContinueAnyway_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Continue;
			Close();
		}
	}
}
