using Saweat.Domain.Enums;

namespace Saweat.Application.Handlers.Queries.Bookings;

public class GetBookingsByStateHandler : IRequestHandler<GetBookingsByStateRequest, Response<IEnumerable<Booking>>>
{
    private readonly IRepository<Booking> _repository;

    public GetBookingsByStateHandler(IRepository<Booking> repository)
    {
        _repository = repository;
    }

    public async Task<Response<IEnumerable<Booking>>> Handle(GetBookingsByStateRequest request, CancellationToken cancellationToken)
    {
        return request.State == BookingState.Undefinied
            ? Response<IEnumerable<Booking>>.CreateResponse(await _repository.GetAllAsync(token: cancellationToken))
            : Response<IEnumerable<Booking>>.CreateResponse(await _repository.GetAllAsync(filter: b => b.State == request.State, token: cancellationToken));
    }
}
