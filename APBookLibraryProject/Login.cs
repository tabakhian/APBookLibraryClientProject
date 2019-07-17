using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
	public partial class Login : BaseDataForm
	{
		public Login()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			ViewModels.LoginInput oLoginInput =
				new ViewModels.LoginInput()
				{			
					Password = Passwordtxt.Text,
					Username = Usernametxt.Text,
				};

			FluentValidation.Results.ValidationResult validationResult = Utility.GeneralViewModelValidator
				<ViewModels.LoginInput, Validations.LoginInputValidator>(oLoginInput);
			if (!validationResult.IsValid)
			{
				string error_message = validationResult.ToString();
				MessageBox.Show(error_message, "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Domain.Entities.User oUser =
				db.Users.Where(current => current.Username == oLoginInput.Username.Trim().ToLower())
				.FirstOrDefault();
			if (oUser == null)
			{
				string error_message = validationResult.ToString();
				MessageBox.Show("Your Login Information is Not Correct! ☹️ Try Again!", "Incorrect Login Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (oUser.IsDeleted && oUser.Role < Domain.Enums.Role.Administrator)
			{
				string error_message = validationResult.ToString();
				MessageBox.Show("Your Login Information is Not Correct! ☹️ Try Again!", "Incorrect Login Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string hashPassword = Hashing.GetSha256(oLoginInput.Password);
			if (oUser.Password != hashPassword)
			{
				string error_message = validationResult.ToString();
				MessageBox.Show("Your Login Information is Not Correct! ☹️ Try Again!", "Incorrect Login Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            AuthenicatedUser oAuthenicatedUser = new AuthenicatedUser(oUser);

            //Domain.Entities.User oUsertest =
            //	db.Users.Where(current => current.Id == oAuthenicatedUser.Id)
            //	.FirstOrDefault();
            //if (oUsertest == null)
            //{

            //}
            //if (oUser.IsDeleted && oUser.Role < Domain.Enums.Role.Administrator)
            //{

            //}

            MainPage oLibraryFirstPageForm = new MainPage();
            oLibraryFirstPageForm.SetAuthenicatedUser(oAuthenicatedUser);
            oLibraryFirstPageForm.Show();

            this.Close();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			Signup signup = new Signup();
			signup.Show();
			this.Close();
		}

        private void Login_Load(object sender, EventArgs e)
        {
			Domain.Entities.User oAdminUser =
					db.Users.Where(current => current.Username.Contains("librarynumber"))
					.FirstOrDefault();
			if (oAdminUser != null)
			{
				Usernametxt.Text = oAdminUser.Username;
				Passwordtxt.Text = "123456789";
			}
		}
    }
}
