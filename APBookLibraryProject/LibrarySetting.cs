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
	public partial class LibrarySetting : BaseAuthenticatedDataForm
	{
		public LibrarySetting()
		{
			InitializeComponent();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtName.Text) || txtName.Text.Length < 5 || txtName.Text.Length > 20)
			{
				MessageBox.Show("Your Name Lenghth Should Be Between 5 to 20 Character, Try a New Name!", "Data Input Error!", MessageBoxButtons.OK);
				return;
			}

			Domain.Entities.ApplicationSetting oApplicationSetting
					= db.ApplicationSettings.OrderByDescending(current => current.RegisterDate).FirstOrDefault();

			LibraryManagmentConnectSDK.LibraryEditReply oRegistreationReply =
						libraryManagerConnection.LibraryEdit(new LibraryManagmentConnectSDK.LibraryEditRequest {
							AuthCode = Utility.GetApplicationSetting().LibraryAuthCode,
							Name = txtName.Text,
						});
			if (oRegistreationReply == null || oRegistreationReply.IsSuccessfull == false)
			{
				DialogResult result = MessageBox.Show("Couldnt Edit This Library From The Library Managment System, Try Agin! \n With Error : "
					+ oRegistreationReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oRegistreationReply.ErrorType).ToString(), "Edit From Server Error!", MessageBoxButtons.OK);
				return;
			}

			oApplicationSetting.LibraryName = txtName.Text;

			db.Entry(oApplicationSetting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			db.SaveChanges();
			Utility.UpdateApplicationSetting();

			this.Close();
		}

		private void LibrarySetting_Load(object sender, EventArgs e)
		{
			txtName.Text = Utility.GetApplicationSetting().LibraryName;
			lblDate.Text = Utility.GetApplicationSetting().RegisterDate.ToString();
			checkWS.Checked = Utility.GetApplicationSetting().LibraryRegisterdInWS;
		}
	}
}
