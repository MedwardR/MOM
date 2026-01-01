using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.ComponentModel;

namespace MOM.Forms;

public partial class frmHouseholds : Form
{
	private readonly AppContext _app;
	private readonly BindingList<Household> _collection = [];
	private Household? _current;
	private bool _restoring;
	private CancellationTokenSource? _cts;

	public frmHouseholds()
	{
		var frm = new frmLogin();
		frm.ShowDialog();

		if (frm.AppContext is not null)
		{
			_app = frm.AppContext;
			InitializeComponent();
			bsHouseholds.DataSource = _collection;
		}
		else
		{
			Log.Information("Application closed before logging in" + Environment.NewLine);
			Program.CloseLogger();
			Environment.Exit(0);
		}
	}

	public void LogOut()
	{
		if (_app.AuthenticatedUser is not null)
		{
			_app.RevertChanges();
			_app.AuthenticatedUser.IsLoggedIn = false;
			_app.SaveChanges();
		}
	}

	private async Task LoadHouseholdsAsync(string search, CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();

		IQueryable<Household> query;
		if (!string.IsNullOrWhiteSpace(search))
		{
			string trimmed = search.Trim();
			query = _app.Households.Where(h =>
				h.Active && (
				EF.Functions.ILike(h.Name, $"%{trimmed}%") ||
				h.Individuals.Any(m =>
					m.Active && (
					EF.Functions.ILike(m.PreferredName ?? string.Empty, $"%{trimmed}%") ||
					EF.Functions.ILike(m.FirstName, $"%{trimmed}%") ||
					EF.Functions.ILike(m.LastName, $"%{trimmed}%"))
				))
			);
		}
		else query = _app.Households.Where(h => h.Active);

		var materialized = await query.ToListAsync(cancellationToken);
		cancellationToken.ThrowIfCancellationRequested();

		var oldIds = _collection.Select(h => h.Id).ToHashSet();
		var newIds = materialized.Select(h => h.Id).ToHashSet();
		if (!oldIds.SetEquals(newIds))
		{
			_collection.Clear();
			foreach (var h in materialized)
			{
				cancellationToken.ThrowIfCancellationRequested();
				_collection.Add(h);
			}
		}
	}

	private async Task LoadAutoCompleteAsync()
	{
		try
		{
			await tbCity.SetSuggestionsWhereActiveAsync(_app.Households, h => h.Address.City);
			await tbState.SetSuggestionsWhereActiveAsync(_app.Households, h => h.Address.State);
			await tbZIP.SetSuggestionsWhereActiveAsync(_app.Households, h => h.Address.Zip);
			await tbCountry.SetSuggestionsWhereActiveAsync(_app.Households, h => h.Address.Country);
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Error loading autocomplete");
		}
	}

	private async Task SaveHouseholdsAsync()
	{
		if (_current is not null)
		{
			_current.Name = tbName.Text;
			_current.Address.Street = tbStreet.Text;
			_current.Address.Apartment = tbAdditionalInformation.Text;
			_current.Address.City = tbCity.Text;
			_current.Address.State = tbState.Text;
			_current.Address.Zip = tbZIP.Text;
			_current.Address.Country = tbCountry.Text;
			_current.Active = cbActive.Checked;
		}
		await _app.SaveChangesAsync();
	}

	private void RevertHouseholds()
	{
		SuspendLayout();
		_app.RevertChanges();
		ResumeLayout();
	}

	private async Task ChangeCurrentAsync(Household household)
	{
		_current = household;
		FocusCurrent();

		tbName.Text = household.Name;
		tbStreet.Text = household.Address.Street;
		tbAdditionalInformation.Text = household.Address.Apartment;
		tbCity.Text = household.Address.City;
		tbState.Text = household.Address.State;
		tbZIP.Text = household.Address.Zip;
		tbCountry.Text = household.Address.Country;
		cbActive.Checked = household.Active;

		await _app.Entry(household)
			.Collection(h => h.Individuals)
			.Query()
			.Where(m => m.Active)
			.LoadAsync();
		PopulateMembers(household.Individuals);
	}

	private void PopulateMembers(IEnumerable<Individual> source)
	{
		flpMembers.SuspendLayout();
		flpMembers.Controls.Clear();

		var sorted = SortMembers(source);
		foreach (var member in sorted)
		{
			var button = new Button
			{
				AutoSize = btnMemberTemplate.AutoSize,
				AutoSizeMode = btnMemberTemplate.AutoSizeMode,
				Text = member.GetDisplayName(),
				UseVisualStyleBackColor = btnMemberTemplate.UseVisualStyleBackColor,
			};
			button.Click += async (_, _) =>
			{
				var choice = await EditIndividualAsync(member);

				if (choice != DialogResult.Cancel)
				{
					if (!member.Active)
					{
						button.Dispose();
						flpMembers.Controls.Remove(button);
					}
					if (_current is not null)
					{
						PopulateMembers(_current.Individuals);
					}
					else button.Text = member.GetDisplayName();
				}
			};
			flpMembers.Controls.Add(button);
		}
		flpMembers.ResumeLayout();
	}

	private static Individual[] SortMembers(IEnumerable<Individual> source)
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

	private void FocusCurrent()
	{
		if (_current is not null)
		{
			try
			{
				_restoring = true;

				int index = _collection.IndexOf(_current);
				dgvHouseholds.ClearSelection();
				dgvHouseholds.Rows[index].Selected = true;
			}
			finally
			{
				_restoring = false;
			}
		}
	}

	private bool HasChanges()
	{
		if (_current is not null)
		{
			var fields = new (string?, string?)[]
			{
				(_current.Name,              tbName.Text),
				(_current.Address.Street,    tbStreet.Text),
				(_current.Address.Apartment, tbAdditionalInformation.Text),
				(_current.Address.City,      tbCity.Text),
				(_current.Address.State,     tbState.Text),
				(_current.Address.Zip,       tbZIP.Text),
				(_current.Address.Country,   tbCountry.Text),
			};
			bool fieldsChanged = fields.Any(f =>
			{
				string? a = f.Item1?.Trim() ?? string.Empty;
				string? b = f.Item2?.Trim() ?? string.Empty;
				return !string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
			});
			bool membersCountChanged = _current.Individuals.Count != flpMembers.Controls.Count;
			bool membersChanged = _current.Individuals.Any(_app.EntityHasChanges);
			bool activeChanged = _current.Active != cbActive.Checked;

			return fieldsChanged || membersCountChanged || membersChanged || activeChanged;
		}
		else return false;
	}

	private async Task<DialogResult> EditIndividualAsync(Individual member)
	{
		using var frm = new frmIndividual(member);
		await frm.LoadAutoCompleteAsync(_app.Individuals);
		frm.ShowDialog();

		return frm.DialogResult;
	}

	private static UnsavedChangesDialogResult ConfirmBeforeDiscardingChanges()
	{
		const string text = "The current household has unsaved changes. Save?";
		var choice = MessageBox.Show(text, "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
		if (choice == DialogResult.Yes)
		{
			return UnsavedChangesDialogResult.SaveAndContinue;
		}
		else if (choice == DialogResult.No)
		{
			return UnsavedChangesDialogResult.DiscardAndContinue;
		}
		else return UnsavedChangesDialogResult.Cancel;
	}

	private async void frmHouseholds_Shown(object sender, EventArgs e)
	{
		try
		{
			Enabled = false;
			await LoadHouseholdsAsync(string.Empty);
			await LoadAutoCompleteAsync();
		}
		catch (Exception ex)
		{
			Application.OnThreadException(ex);
		}
		finally
		{
			Enabled = true;
		}
	}

	private async void frmHouseholds_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			Enabled = false;

			if (HasChanges())
			{
				var choice = ConfirmBeforeDiscardingChanges();
				if (choice == UnsavedChangesDialogResult.SaveAndContinue)
				{
					await SaveHouseholdsAsync();
					e.Cancel = false;
				}
				else if (choice == UnsavedChangesDialogResult.DiscardAndContinue)
				{
					e.Cancel = false;
				}
				else e.Cancel = true;
			}
		}
		finally
		{
			Enabled = true;
		}
	}

	private async void tbSearch_TextChanged(object sender, EventArgs e)
	{
		_cts?.Cancel();
		_cts?.Dispose();
		_cts = new();
		try
		{
			var cancellationToken = _cts.Token;
			await LoadHouseholdsAsync(tbSearch.Text, cancellationToken);
		}
		catch (OperationCanceledException)
		{
			// Ignore
		}
		finally
		{
			_cts = null;
		}
	}

	private async void btnNewHousehold_Click(object sender, EventArgs e)
	{
		Enabled = false;
		try
		{
			var newItem = new Household
			{
				Name = "(New Household)"
			};
			_app.Households.Add(newItem);
			_collection.Add(newItem);
			await ChangeCurrentAsync(newItem);
		}
		finally
		{
			Enabled = true;
		}
	}

	private async void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			Enabled = false;
			await SaveHouseholdsAsync();
		}
		catch (Exception ex)
		{
			Application.OnThreadException(ex);
		}
		finally
		{
			Enabled = true;
		}
	}

	private async void btnRevert_Click(object sender, EventArgs e)
	{
		try
		{
			Enabled = false;

			bool cancel;
			if (HasChanges())
			{
				var choice = ConfirmBeforeDiscardingChanges();
				if (choice == UnsavedChangesDialogResult.SaveAndContinue)
				{
					await SaveHouseholdsAsync();
					cancel = false;
				}
				else if (choice == UnsavedChangesDialogResult.DiscardAndContinue)
				{
					cancel = false;
				}
				else cancel = true;
			}
			else cancel = true;

			if (!cancel)
			{
				RevertHouseholds();

				if (_current is not null)
				{
					await ChangeCurrentAsync(_current);
				}
			}
		}
		finally
		{
			Enabled = true;
		}
	}

	private async void btnAddMember_Click(object sender, EventArgs e)
	{
		if (_current is not null)
		{
			var member = _current.GetNewMember();
			var choice = await EditIndividualAsync(member);

			if (choice != DialogResult.Cancel)
			{
				_current.Individuals.Add(member);
				PopulateMembers(_current.Individuals);
			}
		}
	}

	private async void dgvHouseholds_SelectionChanged(object sender, EventArgs e)
	{
		try
		{
			if (!_restoring)
			{
				if (bsHouseholds.Current is Household newSelection)
				{
					bool cancel;
					if (HasChanges())
					{
						var choice = ConfirmBeforeDiscardingChanges();
						if (choice == UnsavedChangesDialogResult.SaveAndContinue)
						{
							await SaveHouseholdsAsync();
							cancel = false;
						}
						else if (choice == UnsavedChangesDialogResult.DiscardAndContinue)
						{
							cancel = false;
						}
						else cancel = true;
					}
					else cancel = false;

					if (!cancel)
					{
						RevertHouseholds();
						await ChangeCurrentAsync(newSelection);
					}
					else FocusCurrent();
				}
			}
		}
		catch (Exception ex)
		{
			Application.OnThreadException(ex);
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (keyData == (Keys.Control | Keys.N))
		{
			btnNewHousehold.PerformClick();
			return true;
		}
		else if (keyData == (Keys.Control | Keys.S))
		{
			btnSave.PerformClick();
			return true;
		}
		else if (keyData == (Keys.Control | Keys.R))
		{
			btnRevert.PerformClick();
			return true;
		}
		else if (keyData == (Keys.Control | Keys.M))
		{
			btnAddMember.PerformClick();
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}

	private enum UnsavedChangesDialogResult
	{
		SaveAndContinue,
		DiscardAndContinue,
		Cancel,
	}
}
