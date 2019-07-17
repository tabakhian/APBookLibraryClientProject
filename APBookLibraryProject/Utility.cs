using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBookLibraryProject
{
	public static class Utility
	{
		public static FluentValidation.Results.ValidationResult GeneralViewModelValidator<ViewModelType, ValidatorType>(ViewModelType viewModel)
			where ValidatorType : FluentValidation.AbstractValidator<ViewModelType>, new()
		{

			ValidatorType oValidatorObject = new ValidatorType();

			return (oValidatorObject.Validate(viewModel));
		}

		public static Domain.Entities.ApplicationSetting GetApplicationSetting()
		{
			if (_applicationSetting == null)
			{
				lock (new object())
				{
					if (_applicationSetting == null)
					{
						using (var databaseContext = new Persistence.DatabaseContext())
						{
							_applicationSetting = databaseContext.ApplicationSettings.OrderByDescending(current => current.RegisterDate).FirstOrDefault();
							if (_applicationSetting == null)
							{
								_applicationSetting = new Domain.Entities.ApplicationSetting()
								{
									LibraryName = "FirstStepLibrary",
									LibraryRegisterdInWS = false,
									LibraryAuthCode = string.Empty,
								};

								databaseContext.ApplicationSettings.Add(_applicationSetting);
								databaseContext.SaveChanges();
							}
						}
					}
				}
			}
			return (_applicationSetting);
		}
		public static Domain.Entities.ApplicationSetting UpdateApplicationSetting()
		{
			_applicationSetting = null;

			if (_applicationSetting == null)
			{
				lock (new object())
				{
					if (_applicationSetting == null)
					{
						lock (new object())
						{

							using (var databaseContext = new Persistence.DatabaseContext())
							{
								_applicationSetting = databaseContext.ApplicationSettings.OrderByDescending(current => current.RegisterDate).FirstOrDefault();
								if (_applicationSetting == null)
								{
									_applicationSetting = new Domain.Entities.ApplicationSetting()
									{
										LibraryName = "FirstStepLibrary",
										LibraryRegisterdInWS = false,
										LibraryAuthCode = string.Empty,
									};

									databaseContext.ApplicationSettings.Add(_applicationSetting);
									databaseContext.SaveChanges();
								}
							}
						}
					}
				}
			}
			return (_applicationSetting);
		}
		private static Domain.Entities.ApplicationSetting _applicationSetting { get; set; }

		public static double RandomDoubleCodeGeneratorByDigitsCount(int digitsCount)
		{
			double doubleRandomNumber;
			var varRandom = new System.Random();
			string strMaxValue = string.Empty;
			int intMaxValue;
			for (int i = 0; i < digitsCount; i++)
			{
				strMaxValue += "9";
			}
			intMaxValue = Convert.ToInt32(strMaxValue);
			doubleRandomNumber = varRandom.Next(intMaxValue);
			doubleRandomNumber = varRandom.Next(intMaxValue);
			return doubleRandomNumber;
		}
	}
}
