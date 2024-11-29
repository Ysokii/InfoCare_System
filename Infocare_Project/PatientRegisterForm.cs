using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Infocare_Project
{
    public partial class PatientRegisterForm : Form
    {
        public PatientRegisterForm()
        {
            InitializeComponent();
        }

        private void PatientRegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            // Create a new User object with all fields, including address components
            User newUser = new User
            {
                FirstName = FirstnameTxtbox.Text,
                LastName = LastNameTxtbox.Text,
                MiddleName = MiddleNameTxtbox.Text,
                Suffix = SuffixTxtbox.Text,
                Bdate = BdayDateTimePicker.Value,
                Sex = SexCombobox.SelectedItem?.ToString(),
                Username = UsernameTxtbox.Text,
                Password = PasswordTxtbox.Text,
                ConfirmPassword = ConfirmPasswordTxtbox.Text,
                ContactNumber = ContactNumberTxtbox.Text,

                // New Address Components
                HouseNo = HouseNoTxtbox.Text,
                Street = StreetTxtbox.Text,
                Barangay = BarangayTxtbox.Text,
                City = CityTxtbox.Text
            };

            // Validate the password and confirm password match
            if (newUser.Password != newUser.ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                // Save the new user to the database
                Database db = new Database();
                db.PatientReg1(newUser);

                MessageBox.Show("Registration successful!");

                // Open the PatientBasicInformationForm and pass relevant data
                var patientInfoForm = new PatientBasicInformationForm(newUser.Username, newUser.FirstName, newUser.LastName);
                patientInfoForm.Show();

                // Hide the current form
                this.Hide();
            }
            catch (Exception ex)
            {
                // Display error message
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
