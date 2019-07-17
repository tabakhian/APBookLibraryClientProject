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
	public partial class EditBook : BaseAuthenticatedDataForm
	{
		public String ImagePath { get; set; }
		public Domain.Entities.Book Book { get; set; }
		public EditBook()
		{
			ImagePath = string.Empty;
			InitializeComponent();
		}
		public void setBook(Domain.Entities.Book book)
		{
			Book = book;
		}

		private void EditBook_Load(object sender, EventArgs e)
		{
			if (Book.IsDeleted)
			{
				if (authenicatedUser.Role < Domain.Enums.Role.Administrator)
				{
					this.Close();
				}
			}

			Nametxt.Text = Book.Name;
			Authoretxt.Text = Book.Author;
			Translatortxt.Text = Book.Translator;
			Publishertxt.Text = Book.Publisher;
			PublishedDatetxt.Text = Book.PublishedDate.ToString();
			Circulationtxt.Text = Book.Circulation;
			Pricetxt.Text = Book.Price.ToString();
			ISBNtxt.Text = Book.ISBN;
			if (Book.HasImage)
			{
				AddImageClick.Text = "Change Image";
				pictureBook.Image = Infrastructure.ImageUtils.GetThumbnailByImagePath("c:\\BookLibraryData\\Book-" + Book.Id.ToString() + "\\" + "Image.jpg", 135, 135);
				pictureBook.Visible = true;
			}

			string TextPath = "c:\\BookLibraryData\\Book-" + Book.Id.ToString();
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
					BookTextRichBox.Text = "Book Text isnt Available! Write SomeThings...";
				}
				else
				{
					StreamReader read = new StreamReader(TextFullPath);
					BookTextRichBox.Text = read.ReadToEnd();
					read.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An Unknown error has occurred : \n \n" + ex.Message, "File Error!", MessageBoxButtons.OK);
				this.Close();
			}

		}

		private void AddImageClick_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog open = new OpenFileDialog())
			{
				open.Title = "select Image";
				open.Filter = "Image Files (*.bmp;* .jpg;*.jpeg , * .png) | * .BMP ;*.JPG; * .JPEG ; * .PNG ";
				DialogResult result = openFileDialog1.ShowDialog();
				if (result == DialogResult.OK)
				{
					ImagePath = openFileDialog1.FileName;
					var ImagePathPart =
						ImagePath.Split('\\').ToList();
					if (ImagePathPart != null && ImagePathPart.Any())
					{
						string strImageName =
							ImagePathPart.Last();
						lblImagePath.Text = strImageName;
					}

					pictureBook.Image = Infrastructure.ImageUtils.GetThumbnailByImagePath(ImagePath, 135, 135);
					pictureBook.Visible = true;
					AddImageClick.Text = "Change Image";
				}
				else
				{
					MessageBox.Show("An Error accrued in Selecting Image File ! try agin !", "Error In Selecting Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void EditClick_Click(object sender, EventArgs e)
		{
			int PulishDate = 0;
			double Price = 0;
			if (!int.TryParse(PublishedDatetxt.Text, out PulishDate))
			{
				MessageBox.Show("You Shuold Enter PublishDate In Number Format!", "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (!double.TryParse(Pricetxt.Text, out Price))
			{
				MessageBox.Show("You Shuold Enter Price In Number Format!", "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			ViewModels.BookInput oBookInput =
				new ViewModels.BookInput()
				{
					Name = Nametxt.Text,
					Author = Authoretxt.Text,
					Translator = Translatortxt.Text,
					Publisher = Publishertxt.Text,
					PublishedDate = PulishDate,
					Circulation = Circulationtxt.Text,
					Price = Price,
					ISBN = ISBNtxt.Text,
				};
			FluentValidation.Results.ValidationResult validationResult = Utility.GeneralViewModelValidator
			<ViewModels.BookInput, Validations.BookInoutValidator>(oBookInput);
			if (!validationResult.IsValid)
			{
				string error_message = validationResult.ToString();
				MessageBox.Show(error_message, "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (db.Books.Where(current => current.Name == oBookInput.Name.Trim().ToLower() && current.Id != Book.Id ).Any())
			{
				string error_message = validationResult.ToString();
				MessageBox.Show("A book registerd with this 'Name' Before, Please choose a new one!", "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Domain.Entities.Book oBookInNewContext =
					db.Books.Find(Book.Id);
			if (oBookInNewContext == null)
			{
				MessageBox.Show("The Book is not Avaiable For Editing!", "Book Load Error!", MessageBoxButtons.OK);
				this.Close();
			}
			if (oBookInNewContext.IsDeleted)
			{
				if (authenicatedUser.Role < Domain.Enums.Role.Administrator)
				{
					this.Close();
				}
			}


			oBookInNewContext.Name = oBookInput.Name;
			oBookInNewContext.Author = oBookInput.Author;
			oBookInNewContext.Translator = oBookInput.Translator;
			oBookInNewContext.Publisher = oBookInput.Publisher;
			oBookInNewContext.PublishedDate = oBookInput.PublishedDate;
			oBookInNewContext.Circulation = oBookInput.Circulation;
			oBookInNewContext.Price = oBookInput.Price;
			oBookInNewContext.ISBN = oBookInput.ISBN;
			oBookInNewContext.IsEdited = true;
			oBookInNewContext.LastEditDate = System.DateTime.Now;
			oBookInNewContext.EditerUserId = authenicatedUser.Id;
		
			string BookText = BookTextRichBox.Text.ToString();
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
							
				StreamWriter Save = new StreamWriter(TextFullPath, false);
				Save.WriteLine(BookText);
				Save.Close();

				if (!string.IsNullOrEmpty(ImagePath))
				{
					Image oImage = Image.FromFile(ImagePath);
					if (oImage == null)
					{
						MessageBox.Show("This Selected Image is not Exists !", "Error In Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					if (oImage.Height < 100 || oImage.Width < 100)
					{
						MessageBox.Show("Selected Image Size is very small !", "Error Image Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					if (oImage.Height > 2000 || oImage.Width > 2000)
					{
						MessageBox.Show("Selected Image Size is very big !", "Error Image Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					if (File.Exists(TextPath + "\\" + "Image.jpg"))
					{
						File.Delete(TextPath + "\\" + "Image.jpg");
					}

					oImage.Save(TextPath + "\\" + "Image.jpg");
					oBookInNewContext.HasImage = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An Unknown error has occurred : \n \n" + ex.Message, "File Error!", MessageBoxButtons.OK);
				return;
			}


			db.Entry(oBookInNewContext).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			db.SaveChanges();

			var resault = MessageBox.Show("The Book Successfuly Edited!", "Book Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
			if (resault == DialogResult.OK)
			{
				this.Close();
			}
		}
	}
}
