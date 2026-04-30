using DataCommon.Enums;
using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using MOM.Utilities;

namespace MOM.Reports;

internal class MembersByAgeReport(AppContext context, DateTime minimum, DateTime maximum) : Report
{
	private const char SEPARATOR = '⋅';

	private Func<Individual, object>? _keySelector = null;
	private bool _descending = false;

	protected override string GetTitle() => "Members by Age Report";

	protected override string GetPageMargin() => "1in";

	protected override IEnumerable<string> GetHeaders()
	{
		var defaults = base.GetHeaders();
		foreach (string value in defaults) yield return value;
		yield return $"Members born {minimum:d} - {maximum:d}";
	}

	protected override async Task<string> GetBodyAsync()
	{
		var builder = new CodeBuilder();

		var individuals = await context.Individuals
			.Include(member => member.Household)
			.Where(member => member.Household.IncludeInDirectory && member.Active)
			.ToListAsync();

		var names = individuals.ToDictionary(member => member, member =>
		{
			return member.GetDisplayName(NameOptions.IncludeLastName | NameOptions.LastNameFirst);
		});
		var keySelector = _keySelector ?? (member => names[member]);

		IOrderedEnumerable<Individual> ordered;
		
		if (_descending)
		{
			ordered = individuals.OrderByDescending(keySelector);
		}
		else ordered = individuals.OrderBy(keySelector);

		builder.AppendLine(0, "<div class=\"content\">");

		foreach (var member in ordered)
		{
			if (member.BirthDate.HasValue && member.BirthDate.Value >= minimum && member.BirthDate.Value <= maximum)
			{
				string name = names[member];
				int? age = member.Age();

				builder.AppendLine(1, "<div class=\"individual\">");
				builder.AppendLine(2, $"<div>{name}</div>");
				builder.AppendLine(2, $"<div>{SEPARATOR}</div>");
				builder.AppendLine(2, $"<div>{age}</div>");
				builder.AppendLine(1, "</div>");
			}
		}
		builder.AppendLine(0, "</div>");

		return builder.ToString();
	}

	protected override string GetStyle()
	{
		var builder = new CodeBuilder();

		builder.AppendLine(0, ".content {");
		builder.AppendLine(1, "column-count: 3;");
		builder.AppendLine(1, "column-gap: 1rem;");
		builder.AppendLine(0, "}");

		builder.AppendLine(0, ".individual {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "column-gap: 0.5rem;");
		builder.AppendLine(0, "}");

		return builder.ToString();
	}

	public void OrderByName()
	{
		_keySelector = null;
		_descending = false;
	}

	public void OrderByNameDescending()
	{
		_keySelector = null;
		_descending = false;
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
