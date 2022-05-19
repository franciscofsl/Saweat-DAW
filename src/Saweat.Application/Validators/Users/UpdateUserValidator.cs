using FluentValidation;

namespace Saweat.Application.Validators.Users;

public class UpdateUserValidator : AbstractValidator<ApplicationUser>
{
    public UpdateUserValidator()
    {
        this.RuleFor(U => U.Name)
            .NotEmpty()
            .WithMessage("El nombre del usuario es obligatorio");
        this.RuleFor(U => U.Lastnames)
            .NotEmpty()
            .WithMessage("Los apellidos del usuario son obligatorios");
    }
}