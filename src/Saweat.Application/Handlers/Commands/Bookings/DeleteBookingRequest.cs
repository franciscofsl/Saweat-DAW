namespace Saweat.Application.Handlers.Commands.Bookings;

public class DeleteBookingRequest : IRequest<Response<Booking>>
{
    public Booking? Booking { get; set; }
}
