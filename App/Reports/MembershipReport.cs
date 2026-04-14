using DataCommon.Enums;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using MOM.Utilities;

namespace MOM.Reports;

internal class MembershipReport(AppContext context) : Report
{
	protected override string GetTitle() => "Membership Report";

	protected override string GetPageMargin() => "1in";

	protected override async Task<string> GetBodyAsync()
	{
		var builder = new CodeBuilder();

		var individuals = await context.Individuals
			.Include(member => member.Household)
			.Where(member => member.Household.IncludeInDirectory && member.Active)
			.ToListAsync();
		var ordered = individuals
			.OrderBy(member => member.GetDisplayName(NameOptions.IncludeLastName | NameOptions.LastNameFirst));

		builder.AppendLine(0, "<div class=\"content\">");

		foreach (var member in ordered)
		{
			string name = member.GetDisplayName(NameOptions.IncludeLastName | NameOptions.LastNameFirst);
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
}
