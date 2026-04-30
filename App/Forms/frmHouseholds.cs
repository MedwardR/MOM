using DataCommon.Helpers;
using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Services;
using Serilog;
using System.ComponentModel;
using System.Text;

namespace MOM.Forms;

public partial class frmHouseholds : Form
{
	private readonly AppContextFactory _factory;
	private readonly BindingList<Household> _collection = [];
	private Household? _current;
	private Household? _original;
	private bool _restoring;
	private CancellationTokenSource? _cts;

	public frmHouseholds()
	{
		var frm = new frmLogin();
		frm.ShowDialog();

		if (frm.ContextFactory is not null)
		{
			_factory = frm.ContextFactory;
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

	public UserSettings? GetSettings() => _factory.UserSettings;

	public void LogOut()
	{
		if (_factory.AuthenticatedUser is not null)
		{
			using var context = _factory.CreateDbContext();
			var user = context.Users.Find(_factory.AuthenticatedUser.Id)!;
			user.IsLoggedIn = false;
			context.SaveChanges();
		}
	}

	private async Task LoadHouseholdsAsync(string search, CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();
		if (!_restoring)
		{
			try
			{
				_restoring = true;
				using var context = _factory.CreateDbContext();

				IQueryable<Household> query;
				if (!string.IsNullOrWhiteSpace(search))
				{
					string trimmed = search.Trim();

					query = context.Households.Where(h =>
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
				else query = context.Households.Where(h => h.Active);

				var materialized = await query.OrderBy(h => h.Name).ToListAsync(cancellationToken);
				cancellationToken.ThrowIfCancellationRequested();

				var filtered = materialized.Where(h => h.IncludeInDirectory || cbAll.Checked).ToArray();
				cancellationToken.ThrowIfCancellationRequested();

				var oldIds = _collection.Select(h => h.Id).ToHashSet();
				var newIds = filtered.Select(h => h.Id).ToHashSet();

				if (!oldIds.SetEquals(newIds))
				{
					_collection.Clear();

					foreach (var h in filtered)
					{
						cancellationToken.ThrowIfCancellationRequested();
						_collection.Add(h);
					}
				}
				var first = _collection.FirstOrDefault();

				if (first is not null)
				{
					await ChangeCurrentAsync(first);
				}
			}
			finally
			{
				_restoring = false;
			}
		}
	}

	private async Task LoadAutoCompleteAsync()
	{
		try
		{
			using var context = _factory.CreateDbContext();

			await tbCity.SetSuggestionsWhereActiveAsync(context.Households, h => h.Address.City);
			await tbState.SetSuggestionsWhereActiveAsync(context.Households, h => h.Address.State);
			await tbZIP.SetSuggestionsWhereActiveAsync(context.Households, h => h.Address.Zip);
			await tbCountry.SetSuggestionsWhereActiveAsync(context.Households, h => h.Address.Country);
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
			_current.IncludeInDirectory = cbIncludeInDirectory.Checked;
			_current.Active = cbActive.Checked;

			using var context = _factory.CreateDbContext();

			context.Attach(_current);
			context.Entry(_current).State = _current.Id == 0 ? EntityState.Added : EntityState.Modified;
			foreach (var member in _current.Individuals)
			{
				context.Entry(member).State = member.Id == 0 ? EntityState.Added : EntityState.Modified;
			}
			await context.SaveChangesAsync();

			_original = _current.Clone();
		}
	}

	private async Task RevertHouseholdsAsync()
	{
		SuspendLayout();
		await LoadHouseholdsAsync(string.Empty);
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
		cbIncludeInDirectory.Checked = household.IncludeInDirectory;
		cbActive.Checked = household.Active;

		using var context = _factory.CreateDbContext();
		context.Attach(household);

		await context.Entry(household)
			.Collection(h => h.Individuals)
			.Query()
			.Where(m => m.Active)
			.LoadAsync();
		PopulateMembers(household.Individuals);

		_original = household.Clone();
	}

	private void PopulateMembers(IEnumerable<Individual> source)
	{
		flpMembers.SuspendLayout();
		flpMembers.Controls.Clear();

		var sorted = SortHelper.SortMembers(source);
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

	private void FocusCurrent()
	{
		if (_current is not null)
		{
			try
			{
				_restoring = true;
				int index = _collection.IndexOf(_current);

				dgvHouseholds.ClearSelection();
				if (index > 0 && index < dgvHouseholds.RowCount)
				{
					dgvHouseholds.Rows[index].Selected = true;
				}
				else
				{
					dgvHouseholds.Rows[0].Selected = true;
				}
			}
			finally
			{
				_restoring = false;
			}
		}
	}

	private bool HasChanges()
	{
		try
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
				bool includeInDirectoryChanged = _current.IncludeInDirectory != cbIncludeInDirectory.Checked;
				bool activeChanged = _current.Active != cbActive.Checked;

				if (fieldsChanged || includeInDirectoryChanged || activeChanged)
				{
					return true;
				}
				else
				{
					if (_current.Individuals.Count != _original!.Individuals.Count)
					{
						return true;
					}
					else
					{
						bool result = false;

						for (int index = 0; index < _current.Individuals.Count; index++)
						{
							var member = _current.Individuals[index];
							var original = _original!.Individuals[index];

							if (!member.Equals(original))
							{
								result = true;
								break;
							}
						}
						return result;
					}
				}
			}
			else return false;
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Error checking for changes");
			return true;
		}
	}

	private async Task<DialogResult> EditIndividualAsync(Individual member)
	{
		using var context = _factory.CreateDbContext();
		using var frm = new frmIndividual(member);
		await frm.LoadAutoCompleteAsync(context.Individuals);
		frm.ShowDialog();

		return frm.DialogResult;
	}

	private async Task SearchAsync()
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

	private async void tbSearch_TextChanged(object sender, EventArgs e)
	{
		await SearchAsync();
	}

	private async void cbAll_CheckedChanged(object sender, EventArgs e)
	{
		await SearchAsync();
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
				await RevertHouseholdsAsync();

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

	private void llReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		var context = _factory.CreateDbContext();
		var frm = new frmReports(context);
		frm.Show();
	}

	private async void frmHouseholds_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			Enabled = false;

			if (Application.OpenForms.Count > 1)
			{
				string message = "Closing the main window will exit the program, disposing any other open forms. Continue anyway?";
				var choice = MessageBox.Show(message, "Open Forms Remaining", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

				if (choice == DialogResult.OK)
				{
					e.Cancel = false;
				}
				else e.Cancel = true;
			}
			if (!e.Cancel && HasChanges())
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

	private void frmHouseholds_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			foreach (object other in Application.OpenForms)
			{
				if (other is Form frm) frm.Hide();
			}
			using var backup = new frmBackup(_factory.UserSettings);

			bool configured = backup.IsConfigured();
			if (configured)
			{
				string directory = _factory.UserSettings.BackupDirectory ?? string.Empty;

				if (Directory.Exists(directory))
				{
					backup.ShowDialog(this);
				}
				else
				{
					var message = new StringBuilder();
					message.AppendLine("Warning: backup not created. The configured backup folder does not exist:");
					message.AppendLine();
					message.Append(directory);
					MessageBox.Show(message.ToString(), "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else Log.Information("Backup not configured");
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Error occurred during backup process");
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
