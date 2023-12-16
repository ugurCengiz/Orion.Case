using FluentValidation;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Create
{
    public class CreateTelephoneDirectoryValidator : AbstractValidator<CreateTelephoneDirectoryCommand>
    {
        public CreateTelephoneDirectoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}

