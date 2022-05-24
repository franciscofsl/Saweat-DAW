using Saweat.Application.Validators.Entities.Bookings;

namespace Saweat.Application.Test.Handlers.Commands.Bookings;

public class UpdateBookingCommandTest
{
    [Fact]
    public async Task Create_valid_booking()
    {
        var booking = new Booking
        {
            CustomerEmail = "mail@mail.com",
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        }; 
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var repository = TestServices.GetMockRepository(Array.Empty<OpeningPeriod>());
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator(repository));
        var response = await handler.Handle(new UpdateBookingRequest{Booking = booking}, default);
        response.ValidationErrors.Should().BeEmpty();
    }

    [Fact]
    public async Task Create_booking_return_error_with_empty_email()
    { 
        var booking = new Booking
        {
            CustomerEmail = string.Empty,
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        }; 
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var repository = TestServices.GetMockRepository(Array.Empty<OpeningPeriod>());
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator(repository));
        var response = await handler.Handle(new UpdateBookingRequest { Booking = booking }, default); 
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El formato del email es incorrecto o esta vacio: ejemplo@ejemplo.com");
    }

    [Fact]
    public async Task Create_booking_return_error_with_invalid_email()
    {
        var booking = new Booking
        {
            CustomerEmail = "asdasd",
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        }; 
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var repository = TestServices.GetMockRepository(Array.Empty<OpeningPeriod>());
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator(repository));
        var response = await handler.Handle(new UpdateBookingRequest { Booking = booking }, default);
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El formato del email es incorrecto o esta vacio: ejemplo@ejemplo.com");
    }

    [Fact]
    public async Task Create_booking_return_error_with_empty_customer_name()
    {
        var booking = new Booking
        {
            CustomerEmail = "mail@mail.com",
            CustomerPhone = "5476541"
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var repository = TestServices.GetMockRepository(Array.Empty<OpeningPeriod>());
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator(repository));
        var response = await handler.Handle(new UpdateBookingRequest { Booking = booking }, default);
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El nombre es obligatorio.");
    }

    [Fact]
    public async Task Create_booking_return_error_with_empty_customer_phone()
    {
        var booking = new Booking
        {
            CustomerEmail = "email@email.com",
            CustomerName = "Fran",
            CustomerPhone = string.Empty
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var repository = TestServices.GetMockRepository(Array.Empty<OpeningPeriod>());
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator(repository));
        var response = await handler.Handle(new UpdateBookingRequest { Booking = booking }, default);
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("El numero de telefono es obligatorio.");
    }

    [Fact]
    public async Task Update_existing_booking()
    { 
        var booking = new Booking
        {
            CustomerEmail = "mail@mail.com",
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var repository = TestServices.GetMockRepository(Array.Empty<OpeningPeriod>());
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator(repository));
        await handler.Handle(new UpdateBookingRequest { Booking = booking }, default);
        booking.BookingId = 1;
        await handler.Handle(new UpdateBookingRequest { Booking = booking }, default);
    }

    [Fact]
    public async Task Create_booking_out_of_opening_period_return_error()
    {
        var periods = new OpeningPeriod[]
        {
            new OpeningPeriod
            {
                StartHour = new TimeSpan(15, 0, 0),
                EndHour = new TimeSpan(17, 0, 0),
                Day = DayOfWeek.Friday
            }
        };
        var booking = new Booking
        {
            CustomerEmail = "email@email.com",
            CustomerName = "Fran",
            CustomerPhone = "987498",
            StartDate = new DateTime(2022, 5, 20, 10, 0, 0)
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var repository = TestServices.GetMockRepository(periods);
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator(repository));
        var response = await handler.Handle(new UpdateBookingRequest { Booking = booking }, default);
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("No se puede solicitar una reserva fuera del horario de apertura.");
    }
}