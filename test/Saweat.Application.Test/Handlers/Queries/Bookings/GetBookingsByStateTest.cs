using Saweat.Application.Handlers.Queries.Bookings;
using Saweat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saweat.Application.Test.Handlers.Queries.Bookings;

public class GetBookingsByStateTest
{
    [Fact]
    public async Task Get_bookings_by_undefinied_state_return_all_bookings()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var bookings = GetBookings();
        foreach (var booking in bookings)
        {
            await mediator.Send(new UpdateBookingRequest { Booking = booking });
        }
        var response = await mediator.Send(new GetBookingsByStateRequest { State = BookingState.Undefinied });
        var states = response.Data.Select(b => b.State).Distinct();
        states.Should().HaveCount(3);
    }

    [Theory]
    [InlineData(BookingState.Cancel)]
    [InlineData(BookingState.Approved)]
    [InlineData(BookingState.Pending)]
    public async void Get_bookings_by_state_return_bookings_of_request_state(BookingState state)
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var bookings = GetBookings();
        foreach (var booking in bookings)
        {
            await mediator.Send(new UpdateBookingRequest { Booking = booking });
        }
        var response = await mediator.Send(new GetBookingsByStateRequest { State = state });
        var states = response.Data.Select(b => b.State).Distinct();
        states.Should().HaveCount(1);
    }

    private static IEnumerable<Booking> GetBookings()
    {
        return new Booking[]
        {
            new Booking{CustomerEmail = "mail@mail.com", CustomerName = "Test", StartDate = new DateTime(2022, 5, 5, 15, 0 ,0), State = BookingState.Approved, CustomerPhone = "a", PeopleAmount = 1},
            new Booking{CustomerEmail = "mail@mail.com", CustomerName = "Test", StartDate = new DateTime(2022, 5, 5, 15, 0 ,0), State = BookingState.Cancel, CustomerPhone = "a", PeopleAmount = 1},
            new Booking{CustomerEmail = "mail@mail.com", CustomerName = "Test", StartDate = new DateTime(2022, 5, 5, 15, 0 ,0), State = BookingState.Pending, CustomerPhone = "a", PeopleAmount = 1}
        };
    }
}