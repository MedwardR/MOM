using MOM.Abstractions;
using MOM.Reports;
using System.Globalization;

namespace MOM.Forms;

public partial class frmReports : Form
{
	private readonly AppContext _context;

	public frmReports(AppContext context)
	{
		_context = context;

		var months = GetMonths();
		InitializeComponent();

		cmbBirthdayFrom.DataSource = months.ToArray();
		cmbBirthdayFrom.ValueMember = nameof(Month.Value);
		cmbBirthdayFrom.DisplayMember = nameof(Month.Name);

		cmbBirthdayTo.DataSource = months.ToArray();
		cmbBirthdayTo.ValueMember = nameof(Month.Value);
		cmbBirthdayTo.DisplayMember = nameof(Month.Name);

		var birthdaySortOptions = new[]
		{
			BirthdaySort.DayAscending,
			BirthdaySort.DayDescending,
			BirthdaySort.YearAscending,
			BirthdaySort.YearDescending,
		};
		cmbBirthdayOrderBy.DataSource = birthdaySortOptions;
		cmbBirthdayOrderBy.ValueMember = nameof(BirthdaySort.Value);
		cmbBirthdayOrderBy.DisplayMember = nameof(BirthdaySort.Name);
	}

	private void cmbBirthdayFrom_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbBirthdayFrom.SelectedItem is Month from && cmbBirthdayTo.SelectedItem is Month to)
		{
			if (from.Value > to.Value)
			{
				cmbBirthdayTo.SelectedItem = from;
			}
		}
	}

	private void cmbBirthdayTo_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbBirthdayFrom.SelectedItem is Month from && cmbBirthdayTo.SelectedItem is Month to)
		{
			if (from.Value > to.Value)
			{
				cmbBirthdayFrom.SelectedItem = to;
			}
		}
	}

	private async void btnBirthdayGenerate_Click(object sender, EventArgs e)
	{
		if (cmbBirthdayFrom.SelectedItem is Month from && cmbBirthdayTo.SelectedItem is Month to)
		{
			var report = new BirthdayReport(_context, from.Value, to.Value);
			
			if (cmbBirthdayOrderBy.SelectedItem is BirthdaySort sort)
			{
				if (sort.Value == BirthdaySort.DayAscending.Value)
				{
					report.OrderBy(member => member.BirthDate.GetValueOrDefault().Day);
				}
				else if (sort.Value == BirthdaySort.DayDescending.Value)
				{
					report.OrderByDescending(member => member.BirthDate.GetValueOrDefault().Day);
				}
				else if (sort.Value == BirthdaySort.YearAscending.Value)
				{
					report.OrderBy(member => member.BirthDate.GetValueOrDefault().Year);
				}
				else if (sort.Value == BirthdaySort.YearDescending.Value)
				{
					report.OrderByDescending(member => member.BirthDate.GetValueOrDefault().Year);
				}
			}
			await RunReportAsync(report);
		}
	}

	private async Task RunReportAsync(Report report)
	{
		try
		{
			tabControl1.Enabled = false;
			await report.ShowAsync();
		}
		finally
		{
			tabControl1.Enabled = true;
		}
	}

	private static Month[] GetMonths()
	{
		int[] values = [.. Enumerable.Range(1, 12)];
		var months = new Month[values.Length];

		for (int index = 0; index < values.Length; index++)
		{
			int v = values[index];
			string name = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(v);
			months[index] = new(v, name);
		}
		return months;
	}

	private class Month(int value, string name)
	{
		public int Value { get; } = value;
		public string Name { get; } = name;
	}

	private class BirthdaySort(int value, string name)
	{
		public int Value { get; } = value;
		public string Name { get; } = name;

		public static BirthdaySort DayAscending => new(0, "Day (soonest first)");
		public static BirthdaySort DayDescending => new(1, "Day (farthest first)");
		public static BirthdaySort YearAscending => new(2, "Year (oldest first)");
		public static BirthdaySort YearDescending => new(3, "Year (youngest first)");
	}
}
