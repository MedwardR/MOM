using System.Diagnostics;
using System.Text;

namespace MOM.Abstractions;

internal abstract class Report
{
	protected static string Indent => "    ";

	protected abstract string GetTitle();
	protected abstract Task<string> GetBodyAsync();
	protected abstract string GetStyle();

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
		string organization = "Bowmansville Mennonite Church";
		var global = EnumerateLines(GetGlobalStyle());
		var style = EnumerateLines(GetStyle());
		var body = EnumerateLines(await GetBodyAsync());

		var builder = new StringBuilder();
		builder.AppendLine("<!DOCTYPE html>");
		builder.AppendLine("<html>");
		builder.AppendLine("<head>");

		builder.AppendLine(Indent + "<title>");
		builder.AppendLine(Indent + Indent + title);
		builder.AppendLine(Indent + "</title>");

		builder.AppendLine(Indent + "<style>");
		foreach (string line in global) builder.AppendLine(Indent + Indent + line);
		builder.AppendLine(Indent + "</style>");

		builder.AppendLine(Indent + "<style>");
		foreach (string line in style) builder.AppendLine(Indent + Indent + line);
		builder.AppendLine(Indent + "</style>");

		builder.AppendLine("</head>");
		builder.AppendLine("<body>");

		builder.AppendLine(Indent + "<div class=\"header\">");
		builder.AppendLine(Indent + Indent + organization);
		builder.AppendLine(Indent + "</div>");

		builder.AppendLine(Indent + "<div class=\"header\">");
		builder.AppendLine(Indent + Indent + title);
		builder.AppendLine(Indent + "</div>");

		builder.AppendLine(Indent + "<div class=\"line\"></div>");
		foreach (string line in body) builder.AppendLine(Indent + line);

		builder.AppendLine("</body>");
		builder.AppendLine("</html>");
		return builder.ToString();
	}

	private static string GetGlobalStyle() => @"
		@page {
			margin: 1in;
		}
		:root {
			font-family: Calibri, sans-serif;
		}
		html {
			margin: 0;
			padding: 0;
		}
		body {
			margin: 1rem;
			padding: 0;
		}
		.header {
			text-align: center;
			font-weight: bold;
		}
		.line {
			height: 1px;
			margin: 1rem 0 1rem 0;
			background-color: #000;
		}
		@media print {
			body {
				margin: 0;
			}
		}
	";

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
