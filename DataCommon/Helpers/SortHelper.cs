using DataCommon.Models;

namespace DataCommon.Helpers;

public class SortHelper
{
	public static Individual[] SortMembers(IEnumerable<Individual> source)
	{
		// Helper: treat null BirthDate as MaxValue so nulls come last (youngest)
		static DateTime BirthOrMax(Individual i) => i.BirthDate ?? DateTime.MaxValue;

		// Split into non-children and children
		var nonChildren = source.Where(i => !i.Child).ToList();
		var children = source.Where(i => i.Child).OrderBy(BirthOrMax).ToList();

		// Oldest male & female among non-children
		var oldestMale = nonChildren
			.Where(i => i.Gender?.StartsWith("M", StringComparison.OrdinalIgnoreCase) == true)
			.OrderBy(BirthOrMax)
			.FirstOrDefault();

		var oldestFemale = nonChildren
			.Where(i => i.Gender?.StartsWith("F", StringComparison.OrdinalIgnoreCase) == true)
			.OrderBy(BirthOrMax)
			.FirstOrDefault();

		// Exclude oldest male/female from remaining non-children
		var excludedIds = new HashSet<long>(
			[oldestMale?.Id ?? -1, oldestFemale?.Id ?? -1]
		);

		var remainingNonChildren = nonChildren
			.Where(i => !excludedIds.Contains(i.Id))
			.OrderBy(BirthOrMax)
			.ToList();

		// Build final list
		var result = new List<Individual>();
		if (oldestMale is not null) result.Add(oldestMale);
		if (oldestFemale is not null && oldestFemale.Id != oldestMale?.Id) result.Add(oldestFemale);
		result.AddRange(remainingNonChildren);
		result.AddRange(children);

		return [.. result];
	}
}
