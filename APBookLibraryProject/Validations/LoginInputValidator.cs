using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBookLibraryProject.Validations
{
	public class LoginInputValidator : AbstractValidator<ViewModels.LoginInput>
	{
		public LoginInputValidator()
		{	
			RuleFor(current => current.Username).NotEmpty().Length(3, 20);
			RuleFor(current => current.Password).NotEmpty().Length(8, 50);		
		}

	}

}
