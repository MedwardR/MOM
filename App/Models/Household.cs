using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
	public class Household
	{
		public int Id { get; set; }

		[Required] public required string Name { get; set; }
		public int? AddressId { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }

		public List<Individual> Individuals { get; set; } = [];
		public Address? Address { get; set; }
	}
}
