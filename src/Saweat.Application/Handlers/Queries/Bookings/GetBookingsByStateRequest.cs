using Saweat.Domain.Enums;

namespace Saweat.Application.Handlers.Queries.Bookings;

public class GetBookingsByStateRequest : IRequest<Response<IEnumerable<Booking>>>
{
    public BookingState State { get; set; }
}
