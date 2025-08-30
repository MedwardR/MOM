using Microsoft.EntityFrameworkCore;
using MOM.Models;
using Serilog;
using System.ComponentModel;

namespace MOM
{
	public partial class frmMain : Form
	{
		private readonly AppContext _app;
		private readonly BindingList<Household> _households = [];

		public frmMain()
		{
			var frm = new frmLogin();
			frm.ShowDialog();

			if (frm.AppContext is not null)
			{
				_app = frm.AppContext;
				InitializeComponent();
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

		private async void frmMain_Shown(object sender, EventArgs e)
		{
			await LoadHouseholdsAsync();
		}

		private void bsHouseholds_CurrentChanged(object sender, EventArgs e)
		{
			if (bsHouseholds.Current is Household household)
			{
				bool cancel;
				if (CurrentHouseholdHasChanges())
				{
					var choice = MessageBox.Show(
						"The current household has unsaved changes! Continue without saving?",
						"Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (choice == DialogResult.Yes)
					{
						cancel = false;
					}
					else cancel = true;
				}
				else cancel = false;

				if (!cancel)
				{
					_app.RevertChanges();
					
				}
			}
		}

		private async void btnNew_Click(object sender, EventArgs e)
		{
			var household = new Household
			{
				Name = "(New Household)"
			};
			await _app.Households.AddAsync(household);
			_households.Add(household);
			bsHouseholds.Position = _households.IndexOf(household);
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			await SaveHouseholdsAsync();
		}

		private async void btnRevert_Click(object sender, EventArgs e)
		{
			Enabled = false;
			_app.RevertChanges();
			await LoadHouseholdsAsync();
			Enabled = true;
		}

		private async Task LoadHouseholdsAsync()
		{
			var materialzied = await _app.Households.ToListAsync();

			_households.Clear();
			foreach (var h in materialzied)
			{
				_households.Add(h);
			}
		}

		private async Task SaveHouseholdsAsync()
		{
			Enabled = false;
			await _app.SaveChangesAsync();
			Enabled = true;
		}

		private bool CurrentHouseholdHasChanges()
		{
			if (bsHouseholds.Current is Household household)
			{
				var fields = new (object?, object?)[]
				{
					(household.Name,				tbName.Text),
					(household.Address?.Street,		tbStreet.Text),
					(household.Address?.City,		tbCity.Text),
					(household.Address?.Zip,		tbZIP.Text),
					(household.Address?.State,		tbState.Text),
					(household.Address?.Country,	tbCountry.Text),
					(household.Phone,				tbPhone.Text),
					(household.Email,				tbEmail.Text),
				};
				return fields.Any(f => Equals(f.Item1, f.Item2));
			}
			else return false;
		}
	}
}
