using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
	public class Household
	{
		public int Id { get; set; }

		[Required] public required string Name { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }

		public virtual List<Individual> Individuals { get; set; } = [];
		public Address Address { get; set; }

		public Household()
		{
			Address = new();
		}
	}
}
