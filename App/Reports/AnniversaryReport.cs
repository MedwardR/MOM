using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using MOM.Utilities;
using System.Globalization;

namespace MOM.Reports;

internal class AnniversaryReport(AppContext context, int startMonth, int endMonth) : Report
{
	private Func<Household, object>? _keySelector = null;
	private bool _descending = false;

	protected override string GetTitle() => "Anniversary Report";

	protected override string GetPageMargin() => "1in";

	protected override async Task<string> GetBodyAsync()
	{
		var households = await context.Households
			.Include(h => h.Individuals)
			.Where(h => h.IncludeInDirectory)
			.ToListAsync();
		var groups = households
			.Where(h => h.GetMarriedDateOrDefault().HasValue)
			.GroupBy(h => h.GetMarriedDateOrDefault()!.Value.Month)
			.OrderBy(g => g.Key);

		var builder = new CodeBuilder();
		int min = Math.Clamp(startMonth, 1, 12);
		int max = Math.Clamp(endMonth, 1, 12);

		foreach (var g in groups)
		{
			if (g.Key >= min && g.Key <= max)
			{
				string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key);

				builder.AppendLine(0, "<div class=\"month-content\">");
				builder.AppendLine(1, "<div class=\"header-row\">");
				builder.AppendLine(2, $"<div>{month}</div>");
				builder.AppendLine(2, "<div>Day</div>");
				builder.AppendLine(2, "<div>Year</div>");
				builder.AppendLine(2, "<div>Years married</div>");
				builder.AppendLine(1, "</div>");

				IOrderedEnumerable<Household> ordered;
				if (_keySelector is not null)
				{
					if (_descending)
					{
						ordered = g.OrderByDescending(_keySelector);
					}
					else ordered = g.OrderBy(_keySelector);
				}
				else ordered = g.OrderBy(member => member.GetMarriedDateOrDefault().GetValueOrDefault().Day);

				foreach (var member in ordered)
				{
					string name = member.Name;
					string day = member.GetMarriedDateOrDefault().GetValueOrDefault().ToString("MMMM d");
					int year = member.GetMarriedDateOrDefault().GetValueOrDefault().Year;
					int age = DateTime.Today.Year - year;

					builder.AppendLine(1, "<div class=\"row\">");
					builder.AppendLine(2, $"<div>{name}</div>");
					builder.AppendLine(2, $"<div>{day}</div>");
					builder.AppendLine(2, $"<div>{year}</div>");
					builder.AppendLine(2, $"<div>{age}</div>");
					builder.AppendLine(1, "</div>");
				}
				builder.AppendLine(0, "</div>");
			}
		}
		return builder.ToString();
	}

	protected override string GetStyle()
	{
		var builder = new CodeBuilder();

		builder.AppendLine(0, ".month-content {");
		builder.AppendLine(1, "display: grid;");
		builder.AppendLine(1, "grid-template-columns: 40% 23% 17% 20%;");
		builder.AppendLine(1, "row-gap: 0.4rem;");
		builder.AppendLine(1, "margin-bottom: 1rem;");
		builder.AppendLine(1, "break-inside: avoid;");
		builder.AppendLine(0, "}");

		builder.AppendLine(0, ".header-row {");
		builder.AppendLine(1, "display: contents;");
		builder.AppendLine(1, "align-items: start;");
		builder.AppendLine(1, "font-weight: bold;");
		builder.AppendLine(0, "}");

		builder.AppendLine(0, ".row {");
		builder.AppendLine(1, "display: contents;");
		builder.AppendLine(1, "align-items: start;");
		builder.AppendLine(0, "}");

		builder.AppendLine(0, ".row > :first-child {");
		builder.AppendLine(1, "padding-left: 1rem;");
		builder.AppendLine(0, "}");

		builder.AppendLine(0, ".dim {");
		builder.AppendLine(1, "opacity: 0.2;");
		builder.AppendLine(0, "}");

		return builder.ToString();
	}

	public void OrderBy<T>(Func<Household, T> keySelector) where T : notnull
	{
		_keySelector = member => keySelector(member);
		_descending = false;
	}

	public void OrderByDescending<T>(Func<Household, T> keySelector) where T : notnull
	{
		_keySelector = member => keySelector(member);
		_descending = true;
	}
}
