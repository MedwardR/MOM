using DataCommon.Models;

namespace MOM.Forms;

public partial class frmIndividual : Form
{
	private readonly Individual _individual;

	public frmIndividual(Individual individual)
	{
		_individual = individual;
		InitializeComponent();
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

		_individual.Active = cbActive.Checked;

		DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}
}
