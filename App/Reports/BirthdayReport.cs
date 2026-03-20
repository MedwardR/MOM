using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using System.Globalization;
using System.Text;

namespace MOM.Reports;

internal class BirthdayReport(AppContext context, int startMonth, int endMonth) : Report
{
    protected override string GetTitle() => "Birthday Report";

    protected override string GetStyle() => @"
		:root {
			font-family: Calibri, sans-serif;
		}
		html, body {
			margin: 0;
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
		.month-content {
			display: grid;
			grid-template-columns: 35% 25% 20% 20%;
			column-gap: 1rem;
			row-gap: 0.4rem;
			margin-bottom: 1rem;
		}
		.header-row {
			display: contents;
			align-items: start;
			font-weight: bold;
		}
		.row {
			display: contents;
			align-items: start;
		}
		.row > :first-child {
			padding-left: 2rem;
		}
		.dim {
			opacity: 0.2;
		}
	";

    protected override async Task<string> GetBodyAsync()
    {
		var individuals = await context.Individuals.ToListAsync();
		var groups = individuals
			.GroupBy(member => member.BirthDate.GetValueOrDefault().Month)
			.OrderBy(month => month);

		var builder = new StringBuilder();
		int min = Math.Clamp(startMonth, 1, 12);
		int max = Math.Clamp(endMonth, 1, 12);

		foreach (var g in groups)
		{
			if (g.Key >= min && g.Key <= max)
			{
				string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key);

				builder.AppendLine("<div class=\"month-content\">");
				builder.AppendLine(Indent + "<div class=\"header-row\">");
				builder.AppendLine(Indent + Indent + $"<div>{month}</div>");
				builder.AppendLine(Indent + Indent + "<div>Day</div>");
				builder.AppendLine(Indent + Indent + "<div>Year</div>");
				builder.AppendLine(Indent + Indent + "<div>Age</div>");
				builder.AppendLine(Indent + "</div>");

				var ordered = g.OrderBy(member => member.BirthDate.GetValueOrDefault().Day);
				foreach (var member in ordered)
				{
					string name = member.GetDisplayName(true);
					string day = member.BirthDate.GetValueOrDefault().ToString("MMMM d");
					int year = member.BirthDate.GetValueOrDefault().Year;
					int age = DateTime.Today.Year - year;

					builder.AppendLine(Indent + "<div class=\"row\">");
					builder.AppendLine(Indent + Indent + $"<div>{name}</div>");
					builder.AppendLine(Indent + Indent + $"<div>{day}</div>");
					builder.AppendLine(Indent + Indent + $"<div>{year}</div>");
					builder.AppendLine(Indent + Indent + $"<div>{age}</div>");
					builder.AppendLine(Indent + "</div>");
				}
			}
		}
		return builder.ToString();
    }
}
