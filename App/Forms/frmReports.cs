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
		var dateSortOptions = new[]
		{
			DateSort.DayAscending,
			DateSort.DayDescending,
			DateSort.YearAscending,
			DateSort.YearDescending,
		};
		InitializeComponent();

		cmbBirthdayFrom.DataSource = months.ToArray();
		cmbBirthdayFrom.ValueMember = nameof(Month.Value);
		cmbBirthdayFrom.DisplayMember = nameof(Month.Name);

		cmbBirthdayTo.DataSource = months.ToArray();
		cmbBirthdayTo.ValueMember = nameof(Month.Value);
		cmbBirthdayTo.DisplayMember = nameof(Month.Name);

		cmbBirthdayOrderBy.DataSource = dateSortOptions.ToArray();
		cmbBirthdayOrderBy.ValueMember = nameof(DateSort.Value);
		cmbBirthdayOrderBy.DisplayMember = nameof(DateSort.Name);

		cmbAnniversaryFrom.DataSource = months.ToArray();
		cmbAnniversaryFrom.ValueMember = nameof(Month.Value);
		cmbAnniversaryFrom.DisplayMember = nameof(Month.Name);

		cmbAnniversaryTo.DataSource = months.ToArray();
		cmbAnniversaryTo.ValueMember = nameof(Month.Value);
		cmbAnniversaryTo.DisplayMember = nameof(Month.Name);

		cmbAnniversaryOrderBy.DataSource = dateSortOptions.ToArray();
		cmbAnniversaryOrderBy.ValueMember = nameof(DateSort.Value);
		cmbAnniversaryOrderBy.DisplayMember = nameof(DateSort.Name);
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

			if (cmbBirthdayOrderBy.SelectedItem is DateSort sort)
			{
				if (sort.Value == DateSort.DayAscending.Value)
				{
					report.OrderBy(member => member.BirthDate.GetValueOrDefault().Day);
				}
				else if (sort.Value == DateSort.DayDescending.Value)
				{
					report.OrderByDescending(member => member.BirthDate.GetValueOrDefault().Day);
				}
				else if (sort.Value == DateSort.YearAscending.Value)
				{
					report.OrderBy(member => member.BirthDate.GetValueOrDefault().Year);
				}
				else if (sort.Value == DateSort.YearDescending.Value)
				{
					report.OrderByDescending(member => member.BirthDate.GetValueOrDefault().Year);
				}
			}
			await RunReportAsync(report);
		}
	}

	private void cmbAnniversaryFrom_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbAnniversaryFrom.SelectedItem is Month from && cmbAnniversaryTo.SelectedItem is Month to)
		{
			if (from.Value > to.Value)
			{
				cmbAnniversaryTo.SelectedItem = from;
			}
		}
	}

	private void cmbAnniversaryTo_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbAnniversaryFrom.SelectedItem is Month from && cmbAnniversaryTo.SelectedItem is Month to)
		{
			if (from.Value > to.Value)
			{
				cmbAnniversaryFrom.SelectedItem = to;
			}
		}
	}

	private async void btnAnniversaryGenerate_Click(object sender, EventArgs e)
	{
		if (cmbAnniversaryFrom.SelectedItem is Month from && cmbAnniversaryTo.SelectedItem is Month to)
		{
			var report = new AnniversaryReport(_context, from.Value, to.Value);

			if (cmbAnniversaryOrderBy.SelectedItem is DateSort sort)
			{
				if (sort.Value == DateSort.DayAscending.Value)
				{
					report.OrderBy(member => member.GetMarriedDateOrDefault().GetValueOrDefault().Day);
				}
				else if (sort.Value == DateSort.DayDescending.Value)
				{
					report.OrderByDescending(member => member.GetMarriedDateOrDefault().GetValueOrDefault().Day);
				}
				else if (sort.Value == DateSort.YearAscending.Value)
				{
					report.OrderBy(member => member.GetMarriedDateOrDefault().GetValueOrDefault().Year);
				}
				else if (sort.Value == DateSort.YearDescending.Value)
				{
					report.OrderByDescending(member => member.GetMarriedDateOrDefault().GetValueOrDefault().Year);
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

	private class DateSort(int value, string name)
	{
		public int Value { get; } = value;
		public string Name { get; } = name;

		public static DateSort DayAscending => new(0, "Day (soonest first)");
		public static DateSort DayDescending => new(1, "Day (farthest first)");
		public static DateSort YearAscending => new(2, "Year (oldest first)");
		public static DateSort YearDescending => new(3, "Year (youngest first)");
	}
}
