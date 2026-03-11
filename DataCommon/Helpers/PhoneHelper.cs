namespace DataCommon.Helpers;

public class PhoneHelper
{
	public static bool Equals(string? a, string? b)
	{
		if (!string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b))
		{
			return Normalize(a) == Normalize(b);
		}
		else return string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b);
	}

	public static string Normalize(string num)
	{
		// Keep only digits
		var digits = new List<char>();
		foreach (var c in num)
		{
			if (char.IsDigit(c))
			{
				digits.Add(c);
			}
		}

		return new string([.. digits]);
	}
}
