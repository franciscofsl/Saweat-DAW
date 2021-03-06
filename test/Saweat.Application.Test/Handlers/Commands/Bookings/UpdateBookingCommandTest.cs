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
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator());
        var response = await handler.Handle(new UpdateBookingRequest
        {
            Booking = booking
        }, default);
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
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator());
        var response = await handler.Handle(new UpdateBookingRequest
        {
            Booking = booking
        }, default);
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
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator());
        var response = await handler.Handle(new UpdateBookingRequest
        {
            Booking = booking
        }, default);
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
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator());
        var response = await handler.Handle(new UpdateBookingRequest
        {
            Booking = booking
        }, default);
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
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator());
        var response = await handler.Handle(new UpdateBookingRequest
        {
            Booking = booking
        }, default);
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
            CustomerPhone = "5476541",
            BookingId = 1
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>();
        var handler = new UpdateBookingHandler(unitOfWork, new UpdateBookingValidator());
        await handler.Handle(new UpdateBookingRequest
        {
            Booking = booking
        }, default);
    }
}
