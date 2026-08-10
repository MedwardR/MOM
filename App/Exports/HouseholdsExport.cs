using System.Text;
using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Abstractions;

namespace MOM.Exports;

internal class HouseholdsExport(AppContext context, string path) : IExport
{
	public async Task ExportAsync()
	{
		await using var writer = new StreamWriter(path, false, Encoding.UTF8);

		var columns = new string[]
		{
			nameof(Household.Id),
			nameof(Household.Name),
			nameof(Address.Street),
			nameof(Address.Apartment),
			nameof(Address.City),
			nameof(Address.State),
			nameof(Address.Zip),
			nameof(Address.Country),
		};
		string header = string.Join(',', columns);

		await writer.WriteLineAsync(header);

		var households = await context.Households
			.Include(household => household.Individuals)
			.Where(household => household.Active)
			.OrderBy(household => household.Name)
			.ToListAsync();

		foreach (var h in households)
		{
			if (h.HasActiveMember())
			{
				var values = new string[]
				{
					h.Id.ToString(),
					Escape(h.Name),
					Escape(h.Address.Street),
					Escape(h.Address.Apartment),
					Escape(h.Address.City),
					Escape(h.Address.State),
					Escape(h.Address.Zip),
					Escape(h.Address.Country),
				};
				string line = string.Join(',', values);

				await writer.WriteLineAsync(line);
			}
		}
	}

	private static string Escape(string? value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			bool needsQuotes =
				value.Contains(',') ||
				value.Contains('"') ||
				value.Contains('\n') ||
				value.Contains('\r');

			string escapedValue = value.Replace("\"", "\"\"");

			return needsQuotes ? $"\"{escapedValue}\"" : escapedValue;
		}
		else return "";
	}
}
