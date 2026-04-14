using MOM.Utilities;
using System.Diagnostics;
using System.Text;

namespace MOM.Abstractions;

internal abstract class Report
{
	protected abstract string GetTitle();
	protected abstract string GetPageMargin();
	protected abstract Task<string> GetBodyAsync();
	protected abstract string GetStyle();
	public virtual IEnumerable<string> GetHeaders()
	{
		yield return GetTitle();
		yield return "Bowmansville Mennonite Church";
	}

	public async Task ShowAsync()
	{
		string temp = GetFilePath();

		string html = await BuildDocumentAsync();
		File.WriteAllText(temp, html);

		using var process = new Process();
		process.StartInfo.FileName = temp;
		process.StartInfo.UseShellExecute = true;

		process.Start();
	}

	private string GetFilePath()
	{
		string directory = Path.GetTempPath();
		string title = GetTitle();

		var tokens = new List<string>();
		var builder = new StringBuilder();

		foreach (char c in title)
		{
			if (char.IsLetterOrDigit(c))
			{
				builder.Append(c);
			}
			else if (builder.Length > 0)
			{
				string value = builder.ToString().ToLowerInvariant();
				tokens.Add(value);
				builder.Clear();
			}
		}
		if (builder.Length > 0)
		{
			string value = builder.ToString().ToLowerInvariant();
			tokens.Add(value);
		}
		string path = GetDocumentPath(directory, tokens);

		if (File.Exists(path))
		{
			string date = DateTime.Today.ToString("yyyy-MM-dd");
			tokens.Add(date);
			path = GetDocumentPath(directory, tokens);
		}
		if (File.Exists(path))
		{
			string guid = Guid.NewGuid().ToString();
			tokens.Add(guid);
			path = GetDocumentPath(directory, tokens);
		}
		return path;
	}

	private async Task<string> BuildDocumentAsync()
	{
		string title = GetTitle();
		string margin = GetPageMargin();
		const string organization = "Bowmansville Mennonite Church";

		var global = EnumerateLines(GetGlobalStyle());
		var style = EnumerateLines(GetStyle());
		var body = EnumerateLines(await GetBodyAsync());

		var builder = new CodeBuilder();
		builder.AppendLine(0, "<!DOCTYPE html>");
		builder.AppendLine(0, "<html>");
		builder.AppendLine(0, "<head>");

		builder.AppendLine(1, "<title>");
		builder.AppendLine(2, title);
		builder.AppendLine(1, "</title>");

		builder.AppendLine(1, "<style>");
		builder.AppendLine(2, "@page {");
		builder.AppendLine(3, $"margin: {margin};");
		builder.AppendLine(2, "}");
		builder.AppendLine(1, "</style>");

		builder.AppendLine(1, "<style>");
		foreach (string line in global) builder.AppendLine(2, line);
		builder.AppendLine(1, "</style>");

		builder.AppendLine(1, "<style>");
		foreach (string line in style) builder.AppendLine(2, line);
		builder.AppendLine(1, "</style>");

		builder.AppendLine(0, "</head>");
		builder.AppendLine(0, "<body>");

		var headers = GetHeaders();
		foreach (string value in headers)
		{
			builder.AppendLine(1, "<div class=\"header\">");
			builder.AppendLine(2, value);
			builder.AppendLine(1, "</div>");
		}
		builder.AppendLine(1, "<div class=\"line\"></div>");
		foreach (string line in body) builder.AppendLine(1, line);

		builder.AppendLine(0, "</body>");
		builder.AppendLine(0, "</html>");
		return builder.ToString();
	}

	private static string GetGlobalStyle()
	{
		var builder = new CodeBuilder();

		builder.AppendLine(0, ":root {");
		builder.AppendLine(1, "font-family: Calibri, sans-serif;");
		builder.AppendLine(0, "}");
		builder.AppendLine(0, "html {");
		builder.AppendLine(1, "margin: 0;");
		builder.AppendLine(1, "padding: 0;");
		builder.AppendLine(0, "}");
		builder.AppendLine(0, "body {");
		builder.AppendLine(1, "margin: 1rem;");
		builder.AppendLine(1, "padding: 0;");
		builder.AppendLine(0, "}");
		builder.AppendLine(0, ".header {");
		builder.AppendLine(1, "text-align: center;");
		builder.AppendLine(1, "font-weight: bold;");
		builder.AppendLine(0, "}");
		builder.AppendLine(0, ".line {");
		builder.AppendLine(1, "height: 1px;");
		builder.AppendLine(1, "margin: 1rem 0 1rem 0;");
		builder.AppendLine(1, "background-color: #000;");
		builder.AppendLine(0, "}");
		builder.AppendLine(0, "@media print {");
		builder.AppendLine(1, "body {");
		builder.AppendLine(2, "margin: 0;");
		builder.AppendLine(1, "}");
		builder.AppendLine(0, "}");

		return builder.ToString();
	}

	private static string GetDocumentPath(string directory, IEnumerable<string> tokens)
	{
		string name = string.Join('-', tokens);
		string path = Path.Combine(directory, name);
		return Path.ChangeExtension(path, "html");
	}

	private static IEnumerable<string> EnumerateLines(string content)
	{
		using var reader = new StringReader(content);
		string? line;

		while ((line = reader.ReadLine()) is not null)
		{
			yield return line;
		}
	}
}
