using System.Text;

namespace MOM.Abstractions;

internal abstract class Report
{
	protected static string Indent => "    ";

	public async Task<string> ToHtmlAsync()
	{
		string title = GetTitle();
		string organization = "Bowmansville Mennonite Church";
		var css = EnumerateLines(GetStyle());
		var body = EnumerateLines(await GetBodyAsync());

		var builder = new StringBuilder();
		builder.AppendLine("<!DOCTYPE html>");
		builder.AppendLine("<html>");
		builder.AppendLine("<head>");

		builder.AppendLine(Indent + "<title>");
		builder.AppendLine(Indent + Indent + title);
		builder.AppendLine(Indent + "</title>");

		builder.AppendLine(Indent + "<style>");
		foreach (string line in css) builder.AppendLine(Indent + Indent + line);
		builder.AppendLine(Indent + "</style>");

		builder.AppendLine("</head>");
		builder.AppendLine("<body>");

		builder.AppendLine(Indent + "<div class=\"header\"></div>");
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

	public static IEnumerable<string> EnumerateLines(string content)
	{
		using var reader = new StringReader(content);
		string? line;

		while ((line = reader.ReadLine()) is not null)
		{
			yield return line;
		}
	}

	protected abstract string GetTitle();
	protected abstract string GetStyle();
	protected abstract Task<string> GetBodyAsync();
}
