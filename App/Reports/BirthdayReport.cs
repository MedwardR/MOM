using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using MOM.Utilities;
using System.Globalization;

namespace MOM.Reports;

internal class BirthdayReport(AppContext context, int startMonth, int endMonth) : Report
{
	private Func<Individual, object>? _keySelector = null;
	private bool _descending = false;

	protected override string GetTitle() => "Birthday Report";

	protected override string GetPageMargin() => "1in";

	protected override async Task<string> GetBodyAsync()
	{
		var individuals = await context.Individuals
			.Include(member => member.Household)
			.Where(member => member.Household.IncludeInDirectory && member.Active)
			.ToListAsync();
		var groups = individuals
			.Where(member => member.BirthDate.HasValue)
			.GroupBy(member => member.BirthDate!.Value.Month)
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
				builder.AppendLine(2, "<div>Age</div>");
				builder.AppendLine(1, "</div>");

				IOrderedEnumerable<Individual> ordered;
				if (_keySelector is not null)
				{
					if (_descending)
					{
						ordered = g.OrderByDescending(_keySelector);
					}
					else ordered = g.OrderBy(_keySelector);
				}
				else ordered = g.OrderBy(member => member.BirthDate.GetValueOrDefault().Day);

				foreach (var member in ordered)
				{
					string name = member.GetDisplayName(true);
					string day = member.BirthDate.GetValueOrDefault().ToString("MMMM d");
					int year = member.BirthDate.GetValueOrDefault().Year;
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
		builder.AppendLine(1, "grid-template-columns: 37% 28% 22% 13%;");
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

	public void OrderBy<T>(Func<Individual, T> keySelector) where T : notnull
	{
		_keySelector = member => keySelector(member);
		_descending = false;
	}

	public void OrderByDescending<T>(Func<Individual, T> keySelector) where T : notnull
	{
		_keySelector = member => keySelector(member);
		_descending = true;
	}
}
