using DataCommon.Models;
using MigrationTool.MOM;

namespace MigrationTool.SK;

internal class SKImporter
{
	public static void Import(MOMContext mom, SKContext sk)
	{
		foreach (var family in sk.Families)
		{
			var household = new Household()
			{
				Id = long.Parse(family.FAMILY_ID),
				Name = family.FAM_NAME ?? "NO NAME",
				Address = new Address()
				{
					Street = family.GetCombinedStreetAddress(),
					City = family.CITY,
					State = family.STATE,
					Zip = family.ZIP,
					Country = family.COUNTRY,
				}
			};
			mom.Households.Add(household);
		}

		foreach (var other in sk.Individuals)
		{
			var individual = new Individual()
			{
				Household = GetHouseholdFromId(mom, other.FAMILY_ID),
				FirstName = other.FIRST_NAME ?? "Unnamed",
				MiddleName = other.MID_NAME,
				LastName = other.LAST_NAME ?? string.Empty,
				MobilePhone = other.C_PHONE,
				HomePhone = other.H_PHONE,
				Email = other.EMAIL1 ?? other.EMAIL2 ?? other.EMAIL3,
				CommunicationPreference = GetValueFromReferenceId(sk, other.UDF11),
				Gender = other.SEX switch
				{
					"M" => "Male",
					"F" => "Female",
					_ => other.SEX
				},
				BirthDate = ParseTimestamp(other.BIRTH_DT),
				Occupation = GetValueFromReferenceId(sk, other.JOB_CD),
				Employer = other.EMPLOYER,
				JoinedDate = ParseTimestamp(other.JOIN_DT),
				JoinedMethod = GetValueFromReferenceId(sk, other.HOW_JOIN),
				BaptizedDate = ParseTimestamp(other.BAPTIZE_DT),
				BaptizedLocation = GetValueFromReferenceId(sk, other.UDF9),
				MarriedDate = ParseTimestamp(other.WEDDING_DT),
				MaritalStatus = GetValueFromReferenceId(sk, other.MARITAL_CD),
			};
			mom.Individuals.Add(individual);
		}
	}

	private static Household GetHouseholdFromId(MOMContext mom, string id)
	{
		var parsed = long.Parse(id);
		return mom.Households.Single(h => h.Id == parsed);
	}

	private static string? GetValueFromReferenceId(SKContext sk, string? id)
	{
		if (!string.IsNullOrWhiteSpace(id))
		{
			var reference = sk.References.SingleOrDefault(r => r.TBL_ID == id);
			return reference?.DESCS;
		}
		else return null;
	}
	
	private static DateTime? ParseTimestamp(string? timestamp)
	{
		if (!string.IsNullOrWhiteSpace(timestamp))
		{
			throw new NotImplementedException();
		}
		else return null;
	}
}
