using System.ComponentModel;
using System.Globalization;

namespace MOM.Controls
{
	public partial class DateTimeTextBox : MaskedTextBox
	{
		private const string DEFAULT_FORMAT = "MM/dd/yyyy";
		private const string DEFAULT_MASK = "90/90/9900";

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public DateTime? Value
		{
			get => Parse(Text);
			set => Text = Display(value);
		}

		[Browsable(true)]
		[DefaultValue(DEFAULT_FORMAT)]
		public string DisplayFormat { get; set; }

		public DateTimeTextBox()
		{
			DisplayFormat = DEFAULT_FORMAT;
			Mask = DEFAULT_MASK;
			ValidatingType = typeof(DateTime);

			Enter += (s, e) => BeginInvoke(SelectAll);

			Validating += (s, e) =>
			{
				var value = Parse(Text);
				Text = Display(value);
			};
		}

		private static DateTime? Parse(string text)
		{
			if (DateTime.TryParse(text, out var value))
			{
				return value.ToUniversalTime();
			}
			else return null;
		}

		private string Display(DateTime? input)
		{
			if (input.HasValue)
			{
				return input.Value.ToString(DisplayFormat, CultureInfo.InvariantCulture);
			}
			else return string.Empty;
		}
	}
}
