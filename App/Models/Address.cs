namespace MOM.Models
{
	public class Address
	{
		public string? Street { get; set; }
		public string? City { get; set; }
		public string? State { get; set; } = "PA";
		public string? Zip { get; set; }
		public string? Country { get; set; } = "USA";
	}
}
