using APBookLibraryProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
	public class BaseAuthenticatedDataForm : Form
	{
		public DatabaseContext db { get; set; }
		public AuthenicatedUser authenicatedUser { get; set; }
		public LibraryManagmentConnectSDK.ServerConnection libraryManagerConnection { get; set; } 

        public BaseAuthenticatedDataForm()
        {
		
		}
        public void SetAuthenicatedUser(AuthenicatedUser authenicated)
        {
            db = new DatabaseContext();
            authenicatedUser = authenicated;

			if (!LibraryManagmentConnectSDK.ConnectionSetting.ConnectedToServer)
			{
				LibraryManagmentConnectSDK.ConnectionSetting.SetupConnectionChannel("localhost:5000");
			}

			libraryManagerConnection = new LibraryManagmentConnectSDK.ServerConnection();
			libraryManagerConnection.SetLibrary(Utility.GetApplicationSetting().LibraryAuthCode);
			libraryManagerConnection.SetUser(authenicatedUser.WSAuthCode);
		}
	
		public void Close() {
			db.Dispose();
			db = null;
			authenicatedUser = null;
			base.Close();
		}
	}
}
