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
	public partial class UserDetail : BaseAuthenticatedDataForm
	{
		public class Item
		{
			public Item() { }

			public string Value { set; get; }
			public string Text { set; get; }
		}

		public Domain.Entities.User User { get; set; }
		public UserDetail()
		{
			InitializeComponent();
		}

		public void setUser(Domain.Entities.User user)
		{
			User = user;
		}

		private void UserDetail_Load(object sender, EventArgs e)
		{
			List<Item> RoleItems = new List<Item>();
			RoleItems.Add(new Item() { Text = "User", Value = "0" });
			RoleItems.Add(new Item() { Text = "Supervisor", Value = "1" });
			RoleItems.Add(new Item() { Text = "Programmer", Value = "2" });
			RoleItems.Add(new Item() { Text = "Administrator", Value = "3" });

			comboRole.DataSource = RoleItems;
			comboRole.DisplayMember = "Text";
			comboRole.ValueMember = "Value";
			comboRole.SelectedIndex = (int)User.Role;

			///////////////////////////////////////

			lblFirstName.Text = User.FirstName;
			lblLastName.Text = User.LastName;
			lblUserName.Text = User.Username;
			lblEmail.Text = User.EmailAddress;
			lblPhone.Text = User.PhoneNumber;
			lblRole.Text = User.Role.ToString();
			LblGender.Text = User.Gender.ToString();

			var booksList =
					db.Books
					.Where(current => (!current.IsDeleted || authenicatedUser.Role >= Domain.Enums.Role.Administrator) && current.UploaderUserId == User.Id)
					.OrderByDescending(current => current.SortNumber)
					.ThenByDescending(current => current.RegisterDate)
					.Select(current => new object[] { Infrastructure.ImageUtils.GetThumbnailByImagePath("c:\\BookLibraryData\\Book-" + current.Id.ToString() + "\\" + "Image.jpg", 45, 45), current.Name, current.Author})
					.ToList();

			foreach (var item in booksList)
			{
				BooksGridView.Rows.Add(item);
			}


			if (authenicatedUser.Role >= Domain.Enums.Role.Administrator && authenicatedUser.Id != User.Id)
			{
				btnDelete.Enabled = true;
			}

			if (authenicatedUser.Role > User.Role)
			{
				btnChangeRole.Enabled = true;
				comboRole.Enabled = true;
			}
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

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are Sure You Want to Delete This User !?", "Deleting User", buttons: MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Domain.Entities.User oUserInNewContext =
					db.Users.Find(User.Id);
				if (oUserInNewContext != null)
				{
					if (authenicatedUser.Role >= Domain.Enums.Role.Administrator)
					{

						var booksList =
							db.Books
							.Where(current => (!current.IsDeleted || authenicatedUser.Role >= Domain.Enums.Role.Administrator) && current.UploaderUserId == oUserInNewContext.Id)						
							.ToList();

						foreach (var item in booksList)
						{
							db.Books.Remove(item);
						}

						db.Users.Remove(oUserInNewContext);
						db.SaveChanges();

					}

					this.Close();
				}

			}
		}

		private void BtnChangeRole_Click(object sender, EventArgs e)
		{
			if (authenicatedUser.Role > User.Role)
			{
				int SelectedRoleValue = (int)User.Role;
				if (!int.TryParse(comboRole.SelectedValue.ToString(), out SelectedRoleValue))
				{
					MessageBox.Show("Please Select Valid Role From ComboBox !", "Error In Changing Role", buttons: MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				Domain.Entities.User oUserInNewContext =
					db.Users.Find(User.Id);
				if (oUserInNewContext != null)
				{

					oUserInNewContext.Role = (Domain.Enums.Role)SelectedRoleValue;
					db.Entry(oUserInNewContext).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					db.SaveChanges();

					lblRole.Text = oUserInNewContext.Role.ToString();
					comboRole.SelectedIndex = (int)oUserInNewContext.Role;
					MessageBox.Show("User Role Updated !", "Changing Role", buttons: MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

			}			
		}
	}
}
