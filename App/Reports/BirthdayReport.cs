using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using System.Globalization;
using System.Text;

namespace MOM.Reports;

internal class BirthdayReport(AppContext context, int startMonth, int endMonth) : Report
{
	private Func<Individual, object>? _keySelector = null;
	private bool _descending = false;

	protected override string GetTitle() => "Birthday Report";

	protected override async Task<string> GetBodyAsync()
	{
		var individuals = await context.Individuals.ToListAsync();
		var groups = individuals
			.Where(member => member.BirthDate.HasValue)
			.GroupBy(member => member.BirthDate!.Value.Month)
			.OrderBy(g => g.Key);

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

					builder.AppendLine(Indent + "<div class=\"row\">");
					builder.AppendLine(Indent + Indent + $"<div>{name}</div>");
					builder.AppendLine(Indent + Indent + $"<div>{day}</div>");
					builder.AppendLine(Indent + Indent + $"<div>{year}</div>");
					builder.AppendLine(Indent + Indent + $"<div>{age}</div>");
					builder.AppendLine(Indent + "</div>");
				}
				builder.AppendLine("</div>");
			}
		}
		return builder.ToString();
	}

	protected override string GetStyle() => @"
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
			padding-left: 1rem;
		}
		.dim {
			opacity: 0.2;
		}
	";

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
