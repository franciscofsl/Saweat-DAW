namespace Saweat.Application.Validators.Entities.Bookings;

public class UpdateBookingValidator : AbstractValidator<Booking>
{

    public UpdateBookingValidator()
    {
        RuleFor(s => s.CustomerEmail)
            .EmailAddress()
            .WithMessage("El formato del email es incorrecto o esta vacio: ejemplo@ejemplo.com");

        RuleFor(b => b.CustomerName)
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.");

        RuleFor(b => b.CustomerPhone)
            .NotEmpty()
            .WithMessage("El numero de telefono es obligatorio.");
    }
}
