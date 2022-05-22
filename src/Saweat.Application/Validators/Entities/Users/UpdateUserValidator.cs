namespace Saweat.Application.Validators.Entities.Users;

public class UpdateUserValidator : AbstractValidator<ApplicationUser>
{
    public UpdateUserValidator()
    {
        RuleFor(U => U.Name)
            .NotEmpty()
            .WithMessage("El nombre del usuario es obligatorio");
        RuleFor(u => u.Lastnames)
            .NotEmpty()
            .WithMessage("Los apellidos del usuario son obligatorios");
    }
}
