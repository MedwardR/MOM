using DataCommon.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DataCommon.Models
{
	public class Household : AuditableEntity
	{
		public long Id { get; set; }

		[Required] public required string Name { get; set; }

		public virtual List<Individual> Individuals { get; set; } = [];
		public Address Address { get; set; }

		public Household()
		{
			Address = new();
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
