using FluentValidation;
using System.Text.RegularExpressions;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Create
{
    public class CreateTelephoneDirectoryValidator : AbstractValidator<CreateTelephoneDirectoryCommand>
    {
        public CreateTelephoneDirectoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull().WithMessage("Telefon numarası gereklidir.")
                .MinimumLength(10).WithMessage("Eksik telefon numarası girdiniz!")
                .MaximumLength(10).WithMessage("Başında sıfır olmadan deneyiniz!");
                


        }
    }
}

