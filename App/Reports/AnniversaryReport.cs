using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using System.Globalization;
using System.Text;

namespace MOM.Reports;

internal class AnniversaryReport(AppContext context, int startMonth, int endMonth) : Report
{
	private Func<Household, object>? _keySelector = null;
	private bool _descending = false;

	protected override string GetTitle() => "Anniversary Report";

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
				builder.AppendLine(Indent + Indent + "<div>Years married</div>");
				builder.AppendLine(Indent + "</div>");

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
			grid-template-columns: 40% 23% 17% 20%;
			row-gap: 0.4rem;
			margin-bottom: 1rem;
			break-inside: avoid;
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
