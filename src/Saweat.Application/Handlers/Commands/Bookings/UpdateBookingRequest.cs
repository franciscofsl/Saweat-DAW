namespace Saweat.Application.Handlers.Commands.Bookings;

public class UpdateBookingRequest : IRequest<Response<Booking>>
{
    public Booking? Booking { get; set; }
}
