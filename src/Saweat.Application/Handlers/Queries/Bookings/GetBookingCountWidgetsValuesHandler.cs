﻿using Saweat.Domain.Enums;
using Saweat.Domain.Utils;

namespace Saweat.Application.Handlers.Queries.Bookings;

public class GetBookingCountWidgetsValuesHandler : IRequestHandler<GetBookingCountWidgetsValuesRequest, Response<BookingCountWidget>>
{
    private readonly IRepository<Booking> _repository;

    public GetBookingCountWidgetsValuesHandler(IRepository<Booking> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<BookingCountWidget>> Handle(GetBookingCountWidgetsValuesRequest request, CancellationToken cancellationToken)
    {
        var bookings = (await _repository.GetAllAsync(b => b.StartDate >= DateTime.Now, token: cancellationToken)).ToArray();
        var bookingCount = new BookingCountWidget
        {
            TodayBookings = bookings.Count(b => b.State == BookingState.Approved && b.StartDate == DateTime.Now),
            TodayCancels = bookings.Count(b => b.State == BookingState.Cancel && b.StartDate == DateTime.Now),
            NextBookings = bookings.Count(b => b.State == BookingState.Approved && b.StartDate >= DateTime.Now),
            PendingBookings = bookings.Count(b => b.State == BookingState.Pending && b.StartDate <= DateTime.Now.AddDays(14)),
            NextCancels =  bookings.Count(b => b.State == BookingState.Cancel && b.StartDate <= DateTime.Now.AddDays(14))
        };
        return Response<BookingCountWidget>.CreateResponse(bookingCount);
    }
}