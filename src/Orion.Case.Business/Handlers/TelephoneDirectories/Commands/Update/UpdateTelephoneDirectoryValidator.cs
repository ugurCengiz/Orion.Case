using FluentValidation;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Update
{
    public class UpdateTelephoneDirectoryValidator : AbstractValidator<UpdateTelephoneDirectoryCommand>
    {
        public UpdateTelephoneDirectoryValidator()
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
