using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBookLibraryProject.Validations
{
    class BookInoutValidator : AbstractValidator<ViewModels.BookInput>
    {
        public BookInoutValidator()
        {
            RuleFor(current => current.Name).NotEmpty().Length(1, 50);
            RuleFor(current => current.Author).NotEmpty().Length(3, 100);
			RuleFor(current => current.ISBN).NotEmpty().Length(8, 20);
			RuleFor(current => current.Translator).NotEmpty().Length(3, 100);
            RuleFor(current => current.Publisher).NotEmpty().Length(3, 100);
            RuleFor(current => current.PublishedDate).NotNull().LessThanOrEqualTo(100000).GreaterThanOrEqualTo(1);
            RuleFor(current => current.Circulation).NotEmpty().Length(1, 10);
            RuleFor(current => current.Price).NotNull().LessThanOrEqualTo(1000000).GreaterThanOrEqualTo(1000);
        }

    }
}
