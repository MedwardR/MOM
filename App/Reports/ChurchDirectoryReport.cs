using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;
using MOM.Helpers;
using MOM.Utilities;

namespace MOM.Reports;

internal class ChurchDirectoryReport(AppContext context) : Report
{
	private const char SEPARATOR = '⋅';

	protected override string GetTitle() => "Church Directory";

	protected override string GetPageMargin() => "0.5in";

	protected override async Task<string> GetBodyAsync()
	{
		var households = await context.Households
			.Include(household => household.Individuals)
			.Where(household => household.IncludeInDirectory && household.Active)
			.ToListAsync();

		var builder = new CodeBuilder();
		builder.AppendLine(0, "<div class=\"content\">");
		builder.AppendLine();

		foreach (var h in households)
		{
			builder.AppendLine(1, $"<!-- {h.Name} -->");
			builder.AppendLine(1, "<div class=\"content-card\">");
			builder.AppendLine(2, $"<div class=\"household-header\">{h.Name}</div>");
			builder.AppendLine(2, "<div>");
			builder.AppendLine(3, $"<div>{h.Address}</div>");

			string[] phones = [.. h.Individuals
				.Where(member => !string.IsNullOrWhiteSpace(member.HomePhone))
				.Select(member => member.HomePhone!)
				.Distinct(FormatHelper.PhoneComparer)];
			string[] emails = [.. h.Individuals
				.Where(member => !string.IsNullOrWhiteSpace(member.Email))
				.Select(member => member.Email!)
				.Distinct(StringComparer.OrdinalIgnoreCase)];
			var contactTags = new List<string>();

			string? householdPhone = phones.Length == 1 ? phones[0] : null;
			string? householdEmail = emails.Length == 1 ? emails[0] : null;

			if (!string.IsNullOrWhiteSpace(householdPhone))
			{
				string tag = GetPhoneHyperlink(householdPhone);
				contactTags.Add(tag);
			}
			if (!string.IsNullOrWhiteSpace(householdEmail))
			{
				string tag = GetEmailHyperlink(householdEmail);
				contactTags.Add(tag);
			}
			if (contactTags.Count > 0)
			{
				builder.AppendLine(3, "<div class=\"household-contact\">");
				bool first = true;

				foreach (string tag in contactTags)
				{
					if (first)
					{
						first = false;
					}
					else builder.AppendLine(4, $"<div>{SEPARATOR}</div>");

					builder.AppendLine(4, tag);
				}
				builder.AppendLine(3, "</div>");
			}
			var adults = h.Individuals
				.Where(member => member.Active)
				.Where(member => !member.Child)
				.ToArray();

			if (adults.Length > 0)
			{
				builder.AppendLine(3, "<div class=\"household-individuals\">");

				foreach (var adult in adults)
				{
					string name = adult.GetDisplayName(false);

					builder.AppendLine(4, "<div class=\"individual-column\">");
					builder.AppendLine(5, "<div class=\"individual-header\">");
					builder.AppendLine(6, $"<div class=\"individual-name\">{name}</div>");
					
					if (adult.BirthDate.HasValue)
					{
						builder.AppendLine(6, $"<div>{SEPARATOR}</div>");
						builder.AppendLine(6, $"<div>{adult.BirthDate.Value:M/d/yyyy}</div>");
					}
					builder.AppendLine(5, "</div>");

					if (!string.IsNullOrWhiteSpace(adult.HomePhone))
					{
						if (!FormatHelper.PhoneComparer.Equals(adult.HomePhone, householdPhone))
						{
							string tag = GetPhoneHyperlink(adult.HomePhone);
							builder.AppendLine(5, tag);
						}
					}
					if (!string.IsNullOrWhiteSpace(adult.MobilePhone))
					{
						if (!FormatHelper.PhoneComparer.Equals(adult.MobilePhone, householdPhone))
						{
							string tag = GetPhoneHyperlink(adult.MobilePhone);
							builder.AppendLine(5, tag);
						}
					}
					if (!string.IsNullOrWhiteSpace(adult.Email))
					{
						if (!string.Equals(adult.Email, householdEmail))
						{
							string tag = GetEmailHyperlink(adult.Email);
							builder.AppendLine(5, tag);
						}
					}
					builder.AppendLine(4, "</div>");
				}
				builder.AppendLine(3, "</div>");
			}
			builder.AppendLine(2, "</div>");

			var anniversary = adults
				.Where(member => member.MarriedDate.HasValue)
				.Select(member => member.MarriedDate)
				.Distinct()
				.OrderByDescending(value => value!.Value)
				.FirstOrDefault();
			var children = h.Individuals
				.Where(member => member.Active)
				.Where(member => member.Child)
				.ToArray();

			if (anniversary is not null || children.Length > 0)
			{
				builder.AppendLine(2, "<div>");

				if (anniversary is not null)
				{
					builder.AppendLine(3, $"<div>Anniversary: {anniversary.Value:M/d/yyyy}</div>");
				}
				if (children.Length > 0)
				{
					builder.AppendLine(3, "<div class=\"household-children\">");

					foreach (var child in children)
					{
						string name = child.GetDisplayName(false);

						builder.AppendLine(4, "<div class=\"individual-row\">");
						builder.AppendLine(4, $"<div class=\"individual-name\">{name}</div>");

						if (child.BirthDate.HasValue)
						{
							builder.AppendLine(6, $"<div>{SEPARATOR}</div>");
							builder.AppendLine(6, $"<div>{child.BirthDate.Value:M/d/yyyy}</div>");
						}
						builder.AppendLine(4, "</div>");
					}
					builder.AppendLine(3, "</div>");
				}
				builder.AppendLine(2, "</div>");
			}
			builder.AppendLine(1, "</div>");
			builder.AppendLine();
		}
		builder.AppendLine(0, "</div>");

		return builder.ToString();
	}

	private static string GetPhoneHyperlink(string phone)
	{
		string tel = FormatHelper.FormatPhone(phone, "0000000000");
		string display = FormatHelper.FormatPhone(phone, "000-000-0000");
		return $"<a href=\"tel:{tel}\">{display}</a>";
	}

	private static string GetEmailHyperlink(string email)
	{
		string trimmed = email.Trim();
		return $"<a href=\"mailto:{trimmed}\">{trimmed}</a>";
	}

	protected override string GetStyle()
	{
		var builder = new CodeBuilder();

		builder.AppendLine(0, ".content {");
		builder.AppendLine(1, "display: grid;");
		builder.AppendLine(1, "grid-template-columns: 1fr 1fr;");
		builder.AppendLine(1, "font-size: 0.8rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".content-card {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: column;");
		builder.AppendLine(1, "row-gap: 0.5rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".household-header {");
		builder.AppendLine(1, "font-weight: bold;");
		builder.AppendLine(1, "font-size: 1rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".household-contact {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "column-gap: 0.3rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".household-individuals {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "gap: 0.5rem 1rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-column {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: column;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-header {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "column-gap: 0.3rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-name {");
		builder.AppendLine(1, "text-decoration: underline;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".household-children {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "column-gap: 1rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-row {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "column-gap: 0.3rem;");
		builder.AppendLine(0, "}");
		builder.AppendLine(0, ".content {");
		builder.AppendLine(1, "display: grid;");
		builder.AppendLine(1, "grid-template-columns: 1fr 1fr;");
		builder.AppendLine(1, "font-size: 0.8rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".content-card {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: column;");
		builder.AppendLine(1, "row-gap: 0.5rem;");
		builder.AppendLine(0, "}");

		builder.AppendLine(0, ".household-header {");
		builder.AppendLine(1, "font-weight: bold;");
		builder.AppendLine(1, "font-size: 1rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".household-contact {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "column-gap: 0.3rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".household-individuals {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "gap: 0.5rem 1rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-column {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: column;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-header {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "column-gap: 0.3rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-name {");
		builder.AppendLine(1, "text-decoration: underline;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".household-children {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "flex-wrap: wrap;");
		builder.AppendLine(1, "column-gap: 1rem;");
		builder.AppendLine(0, "}");
		
		builder.AppendLine(0, ".individual-row {");
		builder.AppendLine(1, "display: flex;");
		builder.AppendLine(1, "flex-direction: row;");
		builder.AppendLine(1, "column-gap: 0.3rem;");
		builder.AppendLine(0, "}");

		return builder.ToString();
	}
}
