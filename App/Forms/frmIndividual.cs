using DataCommon.Models;
using Serilog;

namespace MOM.Forms;

public partial class frmIndividual : Form
{
	private readonly Individual _individual;

	public frmIndividual(Individual individual)
	{
		_individual = individual;
		InitializeComponent();
	}

	public async Task LoadAutoCompleteAsync(IQueryable<Individual> source)
	{
		try
		{
			await tbLastName.SetSuggestionsWhereActiveAsync(source, i => i.LastName);
			await tbCommunicationPreference.SetSuggestionsWhereActiveAsync(source, i => i.CommunicationPreference);
			await tbOccupation.SetSuggestionsWhereActiveAsync(source, i => i.Occupation);
			await tbEmployer.SetSuggestionsWhereActiveAsync(source, i => i.Employer);
			await tbGender.SetSuggestionsWhereActiveAsync(source, i => i.Gender);
			await tbJoinedMethod.SetSuggestionsWhereActiveAsync(source, i => i.JoinedMethod);
			await tbBaptismLocation.SetSuggestionsWhereActiveAsync(source, i => i.BaptizedLocation);
			await tbMaritalStatus.SetSuggestionsWhereActiveAsync(source, i => i.MaritalStatus);
			await tbMemberStatus.SetSuggestionsWhereActiveAsync(source, i => i.MemberStatus);
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Error loading autocomplete");
		}
	}

	private void tbFirstName_TextChanged(object sender, EventArgs e)
	{
		tbPreferredName.PlaceholderText = tbFirstName.Text;
	}

	private void llPreferFirstName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		tbPreferredName.Text = string.Empty;
	}

	private void llPreferMiddleName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		tbPreferredName.Text = tbMiddleName.Text;
	}

	private void frmIndividual_Shown(object sender, EventArgs e)
	{
		tbFirstName.Text = _individual.FirstName;
		tbMiddleName.Text = _individual.MiddleName;
		tbLastName.Text = _individual.LastName;
		tbPreferredName.Text = _individual.PreferredName;

		tbMobilePhone.Text = _individual.MobilePhone;
		tbHomePhone.Text = _individual.HomePhone;
		tbEmail.Text = _individual.Email;
		tbCommunicationPreference.Text = _individual.CommunicationPreference;

		tbOccupation.Text = _individual.Occupation;
		tbEmployer.Text = _individual.Employer;
		tbBirthDate.Value = _individual.BirthDate;
		tbGender.Text = _individual.Gender;

		tbJoinedMethod.Text = _individual.JoinedMethod;
		tbJoinedDate.Value = _individual.JoinedDate;
		tbBaptismLocation.Text = _individual.BaptizedLocation;
		tbBaptismDate.Value = _individual.BaptizedDate;
		tbMaritalStatus.Text = _individual.MaritalStatus;
		tbMarriageDate.Value = _individual.MarriedDate;

		tbMemberStatus.Text = _individual.MemberStatus;
		cbHasMembership.Checked = _individual.IsMember;

		cbChild.Checked = _individual.Child;
		cbActive.Checked = _individual.Active;

		tbFirstName.Focus();
		tbFirstName.SelectAll();
	}

	private void btnSave_Click(object sender, EventArgs e)
	{
		_individual.FirstName = tbFirstName.Text;
		_individual.MiddleName = tbMiddleName.Text;
		_individual.LastName = tbLastName.Text;
		_individual.PreferredName = tbPreferredName.Text;

		_individual.MobilePhone = tbMobilePhone.Text;
		_individual.HomePhone = tbHomePhone.Text;
		_individual.Email = tbEmail.Text;
		_individual.CommunicationPreference = tbCommunicationPreference.Text;

		_individual.Occupation = tbOccupation.Text;
		_individual.Employer = tbEmployer.Text;
		_individual.BirthDate = tbBirthDate.Value;
		_individual.Gender = tbGender.Text;

		_individual.JoinedMethod = tbJoinedMethod.Text;
		_individual.JoinedDate = tbJoinedDate.Value;
		_individual.BaptizedLocation = tbBaptismLocation.Text;
		_individual.BaptizedDate = tbBaptismDate.Value;
		_individual.MaritalStatus = tbMaritalStatus.Text;
		_individual.MarriedDate = tbMarriageDate.Value;

		_individual.MemberStatus = tbMemberStatus.Text;
		_individual.IsMember = cbHasMembership.Checked;

		_individual.Child = cbChild.Checked;
		_individual.Active = cbActive.Checked;

		DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		if (keyData == (Keys.Control | Keys.Enter) || keyData == (Keys.Control | Keys.Space))
		{
			btnOK.PerformClick();
			return true;
		}
		else if (keyData == (Keys.Control | Keys.W))
		{
			btnCancel.PerformClick();
			return true;
		}
		return base.ProcessCmdKey(ref msg, keyData);
	}
}
