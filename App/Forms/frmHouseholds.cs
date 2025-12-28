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

	private async Task LoadHouseholdsAsync()
	{
		var materialized = await _app.Households
			.Where(h => h.Active)
			.ToListAsync();

		_collection.Clear();
		foreach (var h in materialized)
		{
			_collection.Add(h);
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

	private void ChangeCurrent(Household household)
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

		flpMembers.SuspendLayout();
		flpMembers.Controls.Clear();
		foreach (var member in household.Individuals)
		{
			if (member.Active)
			{
				InitializeMember(member);
			}
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

	private void InitializeMember(Individual member)
	{
		var button = new Button
		{
			AutoSize = btnMemberTemplate.AutoSize,
			AutoSizeMode = btnMemberTemplate.AutoSizeMode,
			Text = member.GetDisplayName(),
			UseVisualStyleBackColor = btnMemberTemplate.UseVisualStyleBackColor,
		};
		button.Click += (_, _) =>
		{
			using var frm = new frmIndividual(member);
			frm.ShowDialog();

			if (frm.DialogResult != DialogResult.Cancel)
			{
				if (!member.Active)
				{
					button.Dispose();
					flpMembers.Controls.Remove(button);
				}
				button.Text = member.GetDisplayName();
			}
		};
		flpMembers.Controls.Add(button);
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
			await LoadHouseholdsAsync();
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

	private void btnNewHousehold_Click(object sender, EventArgs e)
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
			ChangeCurrent(newItem);
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
					ChangeCurrent(_current);
				}
			}
		}
		finally
		{
			Enabled = true;
		}
	}

	private void btnAddMember_Click(object sender, EventArgs e)
	{
		if (_current is not null)
		{
			var member = _current.GetNewMember();

			using var frm = new frmIndividual(member);
			frm.ShowDialog();

			if (frm.DialogResult != DialogResult.Cancel)
			{
				_current.Individuals.Add(member);
				InitializeMember(member);
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
						ChangeCurrent(newSelection);
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
