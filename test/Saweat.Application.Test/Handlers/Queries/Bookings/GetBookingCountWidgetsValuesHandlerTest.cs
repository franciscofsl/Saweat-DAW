using Saweat.Application.Handlers.Queries.Bookings;
using Saweat.Domain.Enums;

namespace Saweat.Application.Test.Handlers.Queries.Bookings;

public class GetBookingCountWidgetsValuesHandlerTest
{
    [Fact]
    public async Task Get_bookings_count_for_today_approved_bookings_return_expected_values()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingCountWidgetsValuesHandler(repository);
        var response = await handler.Handle(new GetBookingCountWidgetsValuesRequest(), default);
        var widgetCount = response.Data;
        widgetCount.TodayBookings.Should().Be(1);
    }

    [Fact]
    public async Task Get_bookings_count_for_today_cancels_bookings_return_expected_values()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingCountWidgetsValuesHandler(repository);
        var response = await handler.Handle(new GetBookingCountWidgetsValuesRequest(), default);
        var widgetCount = response.Data;
        widgetCount.TodayCancels.Should().Be(1);
    }

    [Fact]
    public async Task Get_bookings_count_for_next_bookings_return_expected_values()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingCountWidgetsValuesHandler(repository);
        var response = await handler.Handle(new GetBookingCountWidgetsValuesRequest(), default);
        var widgetCount = response.Data;
        widgetCount.NextBookings.Should().Be(1);
    }

    [Fact]
    public async Task Get_bookings_count_for_pending_bookings_return_expected_values()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingCountWidgetsValuesHandler(repository);
        var response = await handler.Handle(new GetBookingCountWidgetsValuesRequest(), default);
        var widgetCount = response.Data;
        widgetCount.PendingBookings.Should().Be(1);
    }

    [Fact]
    public async Task Get_bookings_count_for_next_cancels_return_expected_values()
    {
        var repository = TestServices.GetMockRepository(GetBookings());
        var handler = new GetBookingCountWidgetsValuesHandler(repository);
        var response = await handler.Handle(new GetBookingCountWidgetsValuesRequest(), default);
        var widgetCount = response.Data;
        widgetCount.NextCancels.Should().Be(1);
    }

    private static Booking[] GetBookings()
    {
        return new Booking[]
        {
            new Booking
            {
                State = BookingState.Approved,
                StartDate = DateTime.Today
            },
            new Booking
            {
                State = BookingState.Cancel,
                StartDate = DateTime.Today
            },
            new Booking
            {
                State = BookingState.Approved,
                StartDate = DateTime.Now.AddHours(2)
            },
            new Booking
            {
                State = BookingState.Pending,
                StartDate = DateTime.Now.AddHours(2)
            },
        };
    }
}