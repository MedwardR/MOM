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
			tbBirthDate.Text = Individual.BirthDate?.ToString("MM/dd/yyyy");
			tbGender.Text = Individual.Gender;

			tbJoinedMethod.Text = Individual.JoinedMethod;
			tbJoinedDate.Text = Individual.JoinedDate?.ToString("MM/dd/yyyy");
			tbBaptismLocation.Text = Individual.BaptizedLocation;
			tbBaptismDate.Text = Individual.BaptizedDate?.ToString("MM/dd/yyyy");
			tbMaritalStatus.Text = Individual.MaritalStatus;
			tbMarriageDate.Text = Individual.MarriedDate?.ToString("MM/dd/yyyy");
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
			Individual.BirthDate = DateTime.TryParse(tbBirthDate.Text, out var birthday) ? birthday : null;
			Individual.Gender = tbGender.Text;

			Individual.JoinedMethod = tbJoinedMethod.Text;
			Individual.JoinedDate = DateTime.TryParse(tbJoinedDate.Text, out var joined) ? joined : null;
			Individual.BaptizedLocation = tbBaptismLocation.Text;
			Individual.BaptizedDate = DateTime.TryParse(tbBaptismDate.Text, out var baptism) ? baptism : null;
			Individual.MaritalStatus = tbMaritalStatus.Text;
			Individual.MarriedDate = DateTime.TryParse(tbMarriageDate.Text, out var marriage) ? marriage : null;

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
