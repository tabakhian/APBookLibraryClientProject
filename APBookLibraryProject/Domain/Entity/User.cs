using System.Collections.Generic;
namespace APBookLibraryProject.Domain.Entities
{
	public class User : BaseEntity
	{
		public User()
		{
			IsPhoneNumberVerified = false;
			IsEmailAddressVerified = false;
			Role = Enums.Role.User;
			Gender = Enums.Gender.Unspecified;
			UploadedBooks = new System.Collections.Generic.HashSet<Book>();
			ConnectedToWS = false;
			//null nabshe list ketab hayi ke user upload karde
		}
		public bool ConnectedToWS { get; set; }
		public string WSAuthCode { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string PhoneNumber { get; set; }
		public string PhoneNumberIsoCode { get; set; }

		public bool IsPhoneNumberVerified { get; set; }

		public System.DateTime? PhoneNumberVerificationDateTime { get; set; }

		public string EmailAddress { get; set; }

		public bool IsEmailAddressVerified { get; set; }

		public System.DateTime? EmailAddressVerificationDateTime { get; set; }

		public Domain.Enums.Gender Gender { get; set; }

		public Domain.Enums.Role Role { get; set; }

		public virtual System.Collections.Generic.ICollection<Book> UploadedBooks { get; set; }
		//relation with book class

	}
}
