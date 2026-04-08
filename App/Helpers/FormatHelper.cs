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
			var provider = new MaskedTextProvider(mask);
			provider.Set(input);
			return provider.ToDisplayString();
		}
		else return string.Empty;
	}
}
