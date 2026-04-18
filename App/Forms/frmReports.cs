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

		InitializeComponent();
		Setup();
	}

	private void Setup()
	{
		var months = GetMonths();

		var dateSortOptions = new[]
		{
			DateSort.DayAscending,
			DateSort.DayDescending,
			DateSort.YearAscending,
			DateSort.YearDescending,
		};
		var memberSortOptions = new[]
		{
			MemberSort.NameAscending,
			MemberSort.NameDescending,
			MemberSort.AgeAscending,
			MemberSort.AgeDescending,
		};
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

		cmbMemberOrderBy.DataSource = memberSortOptions.ToArray();
		cmbMemberOrderBy.ValueMember = nameof(MemberSort.Value);
		cmbMemberOrderBy.DisplayMember = nameof(MemberSort.Name);
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
		else throw new InvalidOperationException("Invalid selection");
	}

	private void llMemberSchoolAge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		int year = DateTime.Today.Month < 6 ? DateTime.Today.Year - 1 : DateTime.Today.Year;
		var cutoff = new DateTime(year, 9, 1);

		tbMemberAgeFrom.Value = cutoff.AddYears(-18);
		tbMemberAgeTo.Value = cutoff.AddYears(-5).AddDays(-1);
		cmbMemberOrderBy.SelectedValue = MemberSort.AgeAscending.Value;
	}

	private void tbMemberAgeFrom_Validated(object sender, EventArgs e)
	{
		if (tbMemberAgeFrom.Value is DateTime from && tbMemberAgeTo.Value is DateTime to)
		{
			if (from > to)
			{
				tbMemberAgeTo.Value = from;
			}
		}
	}

	private void tbMemberAgeTo_Validated(object sender, EventArgs e)
	{
		if (tbMemberAgeFrom.Value is DateTime from && tbMemberAgeTo.Value is DateTime to)
		{
			if (from > to)
			{
				tbMemberAgeTo.Value = to;
			}
		}
	}

	private async void btnMemberGenerate_Click(object sender, EventArgs e)
	{
		var report = new MembershipReport(_context);

		if (tbMemberAgeFrom.Value is DateTime from)
		{
			report.AddFilter(member => member.BirthDate.HasValue && member.BirthDate.Value >= from);
		}
		if (tbMemberAgeTo.Value is DateTime to)
		{
			report.AddFilter(member => member.BirthDate.HasValue && member.BirthDate.Value <= to);
		}
		if (cmbMemberOrderBy.SelectedItem is MemberSort sort)
		{
			if (sort.Value == MemberSort.NameAscending.Value)
			{
				report.OrderByName();
			}
			else if (sort.Value == MemberSort.NameDescending.Value)
			{
				report.OrderByNameDescending();
			}
			else if (sort.Value == MemberSort.AgeAscending.Value)
			{
				report.OrderByDescending(member => member.BirthDate.GetValueOrDefault());
			}
			else if (sort.Value == MemberSort.AgeDescending.Value)
			{
				report.OrderBy(member => member.BirthDate.GetValueOrDefault());
			}
		}
		await RunReportAsync(report);
	}

	private async void btnChurchDirectoryGenerate_Click(object sender, EventArgs e)
	{
		var report = new ChurchDirectoryReport(_context);
		await RunReportAsync(report);
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

		public static DateSort DayAscending => new(0, "Day (ascending)");
		public static DateSort DayDescending => new(1, "Day (descending)");
		public static DateSort YearAscending => new(2, "Year (ascending)");
		public static DateSort YearDescending => new(3, "Year (descending)");
	}

	private class MemberSort(int value, string name)
	{
		public int Value { get; } = value;
		public string Name { get; } = name;

		public static MemberSort NameAscending => new(0, "Name (ascending)");
		public static MemberSort NameDescending => new(1, "Name (descending)");
		public static MemberSort AgeAscending => new(2, "Age (ascending)");
		public static MemberSort AgeDescending => new(3, "Age (descending)");
	}
}
