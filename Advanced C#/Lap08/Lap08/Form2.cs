using System;
using System.Windows.Forms;

namespace Lap08
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ValidationName.Visible = false;
            ValidationEmail.Visible = false;
            ValidationHobbies.Visible = false;
            lblSuccess.Visible = false;

            bool valid = true;

            // Validate Name
            if (txtName.Text.Length < 5)
            {
                ValidationName.Visible = true;
                valid = false;
            } 
            // Validate Email
            if (!txtEmail.Text.Contains("@"))
            {
                ValidationEmail.Visible = true;
                valid = false;
            } 

            // Validate Hobbies
            if (!ChkFootball.Checked && !ChkTennis.Checked && !ChkSwimming.Checked)
            {
                ValidationHobbies.Visible = true;
                valid = false;
            }

            // Show success message if all valid
            if (valid)
            {
                lblSuccess.Visible = true;
            }
        }
    }
}
