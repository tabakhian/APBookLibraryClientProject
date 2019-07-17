namespace APBookLibraryProject
{
	public class AuthenicatedUser
	{

		public AuthenicatedUser(Domain.Entities.User user)
		{
			Id = user.Id;
			FirstName = user.FirstName;
			LastName = user.LastName;
			EmailAddress = user.EmailAddress;
			PhoneNumber = user.PhoneNumber;
			Role = user.Role;
			ConnectedToWS = user.ConnectedToWS;
			WSAuthCode = user.WSAuthCode;
			LastLoginDate = System.DateTime.Now;
		}

		// **********
		public System.Guid Id { get; protected set; }
		// **********
		public bool ConnectedToWS { get; set; }
		public string WSAuthCode { get; set; }
		// **********
		public string FirstName { get; protected set; }
		// **********

		// **********
		public string LastName { get; protected set; }
		// **********

		// **********
		public string EmailAddress { get; protected set; }
		// **********

		// **********
		public string PhoneNumber { get; protected set; }

		public Domain.Enums.Role Role { get; protected set; }

		public System.DateTime LastLoginDate { get; set; }
	}
}
