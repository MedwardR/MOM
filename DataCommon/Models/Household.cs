using DataCommon.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DataCommon.Models
{
	public class Household : AuditableEntity, ICloneable<Household>
	{
		public long Id { get; init; }

		[Required] public required string Name { get; set; }

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

		public Individual GetNewMember() => new()
		{
			FirstName = "(New Individual)",
			LastName = GetDefaultLastName(),
			Household = this,
		};

		private string GetDefaultLastName()
		{
			var mostCommon = Individuals
				.Where(m => !string.IsNullOrWhiteSpace(m.LastName))
				.GroupBy(m => m.LastName.Trim(), StringComparer.OrdinalIgnoreCase)
				.OrderByDescending(g => g.Count())
				.FirstOrDefault()?.Key;
			return mostCommon ?? Name.Split(' ').LastOrDefault() ?? string.Empty;
		}
	}
}
