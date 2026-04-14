using DataCommon.Models.Abstractions;
using System.Text;

namespace DataCommon.Models;

public class Address : ICloneable<Address>
{
	public string? Street { get; set; }
	public string? Apartment { get; set; }
	public string? City { get; set; }
	public string? State { get; set; } = "PA";
	public string? Zip { get; set; }
	public string? Country { get; set; } = "USA";

	public Address Clone()
	{
		return new()
		{
			Street = Street,
			Apartment = Apartment,
			City = City,
			State = State,
			Zip = Zip,
			Country = Country,
		};
	}

	public override string ToString()
	{
		var tokens = new List<string>();

		if (!string.IsNullOrWhiteSpace(Street))
		{
			tokens.Add(Street);
		}
		if (!string.IsNullOrWhiteSpace(Apartment))
		{
			tokens.Add(Apartment);
		}
		if (!string.IsNullOrWhiteSpace(City))
		{
			tokens.Add(City);
		}
		var stateZipTokens = new List<string>();

		if (!string.IsNullOrWhiteSpace(State))
		{
			stateZipTokens.Add(State);
		}
		if (!string.IsNullOrWhiteSpace(Zip))
		{
			stateZipTokens.Add(Zip);
		}
		string stateZip = string.Join(' ', stateZipTokens);
		tokens.Add(stateZip);

		if (!string.IsNullOrWhiteSpace(Country))
		{
			if (!string.Equals(Country, "USA", StringComparison.OrdinalIgnoreCase))
			{
				tokens.Add(Country);
			}
		}
		var trimmed = tokens.Select(value => value.Trim());
		return string.Join(", ", trimmed);
	}
}
