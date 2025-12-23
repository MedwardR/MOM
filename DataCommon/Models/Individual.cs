using DataCommon.Models.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCommon.Models
{
	public class Individual : AuditableEntity
	{
		public long Id { get; init; }
		public long HouseholdId { get; init; }

		[Required] public required string FirstName { get; set; }
		public string? MiddleName { get; set; }
		[Required] public required string LastName { get; set; }
		
		public string? PreferredName { get; set; }

		public string? MobilePhone { get; set; }
		public string? HomePhone { get; set; }
		public string? Email { get; set; }
		public string? CommunicationPreference { get; set; }

		public string? Gender { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? Occupation { get; set; }
		public string? Employer { get; set; }

		public DateTime? JoinedDate { get; set; }
		public string? JoinedMethod { get; set; }
		public DateTime? BaptizedDate { get; set; }
		public string? BaptizedLocation { get; set; }
		public DateTime? MarriedDate { get; set; }
		public string? MaritalStatus { get; set; }

		[ForeignKey(nameof(HouseholdId))] public virtual required Household Household { get; set; }

		public string GetDisplayName()
		{
			if (!string.IsNullOrWhiteSpace(PreferredName))
			{
				return PreferredName;
			}
			else return FirstName;
		}
	}
}
