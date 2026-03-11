using DataCommon.Models;
using MigrationTool.SK.Models;

namespace MigrationTool.SK;

internal static class AddressHelper
{
	public static Address GetAddress(Family family)
	{
		string? street;
		string? apartment;

		if (!string.IsNullOrWhiteSpace(family.ADDR1))
		{
			var homes = new HashSet<string>(["Garden Spot Village", "Sunny Crest Home"], StringComparer.OrdinalIgnoreCase);

			string[] parts = family.ADDR1.Split(['|', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			string first = parts.FirstOrDefault() ?? string.Empty;
			string second = parts.Skip(1).FirstOrDefault() ?? string.Empty;
			string third = parts.Skip(2).FirstOrDefault() ?? string.Empty;

			if (parts.Length <= 2)
			{
				if (IsAuxiliary(first))
				{
					street = second;
					apartment = first;
				}
				else if (IsAuxiliary(second))
				{
					street = first;
					apartment = second;
				}
				else
				{
					street = family.ADDR1;
					apartment = family.ADDR2;
				}
			}
			else if (homes.Contains(first))
			{
				street = second;
				apartment = $"{third}, {first}";
			}
			else if (homes.Contains(third))
			{
				street = first;
				apartment = $"{second}, {third}";
			}
			else
			{
				street = family.ADDR1;
				apartment = family.ADDR2;
			}
		}
		else
		{
			street = family.ADDR1;
			apartment = family.ADDR2;
		}
		return new Address()
		{
			Street = street,
			Apartment = apartment,
			City = family.CITY,
			State = family.STATE,
			Zip = family.ZIP,
			Country = family.COUNTRY,
		};
	}

	private static bool IsAuxiliary(string addr)
	{
		char? first = addr.FirstOrDefault();

		if (first is not null && char.IsNumber(first.Value))
		{
			return false;
		}
		else return true;
	}
}
