namespace APBookLibraryProject.Domain.Entities
{
	public class Book : BaseEntity
	{

		public Book()
		{
			HasImage = false;
			IsEdited = false;
			UploadedToWS = false;
		}

		public bool UploadedToWS { get; set; }
		public string BookIdInWS { get; set; }

		public string Name { get; set; }

		public string Author { get; set; }//nevisandee

		public string Translator { get; set; }//motarjem

		public string Publisher { get; set; }//nasher

		public int PublishedDate { get; set; }//noobate chap

		public string Circulation { get; set; }//tirazh

		public double Price { get; set; }//gheymat

		public string ISBN { get; set; }

		public bool HasImage { get; set; }

		public virtual User UploaderUser { get; set; } //relation with user class
		public System.Guid? UploaderUserId { get; set; } // ? nonable

		public bool IsEdited { get; set; }
		public System.DateTime? LastEditDate { get; set; }
		public System.Guid? EditerUserId { get; set; }

	}
}