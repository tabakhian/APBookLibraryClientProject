using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APBookLibraryProject.Domain.Entities;
using APBookLibraryProject.Persistence;

namespace APBookLibraryProject
{
	
	public partial class Signup : BaseDataForm
	{
		public class Item
		{
			public Item() { }

			public string Value { set; get; }
			public string Text { set; get; }
		}


		public Signup()
		{
			InitializeComponent();
		}

		private void Signup_Load(object sender, EventArgs e)
		{
			List<Item> items = new List<Item>();
			items.Add(new Item() { Text = "+98", Value = "IR" });
			items.Add(new Item() { Text = "+971", Value = "AE" });
			items.Add(new Item() { Text = "+964", Value = "IQ" });
			items.Add(new Item() { Text = "+1", Value = "US" });

			comboBoxIsoCode.DataSource = items;
			comboBoxIsoCode.DisplayMember = "Text";
			comboBoxIsoCode.ValueMember = "Value";
			comboBoxIsoCode.SelectedIndex = 0;
		}

		private void Button4_Click(object sender, EventArgs e)
		{

			ViewModels.SignUpInput oSignUpInput =
				new ViewModels.SignUpInput()
				{
					FirstName = Nametxt.Text,
					LastName = LastNametxt.Text,
					EmailAddress = Emailtxt.Text,
					PhoneNumberIsoCode = comboBoxIsoCode.SelectedValue.ToString(),
					PhoneNumber = PhoneNumbertxt.Text,
					Password = Passwordtxt.Text,
					Username = Usernametxt.Text,
				};

			FluentValidation.Results.ValidationResult validationResult = Utility.GeneralViewModelValidator
				<ViewModels.SignUpInput, Validations.SignUpInputValidator>(oSignUpInput);
			if (!validationResult.IsValid)
			{
				string error_message = validationResult.ToString();
				MessageBox.Show(error_message, "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (db.Users.Where(current => current.Username == oSignUpInput.Username.Trim().ToLower()).Any())
			{
				string error_message = validationResult.ToString();
				MessageBox.Show("Someone registerd with this 'Username' Before, Please choose a new one!", "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (string.IsNullOrEmpty(oSignUpInput.PhoneNumber))
			{
				oSignUpInput.PhoneNumberIsoCode = string.Empty;
			}
			else
			{
				string strRawPhoneNumber = oSignUpInput.PhoneNumber.Trim().ToLower();
				string strRawCountryIso2Code = oSignUpInput.PhoneNumberIsoCode.Trim();
				PhoneNumbers.PhoneNumberUtil phoneNumberUtil;
					phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
				PhoneNumbers.PhoneNumber phoneNumber = phoneNumberUtil.Parse(strRawPhoneNumber, strRawCountryIso2Code);
				string strPhoneNumber = phoneNumberUtil.FormatOutOfCountryCallingNumber(phoneNumber, "IR");
				strPhoneNumber = strPhoneNumber.Replace("  ", " ");
				strPhoneNumber = strPhoneNumber.Replace(" ", "");
				oSignUpInput.PhoneNumber = strPhoneNumber;
			}

			if (!string.IsNullOrEmpty(oSignUpInput.EmailAddress))
			{
				oSignUpInput.EmailAddress = oSignUpInput.EmailAddress.Trim().ToLower();
			}

			oSignUpInput.Password = Hashing.GetSha256(oSignUpInput.Password);
			oSignUpInput.Username = oSignUpInput.Username.Trim().ToLower();

			User oUser = new User()
			{
				FirstName = oSignUpInput.FirstName,
				LastName = oSignUpInput.LastName,
				Username = oSignUpInput.Username,
				Password = oSignUpInput.Password,
				PhoneNumberIsoCode = oSignUpInput.PhoneNumberIsoCode,
				PhoneNumber = oSignUpInput.PhoneNumber,
				EmailAddress = oSignUpInput.EmailAddress,
			};

			if (!LibraryManagmentConnectSDK.ConnectionSetting.ConnectedToServer)
			{
				DialogResult result = MessageBox.Show("Couldnt Connect To The Library Managment System \n For The Signup Process You Should Connect To WS Server, Try Agin!", "Connection Error!", MessageBoxButtons.OK);
				return;
			}
			else
			{
				LibraryManagmentConnectSDK.ServerConnection oServerConnection = new LibraryManagmentConnectSDK.ServerConnection();
				LibraryManagmentConnectSDK.AddUserRequest oAddUserRequest =
					new LibraryManagmentConnectSDK.AddUserRequest()
					{
						FirstName = oUser.FirstName,
						LastName = oUser.LastName,
						Username = oUser.Username,
						EmailAddress =oUser.EmailAddress,
						PhoneNumber =oUser.PhoneNumber,
						Password = oUser.Password,
						PhoneNumberIsoCode = oUser.PhoneNumberIsoCode,
						Role = (int)oUser.Role,
						AuthCode = Utility.GetApplicationSetting().LibraryAuthCode,
					};

				LibraryManagmentConnectSDK.AddUserReply oRegistreationReply =
					oServerConnection.AddUser(oAddUserRequest);
				if (oRegistreationReply == null || oRegistreationReply.IsSuccessfull == false)
				{
					DialogResult result = MessageBox.Show("Couldnt Register This User To The Library Managment System \n For The Signup Process You Should Connect To WS Server, Try Agin! \n With Error : "
						+ oRegistreationReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oRegistreationReply.ErrorType).ToString(), "Registration Error!", MessageBoxButtons.OK);
					return;
				}

				oUser.ConnectedToWS = true;
				oUser.WSAuthCode = oRegistreationReply.UserAuthCode;
			}

			db.Users.Add(oUser);
			db.SaveChanges();

            AuthenicatedUser oAuthenicatedUser = new AuthenicatedUser(oUser);

            MainPage oLibraryFirstPageForm = new MainPage();
            oLibraryFirstPageForm.SetAuthenicatedUser(oAuthenicatedUser);
			oLibraryFirstPageForm.Show();

            this.Close();
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			Login oLoginForm = new Login();
			oLoginForm.Show();
			this.Close();
		}
	}
}
