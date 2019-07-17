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
	public partial class WSBookDetail : BaseAuthenticatedDataForm
	{
		string BookWSId { get; set; }
		public LibraryManagmentConnectSDK.BookDetailReply BookDetailReply { get; set; }
		public WSBookDetail()
		{
			InitializeComponent();
		}
		public void setBook(string strId)
		{
			BookWSId = strId;
		}

		private void WSBookDetail_Load(object sender, EventArgs e)
		{
			btnRead.Enabled = false;
			btnInLibrary.Visible = false;
			btnInLibrary.Enabled = false;

			LibraryManagmentConnectSDK.BookDetailReply oReply =
				libraryManagerConnection.BookDetail(new LibraryManagmentConnectSDK.BookDetailRequest { BookId = BookWSId });
			if (oReply == null || !oReply.IsSuccessfull)
			{
				MessageBox.Show("An Error Occured in Get Book From The Server, Try Again ! \n With Error Message : "
					+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Get Book Error!", MessageBoxButtons.OK);
				this.Close();
				return;
			}

			BookDetailReply = oReply;

			if (oReply.HostLibrary)
			{
				btnInLibrary.Visible = true;
				btnInLibrary.Enabled = true;
				btnRentRequest.Visible = false;
				lblRentingStatus.Text = "The Is All Yours ...";			
				btnRead.Enabled = true;
			}
			if (oReply.CanRead)
			{
				btnRead.Enabled = true;
			}
			if (oReply.RentedThisBook)
			{
				btnRentRequest.Text = "Return This Book";
				lblRentingStatus.Text = "You Currently Owned The Book";
			}
			else
			{
				if (oReply.RentRequestedPendingNow)
				{
					btnRentRequest.Text = "Cancel Rent Request";
					lblRentingStatus.Text = "Your Rent Request On Pending";
				}
				else
				{
					lblRentingStatus.Text = "None, You Can Rent The Book";
					if (!string.IsNullOrEmpty(oReply.LastRentRequestedRejectedResponseContext))
					{
						lblLastResponseHead.Visible = true;
						lblLastResponse.Visible = true;
						lblLastResponse.Text = oReply.LastRentRequestedRejectedResponseContext;
					}			
				}
			}
		
			lblName.Text = oReply.Name;
			lblAuthor.Text = oReply.Author;
			lblTranslator.Text = oReply.Translator;
			lblPublishing.Text = oReply.Publisher;
			lblPublishDate.Text = oReply.PublishedDate.ToString();
			lblCir.Text = oReply.Circulation;
			LblPrice.Text = oReply.Price.ToString();
			lblISBN.Text = oReply.ISBN;
			checkOnline.Checked = true;
			lblLibrary.Text = oReply.LibraryName + (oReply.HostLibrary ? " (This Library)" : "");

			picBook.Image = Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(oReply.ImageData.ToByteArray())), 332, 436);
		}

		private void BtnRead_Click(object sender, EventArgs e)
		{
			if (BookDetailReply.HostLibrary)
			{
				Domain.Entities.Book oBook =
				db.Books.Where(current => current.Name == BookDetailReply.Name)
				.FirstOrDefault();
				if (oBook != null)
				{
					ReadBook ReadBookForm = new ReadBook();
					ReadBookForm.setBook(oBook);
					ReadBookForm.SetAuthenicatedUser(authenicatedUser);
					ReadBookForm.Show();
				}

			}
			else
			{
				if (BookDetailReply.RentedThisBook)
				{
					WSReadBook ReadBookForm = new WSReadBook();
					ReadBookForm.setBook(BookDetailReply.Text);
					ReadBookForm.SetAuthenicatedUser(authenicatedUser);
					ReadBookForm.Show();
				}		
			}
		}

		private void BtnRentRequest_Click(object sender, EventArgs e)
		{
			if (BookDetailReply.RentedThisBook)
			{
				LibraryManagmentConnectSDK.ReturnRentedBookReply oReturnReply =
					libraryManagerConnection.ReturnRentedBook(new LibraryManagmentConnectSDK.ReturnRentedBookRequest { RentId = BookDetailReply.RentId });
				if (oReturnReply == null || !oReturnReply.IsSuccessfull)
				{
					MessageBox.Show("An Error Occured in Return Book You Rented, Try Again ! \n With Error Message : "
						+ (oReturnReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReturnReply.ErrorType).ToString()), "Return Rented Book Error!", MessageBoxButtons.OK);
					this.Close();
					return;
				}

				BookDetailReply.RentedThisBook = false;
				BookDetailReply.RentId = string.Empty;
				lblRentingStatus.Text = "None, You Can Rent The Book";
				btnRentRequest.Text = "Renting This Book";
			}
			else
			{
				if (BookDetailReply.RentRequestedPendingNow)
				{
					LibraryManagmentConnectSDK.CancelRentRequestBookReply oCancelReply =
						libraryManagerConnection.CancelRentRequestBook(new LibraryManagmentConnectSDK.CancelRentRequestBookRequest { RentRequestId = BookDetailReply.RentRequestId });
					if (oCancelReply == null || !oCancelReply.IsSuccessfull)
					{
						MessageBox.Show("An Error Occured in Cancel Rent Requst You Sent, Try Again ! \n With Error Message : "
							+ (oCancelReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oCancelReply.ErrorType).ToString()), "Cancel Rent Requst Error!", MessageBoxButtons.OK);
						this.Close();
						return;
					}

					BookDetailReply.RentRequestedPendingNow = false;
					BookDetailReply.RentRequestId = string.Empty;
					lblRentingStatus.Text = "None, You Can Rent The Book";
					btnRentRequest.Text = "Renting This Book";
				}
				else
				{
					GetRequestContext oContextForm =
						new GetRequestContext();
					oContextForm.ParretForm = this;
					oContextForm.ShowDialog();

				}
			}
		}

		private void BtnInLibrary_Click(object sender, EventArgs e)
		{
			if (BookDetailReply.HostLibrary)
			{
				Domain.Entities.Book oBook =
				db.Books.Where(current => current.Name == BookDetailReply.Name)
				.FirstOrDefault();
				if (oBook != null)
				{
					BookDetail BookDetailForm = new BookDetail();
					BookDetailForm.setBook(oBook);
					BookDetailForm.SetAuthenicatedUser(authenicatedUser);
					BookDetailForm.Show();
					this.Close();
				}		
			}
		}

		public void GetRequestContextFormResult(string context)
		{
			LibraryManagmentConnectSDK.RentABookReply oRentReply =
						libraryManagerConnection.RentABook(new LibraryManagmentConnectSDK.RentABookRequest { BookId = BookDetailReply.BookId , Context = context });
			if (oRentReply == null || !oRentReply.IsSuccessfull)
			{
				MessageBox.Show("An Error Occured in Renting The book, Try Again ! \n With Error Message : "
					+ (oRentReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oRentReply.ErrorType).ToString()), "Rent The Book Error!", MessageBoxButtons.OK);
				this.Close();
				return;
			}

			BookDetailReply.RentedThisBook = false;
			BookDetailReply.RentId = string.Empty;
			BookDetailReply.RentRequestedPendingNow = true;
			BookDetailReply.RentRequestId = oRentReply.RentRequestId;

			btnRentRequest.Text = "Cancel Rent Request";
			lblRentingStatus.Text = "Your Rent Request On Pending";
		}
	}
}
