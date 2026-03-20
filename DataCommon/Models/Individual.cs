using DataCommon.Helpers;
using DataCommon.Models.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataCommon.Models
{
	public class Individual : AuditableEntity, ICloneable<Individual>, IEquatable<Individual>
	{
		public long Id { get; init; }
		public long HouseholdId { get; set; }

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

		public bool Child { get; set; }

		[ForeignKey(nameof(HouseholdId))] public virtual required Household Household { get; set; }

		public Individual Clone()
		{
			return new()
			{
				Id = Id,
				HouseholdId = HouseholdId,
				FirstName = FirstName,
				MiddleName = MiddleName,
				LastName = LastName,
				PreferredName = PreferredName,
				MobilePhone = MobilePhone,
				HomePhone = HomePhone,
				Email = Email,
				CommunicationPreference = CommunicationPreference,
				Gender = Gender,
				BirthDate = BirthDate,
				Occupation = Occupation,
				Employer = Employer,
				JoinedDate = JoinedDate,
				JoinedMethod = JoinedMethod,
				BaptizedDate = BaptizedDate,
				BaptizedLocation = BaptizedLocation,
				MarriedDate = MarriedDate,
				MaritalStatus = MaritalStatus,
				Child = Child,
				Household = Household,
			};
		}

		public string GetDisplayName(bool includeLastName)
		{
			var parts = new List<string>();
			
			if (!string.IsNullOrWhiteSpace(PreferredName))
			{
				parts.Add(PreferredName);
			}
			else parts.Add(FirstName);

			if (includeLastName && !string.IsNullOrWhiteSpace(LastName))
			{
				parts.Add(LastName);
			}
			return string.Join(" ", parts);
		}

		public bool Equals(Individual? other)
		{
			if (other is not null)
			{
				var strings = new (string?, string?)[]
				{
					(FirstName, other.FirstName),
					(MiddleName, other.MiddleName),
					(LastName, other.LastName),
					(PreferredName, other.PreferredName),
					(Email, other.Email),
					(CommunicationPreference, other.CommunicationPreference),
					(Gender, other.Gender),
					(Occupation, other.Occupation),
					(Employer, other.Employer),
					(JoinedMethod, other.JoinedMethod),
					(BaptizedLocation, other.BaptizedLocation),
					(MaritalStatus, other.MaritalStatus),
				};
				bool stringsEqual = strings.All(pair =>
				{
					string? a = pair.Item1?.Trim() ?? string.Empty;
					string? b = pair.Item2?.Trim() ?? string.Empty;
					return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
				});
				return Id == other.Id
					&& HouseholdId == other.HouseholdId
					&& stringsEqual
					&& PhoneHelper.Equals(MobilePhone, other.MobilePhone)
					&& PhoneHelper.Equals(HomePhone, other.HomePhone)
					&& BirthDate == other.BirthDate
					&& JoinedDate == other.JoinedDate
					&& BaptizedDate == other.BaptizedDate
					&& MarriedDate == other.MarriedDate
					&& Child == other.Child
					&& Active == other.Active;
			}
			else return false;
		}

		public override bool Equals(object? obj) => Equals(obj as Individual);

		public override int GetHashCode() => Id.GetHashCode();
	}
}
