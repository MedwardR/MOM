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
				builder.AppendLine("**Message:**");
				builder.AppendLine(ex.Message);
				builder.AppendLine();
				builder.AppendLine("**Stack trace:**");
				builder.AppendLine(ex.StackTrace);

				var inner = ex.InnerException;
				while (inner is not null)
				{
					builder.AppendLine();
					builder.AppendLine("Inner exception:");
					builder.AppendLine(inner.Message);
					inner = inner.InnerException;
				}
			}
			else builder.AppendLine("No exception data");

			_title = "Unhandled Exception";
			_body = builder.ToString();

			tbErrorMessage.Text = _body;
		}

		private void frmError_Shown(object sender, EventArgs e)
		{
			llReport.Focus();
		}

		private void llSubmitBugReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var sb = new StringBuilder();
			sb.AppendLine("**Steps to recreate error:**");
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine("*Please fill in this section!*");
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine();
			sb.Append(_body);

			var query = HttpUtility.ParseQueryString(string.Empty);
			query["template"] = "bug_report.md";
			query["title"] = _title;
			query["body"] = sb.ToString();
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
			Close();
		}
	}
}
