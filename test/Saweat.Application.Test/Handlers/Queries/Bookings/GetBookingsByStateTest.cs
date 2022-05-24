using Saweat.Application.Handlers.Queries.Bookings;
using Saweat.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saweat.Application.Test.Handlers.Queries.Bookings;

[Collection("GetBookingsByStateTest")]
public class GetBookingsByStateTest
{
    [Fact]
    public async Task Get_bookings_by_undefinied_state_return_all_bookings()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var bookings = GetBookings();
        await CreateBookings(mediator, bookings);
        var opening = new OpeningPeriod
        {
            Day = DayOfWeek.Sunday,
            StartHour = new TimeSpan(15, 0, 0),
            EndHour = new TimeSpan(20, 0, 0)
        };
        await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = opening });
        var response = await mediator.Send(new GetBookingsByStateRequest { State = BookingState.Undefinied });
        var states = response.Data.Select(b => b.State).Distinct();
        states.Should().HaveCount(3);
        await mediator.Send(new DeleteOpeningPeriodRequest { OpeningPeriod = opening });
        await RemoveBookings(mediator, bookings);
    }

    [Theory]
    [InlineData(BookingState.Cancel)]
    [InlineData(BookingState.Approved)]
    [InlineData(BookingState.Pending)]
    public async void Get_bookings_by_state_return_bookings_of_request_state(BookingState state)
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var bookings = GetBookings();
        await CreateBookings(mediator, bookings);
        var response = await mediator.Send(new GetBookingsByStateRequest { State = state });
        var states = response.Data.Select(b => b.State).Distinct();
        states.Should().HaveCount(1);
        await RemoveBookings(mediator, bookings);
    }

    public static async Task CreateBookings(IMediator mediator, Booking[] bookings)
    {
        var tasks = bookings.Select(b => mediator.Send(new UpdateBookingRequest { Booking = b })).ToList();
        await Task.WhenAll(tasks);
    }

    public static async Task RemoveBookings(IMediator mediator, Booking[] bookings)
    {
        var tasks = bookings.Select(b => mediator.Send(new DeleteBookingRequest { Booking = b })).ToList();
        await Task.WhenAll(tasks); 
    }

    public static Booking[] GetBookings()
    {
        var bookings = new[]
        {
            new Booking {  State = BookingState.Pending },
            new Booking { State = BookingState.Cancel },
            new Booking { State = BookingState.Approved },
            new Booking { State = BookingState.Cancel },
            new Booking { State = BookingState.Approved },
            new Booking { State = BookingState.Approved },
            new Booking { State = BookingState.Pending },
            new Booking { State = BookingState.Approved },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Pending },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Cancel },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Pending },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Cancel },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Pending },
            new Booking { State = BookingState.Approved },
            new Booking {  State = BookingState.Cancel },
            new Booking { State = BookingState.Approved },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Pending },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Pending },
            new Booking {  State = BookingState.Approved },
            new Booking {  State = BookingState.Cancel }
        };
        foreach (var booking in bookings)
        {
            booking.CustomerEmail = "email@email.com";
            booking.CustomerName = "email@email.com";
            booking.CustomerPhone = "email@email.com";
            booking.StartDate = new DateTime(2022, 5, 22, 18, 0, 0);
        }
        return bookings;
    }
}