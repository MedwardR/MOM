using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
	public class Household
	{
		public int Id { get; set; }

		[Required]
		public required string Name { get; set; }
		
		public string? Street { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zip { get; set; }
		public string? Country { get; set; }
		public string? Phone { get; set; }
		public string? Email { get; set; }
	}
}
