using MOM.Utilities;
using System.ComponentModel;

namespace MOM.Helpers;

internal static class FormatHelper
{
	public static PhoneComparer PhoneComparer => new();

	public static string FormatPhone(string? input, string mask)
	{
		if (!string.IsNullOrWhiteSpace(input))
		{
			char[] digits = [.. input.Where(char.IsDigit)];
			string normalized = new(digits);

			var provider = new MaskedTextProvider(mask);
			provider.Set(normalized);

			return provider.ToDisplayString();
		}
		else return string.Empty;
	}
}
