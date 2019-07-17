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
using APBookLibraryProject.Domain.Entities;
using APBookLibraryProject.Persistence;

namespace APBookLibraryProject
{
    public partial class AddBook : BaseAuthenticatedDataForm
    {
        public AddBook()
        {
            ImagePath = string.Empty;
            InitializeComponent();
        }
       
        public String ImagePath { get; set; }

        private void AddClick_Click(object sender, EventArgs e)
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
                    Circulation = Circulationtxt.Text ,
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

            if (db.Books.Where(current => current.Name == oBookInput.Name.Trim().ToLower()).Any())
            {
                string error_message = validationResult.ToString();
                MessageBox.Show("A book registerd with this 'Name' Before, Please choose a new one!", "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Domain.Entities.User oUser =
            db.Users.Where(current => current.Id == authenicatedUser.Id)
                .FirstOrDefault();
            if (oUser== null)
            {
                MessageBox.Show("An Error accrued in Your Authenication", "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oUser.IsDeleted && oUser.Role < Domain.Enums.Role.Administrator)
            {
                MessageBox.Show("An Error accrued in Your Authenication", "Error In Input Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
			Book oBook = new Book()
			{
				Name = oBookInput.Name,
				Author = oBookInput.Author,
				Translator = oBookInput.Translator,
				Publisher = oBookInput.Publisher,
				PublishedDate = oBookInput.PublishedDate,
				Circulation = oBookInput.Circulation,
				Price = oBookInput.Price,
				ISBN = oBookInput.ISBN,
                UploaderUser = oUser,
                UploaderUserId = oUser.Id,
            };
    

            string BookText = BookTextRichBox.Text.ToString();
            string TextPath = "c:\\BookLibraryData\\Book-" + oBook.Id.ToString();
            try
            {
                bool exists = Directory.Exists(TextPath);
                if (exists)
                {
                    Directory.Delete(TextPath, true);
                }
                Directory.CreateDirectory(TextPath);
                StreamWriter Save = new StreamWriter(TextPath + "\\" + "Text.txt", true);
                Save.WriteLine(BookText);
                Save.Close();
                if (!string.IsNullOrEmpty(ImagePath))
                {
                    Image oImage = Image.FromFile(ImagePath);
                    if (oImage == null)
                    {
                        MessageBox.Show("This Image is not Exists !", "Error In Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					if (oImage.Height < 100 || oImage.Width < 100)
                    {
                        MessageBox.Show("Image Size is very small !", "Error Image Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					if (oImage.Height > 2000 || oImage.Width > 2000)
                    {
                        MessageBox.Show("Image Size is very big !", "Error Image Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					oImage.Save(TextPath + "\\" + "Image.jpg");
					oBook.HasImage = true;

				}
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Unknown error has occurred : \n \n" + ex.Message, "File Error!", MessageBoxButtons.OK);
                return;
            }


            db.Books.Add(oBook);
            db.SaveChanges();

			var resault = MessageBox.Show("The Book Successfuly Added To Library!", "Book Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
			if (resault == DialogResult.OK)
			{
				this.Close();
			}
		}
     
        private void AddImage_Click(object sender, EventArgs e)
        {     
				openFileDialog1.Title = "select Image";
				openFileDialog1.Filter = "Image Files (*.bmp;* .jpg;*.jpeg , * .png) | * .BMP ;*.JPG; * .JPEG ; * .PNG ";
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

		private void AddBook_Load(object sender, EventArgs e)
		{

		}
	}
}
