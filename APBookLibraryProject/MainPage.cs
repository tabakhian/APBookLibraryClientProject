using APBookLibraryProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
    public partial class MainPage : BaseAuthenticatedDataForm
    {
		public MainPage()
        {
			InitializeComponent();
			string strText =
				Utility.GetApplicationSetting().LibraryName;
			this.Text = strText;
		}
		private void MainPage_Load(object sender, EventArgs e)
		{
			
			Domain.Entities.User oUser =
				db.Users.Find(authenicatedUser.Id);
			if (oUser == null)
			{
				MessageBox.Show("An Error occured in Your Authenication", "Error In Authenication", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Login oLoginForm = new Login();
				oLoginForm.Show();
				this.Close();
			}
			if (oUser.IsDeleted && oUser.Role < Domain.Enums.Role.Administrator)
			{
				MessageBox.Show("An Error occured in Your Authenication", "Error In Authenication", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Login oLoginForm = new Login();
				oLoginForm.Show();
				this.Close();
			}

			lblWelcome.Text =
				string.Format("Welcome {0} {1}", oUser.FirstName, oUser.LastName);
			btnLogout.Image =
				Infrastructure.ImageUtils.GetThumbnailByImagePath("c:\\BookLibraryData\\Default\\exit.png", 25, 25);

			if (authenicatedUser.Role > Domain.Enums.Role.User)
			{
				btnManageUsers.Visible = true;
			}
			if (authenicatedUser.Role >= Domain.Enums.Role.Administrator)
			{
				btnSettings.Visible = true;
			}
			if (authenicatedUser.ConnectedToWS)
			{
				btnWSBookList.Visible = true;
				btnBookRentingSystem.Visible = true;
			}

			FillBookGridView(string.Empty);

			Thread thread = new Thread(SetNewRequestBadgeData);
			thread.Start();
		}

		public void SetNewRequestBadgeData()
		{
			LibraryManagmentConnectSDK.BookRentingSystemNotificationCountReply oReply =
						libraryManagerConnection.BookRentingSystemNotificationCount(new LibraryManagmentConnectSDK.BookRentingSystemNotificationCountRequest { });
			if (oReply == null || !oReply.IsSuccessfull)
			{
				return;
			}

			Invoke(new Action(() =>
			{
				lblRequestCount.Text = oReply.NewRentRequestCount.ToString();
			}));

		}

		private void AddBookClick_Click(object sender, EventArgs e)
        {
            AddBook addBookShow = new AddBook();
            addBookShow.SetAuthenicatedUser(authenicatedUser);
			addBookShow.FormClosed += AddBookFormClosing;
			addBookShow.Show();
        }

		private void AddBookFormClosing(object sender, EventArgs e)
		{
			RemoveAllBookGridView();
			FillBookGridView(string.Empty);
			Searchtxt.Text = "Search here...";
		}

		public void SearchPlaceHolderRemoveText(object sender, EventArgs e)
		{
			if (Searchtxt.Text == "Search here...")
			{
				Searchtxt.Text = "";
			}
		}

		public void SearchPlaceHolderAddText(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(Searchtxt.Text))
				Searchtxt.Text = "Search here...";
		}

		private void BookGridView_SelectionChanged(object sender, EventArgs e)
		{
			string strSelectedName = BooksGridView.Rows[BooksGridView.CurrentRow.Index].Cells[1].Value.ToString();

			if (!string.IsNullOrEmpty(strSelectedName))
			{
				Domain.Entities.Book oBook =
				db.Books.Where(current => current.Name == strSelectedName)
				.FirstOrDefault();
				if (oBook != null)
				{
					db.Entry(oBook).Reload();

					BookDetail BookDetailForm = new BookDetail();
					BookDetailForm.setBook(oBook);
					BookDetailForm.SetAuthenicatedUser(authenicatedUser);
					BookDetailForm.Show();
				}
			}

		}

		public void FillBookGridView(string search)
		{
			if (String.IsNullOrEmpty(search) || search == "Search here...")
			{
				var booksList =
					db.Books
					.Where(current=>!current.IsDeleted || authenicatedUser.Role >= Domain.Enums.Role.Administrator)
					.OrderByDescending(current=>current.SortNumber)
					.ThenByDescending(current => current.RegisterDate)
					.Select(current => new object[] { Infrastructure.ImageUtils.GetThumbnailByImagePath("c:\\BookLibraryData\\Book-" + current.Id.ToString() + "\\" + "Image.jpg" ,45,45) ,current.Name,current.Author, current.Translator,current.Publisher, current.Price.ToString()})
					.ToList();
	
				foreach (var item in booksList)
				{					
					BooksGridView.Rows.Add(item);
				}
			}
			else
			{
				search = search.Trim().ToLower();
				var booksList =
					db.Books
					.Where(current => !current.IsDeleted || authenicatedUser.Role >= Domain.Enums.Role.Administrator)
					.Where(current=> current.Name.Trim().ToLower().Contains(search) || current.Author.Trim().ToLower().Contains(search) || current.Translator.Trim().ToLower().Contains(search) || current.Publisher.Trim().ToLower().Contains(search) 
						|| current.PublishedDate.ToString().Trim().ToLower().Contains(search) || current.Circulation.Trim().ToLower().Contains(search) || current.Price.ToString().Trim().ToLower().Contains(search))
					.OrderByDescending(current => current.SortNumber)
					.ThenByDescending(current => current.RegisterDate)
					.Select(current => new object[] { Infrastructure.ImageUtils.GetThumbnailByImagePath("c:\\BookLibraryData\\Book-" + current.Id.ToString() + "\\" + "Image.jpg", 45, 45), current.Name, current.Author, current.Translator, current.Publisher, current.Price.ToString() })
					.ToList();
				foreach (var item in booksList)
				{
					BooksGridView.Rows.Add(item);
				}
			}
		}
		public void RemoveAllBookGridView()
		{
			BooksGridView.Rows.Clear();
		}

		private void BtnLogout_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are Sure You Want To Logout ?!", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				List<Form> openForms = new List<Form>();

				foreach (Form f in Application.OpenForms)
					openForms.Add(f);

				Login oLoginForm = new Login();
				oLoginForm.Show();

				foreach (Form f in openForms)
				{
					if (f.Name != "Loading")
						f.Close();
				}
			}		
		}

		private void ShowAllClick_Click(object sender, EventArgs e)
		{
			RemoveAllBookGridView();
			FillBookGridView(string.Empty);
			Searchtxt.Text = "Search here...";
		}

		private void Searchtxt_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Searchtxt.Text) && Searchtxt.Text != "Search here..." && Searchtxt.Text.Count() > 2)
			{
				RemoveAllBookGridView();
				FillBookGridView(Searchtxt.Text);
			}
			else
			{
				RemoveAllBookGridView();
				FillBookGridView(string.Empty);
			}
	
		}

		private void BtnManageUsers_Click(object sender, EventArgs e)
		{
			UsersList UsersListFrom = new UsersList();
			UsersListFrom.SetAuthenicatedUser(authenicatedUser);
			UsersListFrom.Show();
		}

		private void MainPage_Activated(object sender, EventArgs e)
		{
			Thread thread = new Thread(SetNewRequestBadgeData);
			thread.Start();

			string strText =
				Utility.GetApplicationSetting().LibraryName;
			this.Text = strText;

			if (!string.IsNullOrEmpty(Searchtxt.Text) && Searchtxt.Text != "Search here..." && Searchtxt.Text.Count() > 2)
			{
				RemoveAllBookGridView();
				FillBookGridView(Searchtxt.Text);
			}
			else
			{
				RemoveAllBookGridView();
				FillBookGridView(string.Empty);
			}

		}

		private void BtnWSBookList_Click(object sender, EventArgs e)
		{
			MWSBooksList oMWSBooksList = new MWSBooksList();
			oMWSBooksList.SetAuthenicatedUser(authenicatedUser);
			oMWSBooksList.Show();
		}

		private void BtnBookRentingSystem_Click(object sender, EventArgs e)
		{
			WSRentingSystem oMWSRentingList = new WSRentingSystem();
			oMWSRentingList.SetAuthenicatedUser(authenicatedUser);
			oMWSRentingList.Show();
		}

		private void BtnSettings_Click(object sender, EventArgs e)
		{
			LibrarySetting oSettings = new LibrarySetting();
			oSettings.SetAuthenicatedUser(authenicatedUser);
			oSettings.Show();
		}

		private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
		{
			List<Form> openForms = new List<Form>();

			foreach (Form f in Application.OpenForms)
				openForms.Add(f);

			Login oLoginForm = new Login();
			oLoginForm.Show();

			foreach (Form f in openForms)
			{
					f.Close();
			}
		}
	}
}
