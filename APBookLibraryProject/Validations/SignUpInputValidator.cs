using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBookLibraryProject.Validations
{
	public class SignUpInputValidator : AbstractValidator<ViewModels.SignUpInput>
	{
		public SignUpInputValidator()
		{
			RuleFor(current => current.FirstName).NotEmpty().Length(3,50);
			RuleFor(current => current.LastName).NotEmpty().Length(3,50);
			RuleFor(current => current.Username).NotEmpty().Length(3, 20);
			RuleFor(current => current.Password).NotEmpty().Length(8, 50);

			When(current => !string.IsNullOrEmpty(current.PhoneNumber), () => {

				RuleFor(current => current.PhoneNumber).NotEmpty();
				RuleFor(current => current.PhoneNumberIsoCode).NotEmpty();
				RuleFor(current => current).Must(PhoneNumberValidatorWithRegion).WithMessage("Your phone number should be in the standard format.");
			});

			When(current => !string.IsNullOrEmpty(current.EmailAddress), () => {
				RuleFor(current => current.EmailAddress).NotEmpty().Length(6, 100).EmailAddress();
			});	
		}

		public bool PhoneNumberValidatorWithRegion(ViewModels.SignUpInput model)
		{
			return (IsPhoneNumberValid(model.PhoneNumber, model.PhoneNumberIsoCode));
		}

		public static bool IsPhoneNumberValid(string phoneNumber, string countryCode)
		{
			PhoneNumbers.PhoneNumberUtil _phoneNumberUtil;
			_phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

			try
			{
				PhoneNumbers.PhoneNumber oPhoneNumber = _phoneNumberUtil.Parse(phoneNumber, countryCode);
				if (_phoneNumberUtil.IsValidNumberForRegion(oPhoneNumber, countryCode))
				{
					return (true);
				}
			}
			catch (Exception)
			{

			}

			return (false);
		}
	}

}
