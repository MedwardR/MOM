using MOM.Models.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOM.Models
{
	public class Individual : AuditableEntity
	{
		public int Id { get; set; }
		public int HouseholdId { get; set; }

		[Required] public required string FirstName { get; set; }
		public string? MiddleName { get; set; }
		[Required] public required string LastName { get; set; }

		public string? Phone { get; set; }
		public string? Email { get; set; }
		public string? CommunicationPreference { get; set; }

		public string? Gender { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? Occupation { get; set; }
		public string? Employer { get; set; }

		public string? JoinedMethod { get; set; }
		public DateTime? JoinedDate { get; set; }
		public DateTime? BaptizedDate { get; set; }
		public string? BaptizedLocation { get; set; }
		public string? MaritalStatus { get; set; }
		public DateTime? MarriedDate { get; set; }

		[ForeignKey(nameof(HouseholdId))] public virtual required Household Household { get; set; }
		public Address Address { get; set; }

		public Individual()
		{
			Address = new();
		}
	}
}
