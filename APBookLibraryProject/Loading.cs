using APBookLibraryProject.Domain.Entities;
using APBookLibraryProject.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace APBookLibraryProject
{
	public partial class Loading : Form
	{
		private bool _databaseCreatedSuccessfuly { get; set; }
		public Timer MainTimer { get; set; }

		public Loading()
		{
			_databaseCreatedSuccessfuly = false;
			InitializeComponent();
			
		}

		public void t_Tick(object sender, EventArgs e)
		{	
			MainTimer.Enabled = false;
			if (_databaseCreatedSuccessfuly)
			{
				Login oLoginForm = new Login();
				oLoginForm.Show();
				this.Hide();
			}
		}

		private void Loading_Load(object sender, EventArgs e)
		{
			DatabaseContext databaseContextCreated = new DatabaseContext();

			try
			{
				bool _databaseInitilized = databaseContextCreated.Database.EnsureCreated();
				if (_databaseInitilized && (!databaseContextCreated.Users.Any() || !databaseContextCreated.ApplicationSettings.Any()))
				{
					ApplicationSetting oApplicationSetting = new ApplicationSetting()
					{
						LibraryName = "Library Number " + Utility.RandomDoubleCodeGeneratorByDigitsCount(2).ToString(),
						LibraryRegisterdInWS = false,
						LibraryAuthCode = string.Empty,
					};

					User oUser = new User()
					{
						FirstName = "Zahra",
						LastName = "Nabizzz",
						Username = oApplicationSetting.LibraryName.Trim().Replace("  "," ").Replace(" ", "").ToLower(),
						PhoneNumber = "09372302283",
						PhoneNumberIsoCode = "IR",
						EmailAddress = "zaziz@gmail.com",
						Role = Domain.Enums.Role.Administrator,
						Password = Hashing.GetSha256("123456789"),
						IsPhoneNumberVerified = true,
						IsEmailAddressVerified = true,
					};
					databaseContextCreated.Users.Add(oUser);
					databaseContextCreated.SaveChanges();
			
					databaseContextCreated.ApplicationSettings.Add(oApplicationSetting);
					databaseContextCreated.SaveChanges();
				}
				_databaseCreatedSuccessfuly = true;
			}
			catch (Exception ex)
			{
				DialogResult result = MessageBox.Show("DatabaseCreationProcess Error With Detail : \n \n" + ex.Message, "Database Error!", MessageBoxButtons.OK);
				if (result == DialogResult.OK)
				{
					MessageBoxOkClick();
				}
			}

			LibraryManagmentConnectSDK.ConnectionSetting.SetupConnectionChannel("localhost:5000");
			if (!LibraryManagmentConnectSDK.ConnectionSetting.ConnectedToServer)
			{
				MessageBox.Show("Couldnt Connect To The Library Managment System !", "Connection Error!", MessageBoxButtons.OK);
			}
			if (!Utility.GetApplicationSetting().LibraryRegisterdInWS)
			{
				if (!LibraryManagmentConnectSDK.ConnectionSetting.ConnectedToServer)
				{
					DialogResult result = MessageBox.Show("Couldnt Connect To The Library Managment System \n For The First Time You Should Connect To WS Server \n Try Agin!", "Connection Error!", MessageBoxButtons.OK);
					if (result == DialogResult.OK)
					{
						MessageBoxOkClick();
					}
				}
				else
				{
					LibraryManagmentConnectSDK.ServerConnection oServerConnection = new LibraryManagmentConnectSDK.ServerConnection();
					LibraryManagmentConnectSDK.LibraryRegisterReply oRegistreationReply =
						oServerConnection.LibraryRegister(new LibraryManagmentConnectSDK.LibraryRegisterRequest { Name = Utility.GetApplicationSetting().LibraryName});
					if (oRegistreationReply == null || oRegistreationReply.IsSuccessfull == false)
					{
						DialogResult result = MessageBox.Show("Couldnt Register This Library To The Library Managment System \n For The First Time You Should Register To WS Server \n Try Agin! \n With Error : " 
							+ ((oRegistreationReply == null)? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oRegistreationReply?.ErrorType).ToString()), "Registration Error!", MessageBoxButtons.OK);
						if (result == DialogResult.OK)
						{
							MessageBoxOkClick();
							return;
						}
					}

					Domain.Entities.User oAdminUser =
						databaseContextCreated.Users.Where(current => current.Username == Utility.GetApplicationSetting().LibraryName.Trim().Replace("  ", " ").Replace(" ", "").ToLower())
						.FirstOrDefault();
					if (oAdminUser == null)
					{
						DialogResult result = MessageBox.Show("Couldnt Connect To The Library Managment System \n For The First Time You Should Connect To WS Server \n Try Agin!", "Connection Error!", MessageBoxButtons.OK);
						if (result == DialogResult.OK)
						{
							MessageBoxOkClick();
							return;
						}
					}

					oServerConnection.SetLibrary(oRegistreationReply.AuthCode);

					LibraryManagmentConnectSDK.AddUserRequest oAddUserRequest =
						new LibraryManagmentConnectSDK.AddUserRequest
						{
							FirstName = oAdminUser.FirstName,
							LastName = oAdminUser.LastName,
							Username = oAdminUser.Username,
							EmailAddress = oAdminUser.EmailAddress,
							PhoneNumber = oAdminUser.PhoneNumber,
							Password = oAdminUser.Password,
							PhoneNumberIsoCode = oAdminUser.PhoneNumberIsoCode,
							Role = (int)oAdminUser.Role,
						};

					LibraryManagmentConnectSDK.AddUserReply oAddUserReply =
						oServerConnection.AddUser(oAddUserRequest);
					if (oAddUserReply == null || oAddUserReply.IsSuccessfull == false)
					{
						DialogResult result = MessageBox.Show("Couldnt Register This User To The Library Managment System \n For The Signup Process You Should Connect To WS Server, Try Agin! \n With Error : "
							+ oAddUserReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oAddUserReply.ErrorType).ToString(), "Registration Error!", MessageBoxButtons.OK);
						if (result == DialogResult.OK)
						{
							MessageBoxOkClick();
							return;
						}
					}

					oAdminUser.ConnectedToWS = true;
					oAdminUser.WSAuthCode = oAddUserReply.UserAuthCode;

					Domain.Entities.ApplicationSetting oApplicationSetting
						= databaseContextCreated.ApplicationSettings.OrderByDescending(current => current.RegisterDate).FirstOrDefault();
					oApplicationSetting.LibraryRegisterdInWS = true;
					oApplicationSetting.LibraryAuthCode = oRegistreationReply.AuthCode;

					databaseContextCreated.Entry(oAdminUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					databaseContextCreated.Entry(oApplicationSetting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					databaseContextCreated.SaveChanges();
					Utility.UpdateApplicationSetting();

				}
			}

			MainTimer = new Timer();
			MainTimer.Interval = 2000;
			MainTimer.Enabled = true;
			MainTimer.Tick += new EventHandler(t_Tick);
		}
		public void MessageBoxOkClick()
		{
			this.Dispose();
			Application.Exit();
		}
	}
}