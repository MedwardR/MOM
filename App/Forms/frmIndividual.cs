using MOM.Models;

namespace MOM.Forms
{
	public partial class frmIndividual : Form
	{
		public Individual Individual { get; set; }

		public frmIndividual(Individual individual)
		{
			Individual = individual;
			InitializeComponent();
		}

		private void frmIndividual_Shown(object sender, EventArgs e)
		{
			tbFirstName.Text = Individual.FirstName;
			tbMiddleName.Text = Individual.MiddleName;
			tbLastName.Text = Individual.LastName;

			tbPhone.Text = Individual.Phone;
			tbEmail.Text = Individual.Email;
			tbCommunicationPreference.Text = Individual.CommunicationPreference;

			tbOccupation.Text = Individual.Occupation;
			tbEmployer.Text = Individual.Employer;
			tbBirthDate.Value = Individual.BirthDate;
			tbGender.Text = Individual.Gender;

			tbJoinedMethod.Text = Individual.JoinedMethod;
			tbJoinedDate.Value = Individual.JoinedDate;
			tbBaptismLocation.Text = Individual.BaptizedLocation;
			tbBaptismDate.Value = Individual.BaptizedDate;
			tbMaritalStatus.Text = Individual.MaritalStatus;
			tbMarriageDate.Value = Individual.MarriedDate;

			cbActive.Checked = Individual.Active;

			tbFirstName.Focus();
			tbFirstName.SelectAll();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Individual.FirstName = tbFirstName.Text;
			Individual.MiddleName = tbMiddleName.Text;
			Individual.LastName = tbLastName.Text;

			Individual.Phone = tbPhone.Text;
			Individual.Email = tbEmail.Text;
			Individual.CommunicationPreference = tbCommunicationPreference.Text;

			Individual.Occupation = tbOccupation.Text;
			Individual.Employer = tbEmployer.Text;
			Individual.BirthDate = tbBirthDate.Value;
			Individual.Gender = tbGender.Text;

			Individual.JoinedMethod = tbJoinedMethod.Text;
			Individual.JoinedDate = tbJoinedDate.Value;
			Individual.BaptizedLocation = tbBaptismLocation.Text;
			Individual.BaptizedDate = tbBaptismDate.Value;
			Individual.MaritalStatus = tbMaritalStatus.Text;
			Individual.MarriedDate = tbMarriageDate.Value;

			Individual.Active = cbActive.Checked;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
