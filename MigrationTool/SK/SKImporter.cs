using DataCommon.Models;
using MigrationTool.MOM;
using MigrationTool.SK.Models;
using System.Globalization;

namespace MigrationTool.SK;

internal class SKImporter
{
	public static void Import(MOMContext mom, SKContext sk)
	{
		var households = new List<Household>();
		var individuals = new List<DataCommon.Models.Individual>();
		var references = sk.References.ToList();
		var map = new Dictionary<long, List<Models.Individual>>();

		foreach (var other in sk.Families.ToList())
		{
			long id = long.Parse(other.FAMILY_ID);
			string name = other.FAM_NAME ?? "NULL";
			var address = AddressHelper.GetAddress(other);

			var item = new Household()
			{
				Id = id,
				Name = name,
				Address = address,
			};
			households.Add(item);
			map.Add(id, []);
		}
		foreach (var other in sk.Individuals.ToList())
		{
			var household = GetHouseholdFromId(households, other.FAMILY_ID);
			string firstName = other.FIRST_NAME ?? "NULL";
			var middleName = other.MID_NAME;
			string lastName = other.LAST_NAME ?? "NULL";
			var preferredName = other.PREFERNAME == other.FIRST_NAME ? null : other.PREFERNAME;
			var mobilePhone = other.C_PHONE;
			var homePhone = other.H_PHONE;
			var email = other.EMAIL1 ?? other.EMAIL2 ?? other.EMAIL3;
			var communicationPreference = GetValueFromReferenceId(references, other.UDF11);
			var gender = other.SEX switch
			{
				"M" => "Male",
				"F" => "Female",
				_ => other.SEX
			};
			var birthDate = ParseTimestamp(other.BIRTH_DT);
			var occupation = GetValueFromReferenceId(references, other.JOB_CD);
			var employer = other.EMPLOYER;
			var joinedDate = ParseTimestamp(other.JOIN_DT);
			var joinedMethod = GetValueFromReferenceId(references, other.HOW_JOIN);
			var baptizedDate = ParseTimestamp(other.BAPTIZE_DT);
			var baptizedLocation = GetValueFromReferenceId(references, other.UDF9);
			var marriedDate = ParseTimestamp(other.WEDDING_DT);
			var maritalStatus = GetValueFromReferenceId(references, other.MARITAL_CD);
			var memberStatus = GetValueFromReferenceId(references, other.MEM_STATUS);
			bool child = IsChild(other);

			var item = new DataCommon.Models.Individual()
			{
				Household = household,
				FirstName = firstName,
				MiddleName = middleName,
				LastName = lastName,
				PreferredName = preferredName,
				MobilePhone = mobilePhone,
				HomePhone = homePhone,
				Email = email,
				CommunicationPreference = communicationPreference,
				Gender = gender,
				BirthDate = birthDate,
				Occupation = occupation,
				Employer = employer,
				JoinedDate = joinedDate,
				JoinedMethod = joinedMethod,
				BaptizedDate = baptizedDate,
				BaptizedLocation = baptizedLocation,
				MarriedDate = marriedDate,
				MaritalStatus = maritalStatus,
				MemberStatus = memberStatus,
				Child = child,
			};
			individuals.Add(item);
			map[household.Id].Add(other);
		}
		foreach (var h in households)
		{
			h.IncludeInDirectory = map[h.Id].Any(m =>
			{
				return int.TryParse(m.INCLD_DIR, out int value) && value == 0;
			});
		}
		mom.Households.AddRange(households);
		mom.Individuals.AddRange(individuals);

		mom.SaveChanges();
	}

	private static Household GetHouseholdFromId(IEnumerable<Household> households, string id)
	{
		long parsed = long.Parse(id);
		return households.Single(h => h.Id == parsed);
	}

	private static string? GetValueFromReferenceId(IEnumerable<Reference> references, string? id)
	{
		if (!string.IsNullOrWhiteSpace(id))
		{
			var match = references.SingleOrDefault(r => r.TBL_ID == id);
			return match?.DESCS;
		}
		else return null;
	}

	private static DateTime? ParseTimestamp(string? timestamp)
	{
		if (!string.IsNullOrWhiteSpace(timestamp))
		{
			const string format = "yyyyMMdd";
			var provider = CultureInfo.InvariantCulture;
			var style = DateTimeStyles.AdjustToUniversal;

			string s;
			if (timestamp.StartsWith('9'))
			{
				s = $"1{timestamp}";
			}
			else s = timestamp;

			var result = DateTime.ParseExact(s, format, provider, style);
			return result.ToUniversalTime();
		}
		else return null;
	}

	private static bool IsChild(Models.Individual individual)
	{
		return individual.RELAT_CD switch
		{
			"0000000000000001" => false, 	// Head of Household
			"0000000000000002" => false, 	// Spouse
			"0000000000000003" => true, 	// Son
			"0000000000000004" => true, 	// Daughter
			"0000000000000094" => false, 	// Aunt
			"0000000000000095" => false, 	// Brother
			"0000000000000096" => false, 	// Brother In-Law
			"0000000000000097" => true, 	// Child
			"0000000000000098" => false, 	// Cousin
			"0000000000000099" => true, 	// Daughter In - Law
			"0000000000000100" => false, 	// Father
			"0000000000000101" => false, 	// Father In-Law
			"0000000000000102" => false, 	// Child's mother/girlfriend
			"0000000000000103" => true, 	// Granddaughter
			"0000000000000104" => false, 	// Grandfather
			"0000000000000105" => false, 	// Grandmother
			"0000000000000107" => true, 	// Great Granddaughter
			"0000000000000108" => false, 	// Great Grandfather
			"0000000000000109" => false, 	// Great Grandmother
			"0000000000000110" => true, 	// Grandson
			"0000000000000111" => false, 	// Individual
			"0000000000000112" => false, 	// Mother
			"0000000000000113" => false, 	// Mother In-Law
			"0000000000000114" => false, 	// Neighbor
			"0000000000000115" => true, 	// Nephew
			"0000000000000116" => true, 	// Niece
			"0000000000000117" => false, 	// Relative
			"0000000000000118" => false, 	// Sister
			"0000000000000119" => false, 	// Sister In - Law
			"0000000000000120" => true, 	// Son In-Law
			"0000000000000121" => true, 	// Step Daughter
			"0000000000000122" => true, 	// Step Son
			"0000000000000123" => true, 	// Student
			"0000000000000124" => false, 	// Uncle
			"0000000000000400" => false, 	// Organization Record
			_ => false,
		};
	}
}
