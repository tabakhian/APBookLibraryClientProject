using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBookLibraryProject.ViewModels
{
	public class SignUpInput
	{
		public SignUpInput()
		{

		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumberIsoCode { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

	}
}
