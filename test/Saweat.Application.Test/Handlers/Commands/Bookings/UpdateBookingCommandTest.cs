using System;
using Saweat.Domain.Enums;

namespace Saweat.Application.Test.Handlers.Commands.Bookings;

public class UpdateBookingCommandTest
{
    [Fact]
    public async Task Create_valid_booking()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var booking = new Booking
        {
            CustomerEmail = "mail@mail.com",
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        };
        var response = await mediator.Send(new UpdateBookingRequest { Booking = booking });
        response.Success.Should().BeTrue();
        await mediator.Send(new DeleteBookingRequest { Booking = booking });
    }

    [Fact]
    public async Task Create_booking_return_error_with_empty_email()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var booking = new Booking
        {
            CustomerEmail = string.Empty,
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        };
        var response = await mediator.Send(new UpdateBookingRequest { Booking = booking });
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El formato del email es incorrecto o esta vacio: ejemplo@ejemplo.com");
    }

    [Fact]
    public async Task Create_booking_return_error_with_invalid_email()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var booking = new Booking
        {
            CustomerEmail = "asdasd",
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        };
        var response = await mediator.Send(new UpdateBookingRequest { Booking = booking });
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El formato del email es incorrecto o esta vacio: ejemplo@ejemplo.com");
    }

    [Fact]
    public async Task Create_booking_return_error_with_empty_customer_name()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var booking = new Booking
        {
            CustomerEmail = "email@email.com",
            CustomerName = string.Empty,
            CustomerPhone = "5476541"
        };
        var response = await mediator.Send(new UpdateBookingRequest { Booking = booking });
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El nombre es obligatorio.");
    }

    [Fact]
    public async Task Create_booking_return_error_with_empty_customer_phone()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var booking = new Booking
        {
            CustomerEmail = "email@email.com",
            CustomerName = "Fran",
            CustomerPhone = string.Empty
        };
        var response = await mediator.Send(new UpdateBookingRequest { Booking = booking });
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El numero de telefono es obligatorio.");
    }

    [Fact]
    public async Task Update_existing_booking()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var booking = new Booking
        {
            CustomerEmail = "email@email.com",
            CustomerName = "Fran",
            CustomerPhone = "987498"
        };
        await mediator.Send(new UpdateBookingRequest { Booking = booking });
        booking.CustomerEmail = "new@correo.com";
        await mediator.Send(new UpdateBookingRequest { Booking = booking }); 
        await mediator.Send(new DeleteBookingRequest { Booking = booking });
    }

    [Fact]
    public async Task Create_booking_out_of_opening_period_return_error()
    { 
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var period = new OpeningPeriod
        {
            StartHour = new TimeSpan(15, 0, 0),
            EndHour = new TimeSpan(17, 0, 0),
            Day = DayOfWeek.Friday
        };
        await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = period });
        var booking = new Booking
        {
            CustomerEmail = "email@email.com",
            CustomerName = "Fran",
            CustomerPhone = "987498",
            StartDate = new DateTime(2022, 5, 20, 10, 0, 0)
        };
        var response = await mediator.Send(new UpdateBookingRequest { Booking = booking});
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("No se puede solicitar una reserva fuera del horario de apertura.");
    }
}