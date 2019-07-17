using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
	public partial class BookDetail : BaseAuthenticatedDataForm
	{
		public Domain.Entities.Book Book { get; set; }
		public BookDetail()
		{
			InitializeComponent();
		}

		public void setBook(Domain.Entities.Book book)
		{
			Book = book;
		}
		private void BookDetail_Load(object sender, EventArgs e)
		{
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnUplaodWS.Enabled = false;
			if (authenicatedUser.Role > Domain.Enums.Role.User || Book.UploaderUserId == authenicatedUser.Id)
			{
				btnEdit.Enabled = true;
				btnDelete.Enabled = true;
			}
			if (authenicatedUser.Role >= Domain.Enums.Role.Administrator || Book.UploaderUserId == authenicatedUser.Id)
			{
				btnUplaodWS.Enabled = true;
			}

			if (Book.IsDeleted)
			{
				if (authenicatedUser.Role < Domain.Enums.Role.Administrator)
				{
					this.Close();
				}
				else
				{
					Domain.Entities.User oDeleterUser =
						db.Users.Find(Book.DeleterUserId);
					if (oDeleterUser != null)
					{
						lblDeletedData.Text = string.Format("This Book Was Deleted By {0} {1} With Username {2}, On {3}", oDeleterUser.FirstName, oDeleterUser.LastName, oDeleterUser.Username, Book.DeleteDate.Value.ToString());
					}
					else
					{
						lblDeletedData.Text = string.Format("This Book Was Deleted By UnAvailable User On {0}", Book.DeleteDate.Value.ToString());
					}
					lblDeletedData.Visible = true;
					btnRecover.Visible = true;
					btnDelete.Text = "Hard Delete";
				}
			}

			if (Book.IsEdited)
			{
				if (authenicatedUser.Role >= Domain.Enums.Role.Administrator)
				{
					Domain.Entities.User oEditerUser =
						db.Users.Find(Book.EditerUserId);
					if (oEditerUser != null)
					{
						lblEdited.Text = string.Format("This Book Was Edited By {0} {1} With Username {2}, On {3}", oEditerUser.FirstName, oEditerUser.LastName, oEditerUser.Username, Book.LastEditDate.Value.ToString());
					}
					else
					{
						lblEdited.Text = string.Format("This Book Was Edited By UnAvailable User On {0}", Book.LastEditDate.Value.ToString());
					}
					lblEdited.Visible = true;
				}
			}

			if (Book.UploadedToWS)
			{
				btnUplaodWS.Text = "Remove Online";
			}

			lblName.Text = Book.Name;
			lblAuthor.Text = Book.Author;
			lblTranslator.Text = Book.Translator;
			lblPublishing.Text = Book.Publisher;
			lblPublishDate.Text = Book.PublishedDate.ToString();
			lblCir.Text = Book.Circulation;
			LblPrice.Text = Book.Price.ToString();
			lblISBN.Text = Book.ISBN;
			checkOnline.Checked = Book.UploadedToWS;

			picBook.Image = Infrastructure.ImageUtils.GetThumbnailByImagePath("c:\\BookLibraryData\\Book-" + Book.Id.ToString() + "\\" + "Image.jpg", 245, 325);
		}

		private void BtnEdit_Click(object sender, EventArgs e)
		{
			if (authenicatedUser.Role > Domain.Enums.Role.User || Book.UploaderUserId == authenicatedUser.Id)
			{
				if (Book.IsDeleted)
				{
					if (authenicatedUser.Role < Domain.Enums.Role.Administrator)
					{
						this.Close();
					}
				}

				Domain.Entities.Book oBookInNewContext =
					db.Books.Find(Book.Id);
				if (oBookInNewContext != null)
				{
					db.Entry(oBookInNewContext).Reload();

					EditBook EditBookForm = new EditBook();
					EditBookForm.setBook(oBookInNewContext);
					EditBookForm.SetAuthenicatedUser(authenicatedUser);
					EditBookForm.Show();
				}
			}
			else
			{
				btnEdit.Enabled = false;
			}
		}

		private void BtnRead_Click(object sender, EventArgs e)
		{
			Domain.Entities.Book oBookInNewContext =
					db.Books.Find(Book.Id);
			if (oBookInNewContext != null)
			{
				db.Entry(oBookInNewContext).Reload();

				ReadBook ReadBookForm = new ReadBook();
				ReadBookForm.setBook(oBookInNewContext);
				ReadBookForm.SetAuthenicatedUser(authenicatedUser);
				ReadBookForm.Show();
			}
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Are Sure You Want to Delete This Book !?", "Deleting Book", buttons: MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Domain.Entities.Book oBookInNewContext =
					db.Books.Find(Book.Id);
				if (oBookInNewContext != null)
				{
					if (authenicatedUser.Role < Domain.Enums.Role.Administrator)
					{
						oBookInNewContext.IsDeleted = true;
						oBookInNewContext.DeleteDate = System.DateTime.Now;
						oBookInNewContext.DeleterUserId = authenicatedUser.Id;
						db.Entry(oBookInNewContext).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
						db.SaveChanges();
					}
					else
					{
						db.Books.Remove(oBookInNewContext);
						db.SaveChanges();

						string TextPath = "c:\\BookLibraryData\\Book-" + Book.Id.ToString();
						try
						{
							bool exists = Directory.Exists(TextPath);
							if (exists)
							{
								Directory.Delete(TextPath, true);
							}
						}
						catch (Exception)
						{

						}
					}

					this.Close();
				}

			}
		}

		private void BtnRecover_Click(object sender, EventArgs e)
		{
			if (authenicatedUser.Role < Domain.Enums.Role.Administrator)
			{
				this.Close();
			}

			var result = MessageBox.Show("Are Sure You Want to Recover This Book !?", "Recovering Book", buttons: MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Domain.Entities.Book oBookInNewContext =
					db.Books.Find(Book.Id);
				if (oBookInNewContext != null)
				{
					oBookInNewContext.IsDeleted = false;
					oBookInNewContext.DeleteDate = null;
					oBookInNewContext.DeleterUserId = null;
					db.Entry(oBookInNewContext).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					db.SaveChanges();

					this.BookDetail_Load(sender, e);
				}
			}
		}

		private void BtnUplaodWS_Click(object sender, EventArgs e)
		{
			if (authenicatedUser.Role >= Domain.Enums.Role.Administrator || Book.UploaderUserId == authenicatedUser.Id)
			{
				Domain.Entities.Book oBookInNewContext =
					   db.Books.Find(Book.Id);
				if (oBookInNewContext != null)
				{
					if (!oBookInNewContext.UploadedToWS)
					{
						LibraryManagmentConnectSDK.AddBookRequest oRequest =
						new LibraryManagmentConnectSDK.AddBookRequest()
						{
							Name = oBookInNewContext.Name,
							Author = oBookInNewContext.Author,
							Translator = oBookInNewContext.Translator,
							Publisher = oBookInNewContext.Publisher,
							PublishedDate = oBookInNewContext.PublishedDate,
							Circulation = oBookInNewContext.Circulation,
							HasImage = oBookInNewContext.HasImage,
							ISBN = oBookInNewContext.ISBN,
							Price = (long)oBookInNewContext.Price,
							ImageData = Google.Protobuf.ByteString.Empty,
							Text = string.Empty,
						};

						if (oRequest.HasImage)
						{
							var imageStream = Infrastructure.ImageUtils.GetPhoto("c:\\BookLibraryData\\Book-" + oBookInNewContext.Id.ToString() + "\\" + "Image.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
							imageStream.Seek(0, SeekOrigin.Begin);
							oRequest.ImageData =
								Google.Protobuf.ByteString.FromStream(imageStream);
						}

						string TextPath = "c:\\BookLibraryData\\Book-" + oBookInNewContext.Id.ToString();
						try
						{
							bool exists = Directory.Exists(TextPath);
							if (!exists)
							{
								Directory.CreateDirectory(TextPath);
							}
							string TextFullPath = TextPath + "\\" + "Text.txt";

							if (!File.Exists(TextFullPath))
							{
								File.CreateText(TextFullPath);
							}
							else
							{
								StreamReader read = new StreamReader(TextFullPath);
								oRequest.Text = read.ReadToEnd();
								read.Close();
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("An Unknown error has occurred : \n \n" + ex.Message, "File Error!", MessageBoxButtons.OK);
							this.Close();
						}

						LibraryManagmentConnectSDK.AddBookReply oReply =
							libraryManagerConnection.AddBook(oRequest);
						if (oReply == null || !oReply.IsSuccessfull)
						{
							MessageBox.Show("An Error Occured in Uploading Book To The Server, Try Agin! \n With Error Message : "
								+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Upload Book Error!", MessageBoxButtons.OK);
							return;
						}

						oBookInNewContext.UploadedToWS = true;
						oBookInNewContext.BookIdInWS = oReply.BookId;
						db.Entry(oBookInNewContext).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
						db.SaveChanges();

						btnUplaodWS.Text = "Remove Online";
						checkOnline.Checked = true;

						Book = oBookInNewContext;
					}
					else
					{
						LibraryManagmentConnectSDK.RemoveBookReply oReply =
							libraryManagerConnection.AddBook(new LibraryManagmentConnectSDK.RemoveBookRequest{ BookId = oBookInNewContext.BookIdInWS});
						if (oReply == null || !oReply.IsSuccessfull)
						{
							MessageBox.Show("An Error Occured in Removing Online Book From The Server, Try Agin! \n With Error Message : "
								+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Remove Online Book Error!", MessageBoxButtons.OK);
							return;
						}

						oBookInNewContext.UploadedToWS = false;
						oBookInNewContext.BookIdInWS = string.Empty;
						db.Entry(oBookInNewContext).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
						db.SaveChanges();

						btnUplaodWS.Text = "Upload";
						checkOnline.Checked = false;

						Book = oBookInNewContext;
					}
				}
			}
		}
	}
}
