using DataCommon.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DataCommon.Models;

public class Household : AuditableEntity, ICloneable<Household>
{
	public long Id { get; init; }

	[Required] public required string Name { get; set; }

	public bool IncludeInDirectory { get; set; }

	public Address Address { get; init; } = new();
	public virtual List<Individual> Individuals { get; init; } = [];

	public Household Clone()
	{
		return new()
		{
			Name = Name,
			Address = Address.Clone(),
			Individuals = [.. Individuals.Select(m => m.Clone())],
		};
	}

	public bool HasActiveMember() => Individuals.Any(member => member.IsMember && member.Active);

	public DateTime? GetMarriedDateOrDefault()
	{
		var couple = Individuals
			.Where(member => member.MarriedDate.HasValue)
			.GroupBy(member => member.MarriedDate!.Value.Date)
			.FirstOrDefault();
		if (couple is not null && couple.Count() == 2)
		{
			return couple.Key;
		}
		else return null;
	}

	public Individual GetNewMember() => new()
	{
		FirstName = "(New Individual)",
		LastName = GetDefaultLastName() ?? string.Empty,
		Household = this,
	};

	private string? GetDefaultLastName()
	{
		var mostCommon = Individuals
			.Where(m => !string.IsNullOrWhiteSpace(m.LastName))
			.GroupBy(m => m.LastName.Trim(), StringComparer.OrdinalIgnoreCase)
			.OrderByDescending(g => g.Count())
			.FirstOrDefault();
		return mostCommon is not null ? mostCommon.Key : Name.Split(' ').LastOrDefault();
	}
}
