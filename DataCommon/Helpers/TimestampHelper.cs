namespace DataCommon.Helpers;

public static class TimestampHelper
{
	public static int YearsBetween(DateTime a, DateTime b)
	{
		int years = a.Year - b.Year;

		if (a < b.AddYears(years))
		{
			return years - 1;
		}
		else return years;
	}

	public static (DateTime Start, DateTime End) GetBirthdateRangeForGradesK12() => GetBirthdateRangeForGradesK12(DateTime.Now);

	public static (DateTime Start, DateTime End) GetBirthdateRangeForGradesK12(DateTime moment)
	{
		int year = moment.Month < 6 ? moment.Year - 1 : moment.Year;
		var cutoff = new DateTime(year, 9, 1);

		var oldest = cutoff.AddYears(-18);
		var youngest = cutoff.AddYears(-5).AddDays(-1);

		return (oldest, youngest);
	}
}
