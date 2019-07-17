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
	public partial class UsersList : BaseAuthenticatedDataForm
	{
		public UsersList()
		{
			InitializeComponent();
		}

		private void UsersList_Load(object sender, EventArgs e)
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

			lblRole.Text =
				string.Format("You Are {0}", oUser.Role.ToString());

			FillUserGridView(string.Empty);
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

		public void FillUserGridView(string search)
		{
			if (String.IsNullOrEmpty(search) || search == "Search here...")
			{
				var booksList =
					db.Users
					.Where(current => !current.IsDeleted || authenicatedUser.Role >= Domain.Enums.Role.Administrator)
					.OrderByDescending(current => current.SortNumber)
					.ThenByDescending(current => current.RegisterDate)
					.Select(current => new object[] {current.FirstName, current.LastName, current.Username, current.EmailAddress, current.PhoneNumber, current.Role.ToString() })
					.ToList();

				foreach (var item in booksList)
				{
					UsersGridView.Rows.Add(item);
				}
			}
			else
			{
				search = search.Trim().ToLower();

				var booksList =
					db.Users
					.Where(current => !current.IsDeleted || authenicatedUser.Role >= Domain.Enums.Role.Administrator)
					.Where(current => current.FirstName.Trim().ToLower().Contains(search) || current.LastName.Trim().ToLower().Contains(search) || current.Username.Trim().ToLower().Contains(search) || (!String.IsNullOrEmpty(current.EmailAddress) && current.EmailAddress.Trim().ToLower().Contains(search))
						|| (!String.IsNullOrEmpty(current.PhoneNumber) && current.PhoneNumber.Trim().ToLower().Contains(search)) || current.Role.ToString().Trim().ToLower().Contains(search))
					.OrderByDescending(current => current.SortNumber)
					.ThenByDescending(current => current.RegisterDate)
					.Select(current => new object[] { current.FirstName, current.LastName, current.Username, current.EmailAddress, current.PhoneNumber, current.Role.ToString() })
					.ToList();
				foreach (var item in booksList)
				{
					UsersGridView.Rows.Add(item);
				}
			}
		}
		public void RemoveAllUserGridView()
		{
			UsersGridView.Rows.Clear();
		}

		private void BtnLogout_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are Sure You Want To Logout ?!", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Login oLoginForm = new Login();
				oLoginForm.Show();
				this.Close();
			}
		}

		private void ShowAllClick_Click(object sender, EventArgs e)
		{
			RemoveAllUserGridView();
			FillUserGridView(string.Empty);
			Searchtxt.Text = "Search here...";
		}

		private void Searchtxt_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Searchtxt.Text) && Searchtxt.Text != "Search here..." && Searchtxt.Text.Count() > 2)
			{
				RemoveAllUserGridView();
				FillUserGridView(Searchtxt.Text);
			}
			else
			{
				RemoveAllUserGridView();
				FillUserGridView(string.Empty);
			}

		}

		private void UsersGridView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string strSelectedUsername = UsersGridView.Rows[UsersGridView.CurrentRow.Index].Cells[2].Value.ToString();

			if (!string.IsNullOrEmpty(strSelectedUsername))
			{
				Domain.Entities.User oUser =
				db.Users.Where(current => current.Username == strSelectedUsername)
				.FirstOrDefault();
				if (oUser != null)
				{
					if (oUser.Role <= authenicatedUser.Role)
					{
						db.Entry(oUser).Reload();

						UserDetail UserDetailForm = new UserDetail();
						UserDetailForm.setUser(oUser);
						UserDetailForm.SetAuthenicatedUser(authenicatedUser);
						UserDetailForm.Show();
					}	
				}
			}

		}

		private void UsersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void UsersList_Enter(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Searchtxt.Text) && Searchtxt.Text != "Search here..." && Searchtxt.Text.Count() > 2)
			{
				RemoveAllUserGridView();
				FillUserGridView(Searchtxt.Text);
			}
			else
			{
				RemoveAllUserGridView();
				FillUserGridView(string.Empty);
			}
		}
	}
}
