using DataCommon.Models.Abstractions;

namespace DataCommon.Models
{
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
	}
}
