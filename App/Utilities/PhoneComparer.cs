using MOM.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace MOM.Utilities;

internal class PhoneComparer : IEqualityComparer<string?>
{
	private const string MASK = "0000000000";

	public bool Equals(string? x, string? y)
	{
		string a = FormatHelper.FormatPhone(x, MASK);
		string b = FormatHelper.FormatPhone(x, MASK);
		return string.Equals(a, b);
	}

	public int GetHashCode([DisallowNull] string? obj)
	{
		string normalized = FormatHelper.FormatPhone(obj, MASK);
		return normalized.GetHashCode();
	}
}
