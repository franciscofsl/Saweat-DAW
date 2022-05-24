using Saweat.Application.Handlers.Queries.Bookings;
using Saweat.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Saweat.Application.Test.Handlers.Queries.Bookings;

public class GetBookingsByStateTest
{
    [Fact]
    public async Task Get_bookings_by_undefinied_state_return_all_bookings()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var bookings = GetBookings();
        await Create(mediator, bookings);
        var response = await mediator.Send(new GetBookingsByStateRequest { State = BookingState.Undefinied });
        response.Data.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task Get_bookings_by_approved_state_return_approved_bookings()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var bookings = GetBookings();
        await Create(mediator, bookings);
        var response = await mediator.Send(new GetBookingsByStateRequest { State = BookingState.Approved });
        response.Data.Should().HaveCount(1);
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

    private static async Task Create(IMediator mediator, IEnumerable<Booking> bookings)
    {
        foreach (var booking in bookings)
        {
            await mediator.Send(new UpdateBookingRequest { Booking = booking });
        }
    }

    private static async Task Delete(IMediator mediator, IEnumerable<Booking> bookings)
    {
        foreach (var booking in bookings)
        {
            await mediator.Send(new DeleteBookingRequest { Booking = booking });
        }
    }
}