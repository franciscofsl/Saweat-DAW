﻿using FluentValidation.Validators;

namespace Saweat.Application.Validators.Entities.Bookings;

public class UpdateBookingValidator : AbstractValidator<Booking>
{
    private readonly IRepository<OpeningPeriod> _repository;

    public UpdateBookingValidator(IRepository<OpeningPeriod> repository)
    {
        this._repository = repository;
         
        this.RuleFor(s => s.CustomerEmail)
            .EmailAddress()
            .WithMessage("El formato del email es incorrecto o esta vacio: ejemplo@ejemplo.com");

        this.RuleFor(b => b.CustomerName)
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.");

        this.RuleFor(b => b.CustomerPhone)
            .NotEmpty()
            .WithMessage("El numero de telefono es obligatorio.");

        this.RuleFor(e => e)
            .MustAsync(BookingInValidPeriod)
            .WithMessage("No se puede solicitar una reserva fuera del horario de apertura.");
    }

    private async Task<bool> BookingInValidPeriod(Booking booking, CancellationToken token)
    { 
        var periods = await _repository.GetAllAsync(p => p.Day == booking.StartDate.DayOfWeek, token:token);
        if (periods.Any() == false)
        {
            return true;
        }
        return !periods.Any(p => booking.StartDate.Between(p.StartHour, p.EndHour) == false &&
                                 booking.EndDate.Between(p.StartHour, p.EndHour) == false);
    }
}