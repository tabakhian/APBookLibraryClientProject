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
	public partial class MWSBooksList : BaseAuthenticatedDataForm
	{
		public MWSBooksList()
		{
			InitializeComponent();
			LoadTime = -1;
		}
		public int LoadTime { get; set; }
		public List<LibraryManagmentConnectSDK.BookDetailReply> CurrentBooksList { get; set; }
		private void MWSBooksList_Load(object sender, EventArgs e)
		{

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
				var SelectedBookId =
					CurrentBooksList.Where(current => current.Name == strSelectedName)
					.FirstOrDefault();
				if (SelectedBookId != null)
				{
					string strSelectedBookId = SelectedBookId.BookId;

					WSBookDetail BookDetailForm = new WSBookDetail();
					BookDetailForm.setBook(strSelectedBookId);
					BookDetailForm.SetAuthenicatedUser(authenicatedUser);
					BookDetailForm.Show();
				}

			}

		}

		public void FillBookGridView(string search)
		{
			LoadTime++;

			if (String.IsNullOrEmpty(search) || search == "Search here...")
			{
				LibraryManagmentConnectSDK.BookListReply oReply =
						libraryManagerConnection.BookList(new LibraryManagmentConnectSDK.BookListRequest() { });
				if (oReply == null || !oReply.IsSuccessfull)
				{
					if (LoadTime == 0)
					{
						MessageBox.Show("An Error Occured in Get Books List From The Server, Try Again And Click On Show All Buttun! \n With Error Message : "
							+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Get Books Error!", MessageBoxButtons.OK);
					}	
					return;
				}

				CurrentBooksList = oReply.Books.ToList();

				var booksList =
					CurrentBooksList
					.Select(current => new object[] { Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(current.ImageData.ToByteArray())), 45, 45), current.Name, current.LibraryName, current.Author, current.Translator, current.Publisher, current.Price.ToString() })
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
					CurrentBooksList
					.Where(current => current.Name.Trim().ToLower().Contains(search) || current.Author.Trim().ToLower().Contains(search) || current.Translator.Trim().ToLower().Contains(search) || current.Publisher.Trim().ToLower().Contains(search)
						|| current.PublishedDate.ToString().Trim().ToLower().Contains(search) || current.Circulation.Trim().ToLower().Contains(search) || current.Price.ToString().Trim().ToLower().Contains(search)
						|| (!string.IsNullOrEmpty(current.Text) && current.Text.ToString().Trim().ToLower().Contains(search)))
					.Select(current => new object[] { Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(current.ImageData.ToByteArray())), 45, 45), current.Name, current.LibraryName, current.Author, current.Translator, current.Publisher, current.Price.ToString() })
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

		private void Page_Activated(object sender, EventArgs e)
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

	}
}
