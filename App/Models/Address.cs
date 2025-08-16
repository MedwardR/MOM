namespace MOM.Models
{
	public class Address
	{
		public Address()
		{
			State = "PA";
			Country = "USA";
		}

		public string? Street { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zip { get; set; }
		public string? Country { get; set; }
	}
}
