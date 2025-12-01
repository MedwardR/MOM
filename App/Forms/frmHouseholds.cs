using DataCommon.Models;
using Microsoft.EntityFrameworkCore;
using MOM.Forms;
using Serilog;
using System.CodeDom;
using System.ComponentModel;

namespace MOM
{
	public partial class frmHouseholds : Form
	{
		private readonly AppContext _app;
		private readonly BindingList<Household> _collection = [];
		private Household? _current = null;
		private bool _restoring = false;

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
			if (_app is not null)
			{
				if (_app.AuthenticatedUser is not null)
				{
					_app.RevertChanges();
					_app.AuthenticatedUser.IsLoggedIn = false;
					_app.SaveChanges();
				}
			}
		}

		private async Task LoadHouseholdsAsync()
		{
			var materialzied = await _app.Households.ToListAsync();

			_collection.Clear();
			foreach (var h in materialzied)
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
				_current.Address.City = tbCity.Text;
				_current.Address.State = tbState.Text;
				_current.Address.Zip = tbZIP.Text;
				_current.Address.Country = tbCountry.Text;
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
			if (household is not null)
			{
				_current = household;
				FocusCurrent();

				tbName.Text = household.Name;
				tbStreet.Text = household.Address.Street;
				tbCity.Text = household.Address.City;
				tbState.Text = household.Address.State;
				tbZIP.Text = household.Address.Zip;
				tbCountry.Text = household.Address.Country;

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
			else throw new ArgumentNullException(nameof(household));
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
					(_current.Name,            tbName.Text),
					(_current.Address.Street,  tbStreet.Text),
					(_current.Address.City,    tbCity.Text),
					(_current.Address.State,   tbState.Text),
					(_current.Address.Zip,     tbZIP.Text),
					(_current.Address.Country, tbCountry.Text),
				};
				bool fieldsChanged = fields.Any(f =>
				{
					string? a = f.Item1?.Trim();
					string? b = f.Item2?.Trim();
					return !string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
				});
				bool membersCountChanged = _current.Individuals.Count != flpMembers.Controls.Count;
				bool membersChanged = _current.Individuals.Any(_app.EntityHasChanges);
				
				return fieldsChanged || membersCountChanged || membersChanged;
			}
			else return false;
		}

		private void InitializeMember(Individual member)
		{
			var button = new Button
			{
				AutoSize = btnMemberTemplate.AutoSize,
				AutoSizeMode = btnMemberTemplate.AutoSizeMode,
				Text = member.FirstName,
				UseVisualStyleBackColor = btnMemberTemplate.UseVisualStyleBackColor,
			};
			button.Click += (s, e) =>
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
					button.Text = member.FirstName;
				}
			};
			flpMembers.Controls.Add(button);
		}

		private static DialogResult ConfirmBeforeDiscardingChanges()
		{
			const string text = "The current household has unsaved changes! Continue without saving?";
			return MessageBox.Show(text, "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		}

		private async void frmHouseholds_Shown(object sender, EventArgs e)
		{
			Enabled = false;
			try
			{
				await LoadHouseholdsAsync();
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
			Enabled = false;
			try
			{
				await SaveHouseholdsAsync();
			}
			finally
			{
				Enabled = true;
			}
		}

		private void btnRevert_Click(object sender, EventArgs e)
		{
			try
			{
				Enabled = false;

				bool cancel;
				if (HasChanges())
				{
					var choice = ConfirmBeforeDiscardingChanges();
					if (choice == DialogResult.Yes)
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

		private void dgvHouseholds_SelectionChanged(object sender, EventArgs e)
		{
			if (!_restoring)
			{
				if (bsHouseholds.Current is Household newSelection)
				{
					bool cancel;
					if (HasChanges())
					{
						var choice = ConfirmBeforeDiscardingChanges();
						if (choice == DialogResult.Yes)
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
	}
}
