using System.Diagnostics;
using System.Text;
using System.Web;

namespace MOM;

public partial class frmError : Form
{
	public Exception Exception { get; }
	public bool ExitProgram { get; private set; }

	public frmError(Exception? ex)
	{
		InitializeComponent();
		Exception = ex ?? new Exception("No exception data");
		tbErrorMessage.Text = Exception.ToString();
	}

	private void frmError_Shown(object sender, EventArgs e)
	{
		llReport.Focus();
	}

	private void llReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		var sb = new StringBuilder();
		sb.AppendLine("**Steps to recreate the error:**");
		sb.AppendLine();
		sb.AppendLine("1. ");
		sb.AppendLine("2. ");
		sb.AppendLine("3. ");
		sb.AppendLine();
		sb.AppendLine();
		sb.AppendLine();
		sb.AppendLine();
		sb.AppendLine("**Exception details:**");
		sb.AppendLine(Exception.ToString());
		sb.AppendLine();
		sb.AppendLine();
		sb.AppendLine($"**Version: {Program.Version}**");

		var query = HttpUtility.ParseQueryString(string.Empty);
		query["template"] = "bug_report.md";
		query["title"] = "Unhandled Exception";
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

	private void btnContinueAnyway_Click(object sender, EventArgs e)
	{
		ExitProgram = false;
		Close();
	}

	private void btnCloseProgram_Click(object sender, EventArgs e)
	{
		ExitProgram = true;
		Close();
	}
}