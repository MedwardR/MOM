using DataCommon.Enums;
using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using MOM.Utilities;
using System.Linq;

namespace MOM.Reports;

internal class MembershipReport(AppContext context) : Report
{
	private List<Func<Individual, bool>> _criteria = [];
	private Func<Individual, object>? _keySelector = null;
	private bool _descending = false;

	protected override string GetTitle() => "Membership Report";

	protected override string GetPageMargin() => "1in";

	protected override async Task<string> GetBodyAsync()
	{
		var builder = new CodeBuilder();

		var individuals = await context.Individuals
			.Include(member => member.Household)
			.Where(member => member.Household.IncludeInDirectory && member.Active)
			.ToListAsync();
		ICollection<Individual> filtered;

		if (_criteria.Count > 0)
		{
			filtered = [.. individuals.Where(member => {
				return _criteria.All(predicate => predicate(member));
			})];
		}
		else filtered = individuals;

		var names = filtered.ToDictionary(member => member, member =>
		{
			return member.GetDisplayName(NameOptions.IncludeLastName | NameOptions.LastNameFirst);
		});
		IOrderedEnumerable<Individual> ordered;
		var keySelector = _keySelector ?? (member => names[member]);

		if (_descending)
		{
			ordered = filtered.OrderByDescending(keySelector);
		}
		else ordered = filtered.OrderBy(keySelector);

		builder.AppendLine(0, "<div class=\"content\">");

		foreach (var member in ordered)
		{
			string name = names[member];
			builder.AppendLine(3, $"<div>{name}</div>");
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

		return builder.ToString();
	}

	public void AddFilter(Func<Individual, bool> predicate) => _criteria.Add(predicate);

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
