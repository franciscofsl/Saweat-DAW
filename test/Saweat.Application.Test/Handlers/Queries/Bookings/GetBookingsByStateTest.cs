using Saweat.Application.Handlers.Queries.Bookings;
using Saweat.Domain.Enums;

namespace Saweat.Application.Test.Handlers.Queries.Bookings;

public class GetBookingsByStateTest
{
    [Fact]
    public async Task Get_bookings_by_undefinied_state_return_all_bookings()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingsByStateHandler(repository);
        var response = await handler.Handle(new GetBookingsByStateRequest
        {
            State = BookingState.Undefinied
        }, default);
        response.Data.Should().HaveCount(3);
    }

    [Fact]
    public async Task Get_bookings_by_approved_state_return_approved_bookings()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingsByStateHandler(repository);
        var response = await handler.Handle(new GetBookingsByStateRequest
        {
            State = BookingState.Approved
        }, default);
        response.Data.Should().HaveCount(1);
    }

    [Fact]
    public async Task Get_bookings_by_cancel_state_return_cancel_bookings()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingsByStateHandler(repository);
        var response = await handler.Handle(new GetBookingsByStateRequest
        {
            State = BookingState.Cancel
        }, default);
        response.Data.Should().HaveCount(1);
    }

    [Fact]
    public async Task Get_bookings_by_pending_state_return_pending_bookings()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingsByStateHandler(repository);
        var response = await handler.Handle(new GetBookingsByStateRequest
        {
            State = BookingState.Pending
        }, default);
        response.Data.Should().HaveCount(1);
    }

    private static Booking[] GetBookings()
    {
        return new[]
        {
            new Booking
            {
                CustomerEmail = "mail@mail.com",
                CustomerName = "Test",
                StartDate = new DateTime(2022, 5, 5, 15, 0, 0),
                State = BookingState.Approved,
                CustomerPhone = "a",
                PeopleAmount = 1
            },
            new Booking
            {
                CustomerEmail = "mail@mail.com",
                CustomerName = "Test",
                StartDate = new DateTime(2022, 5, 5, 15, 0, 0),
                State = BookingState.Cancel,
                CustomerPhone = "a",
                PeopleAmount = 1
            },
            new Booking
            {
                CustomerEmail = "mail@mail.com",
                CustomerName = "Test",
                StartDate = new DateTime(2022, 5, 5, 15, 0, 0),
                State = BookingState.Pending,
                CustomerPhone = "a",
                PeopleAmount = 1
            }
        };
    }
}
