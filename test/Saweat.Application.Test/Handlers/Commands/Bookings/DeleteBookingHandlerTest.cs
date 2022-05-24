namespace Saweat.Application.Test.Handlers.Commands.Bookings;

public class DeleteBookingHandlerTest
{
      [Fact]
    public async Task Delete_opening_period()
    {
        var booking = new Booking
        {
            CustomerEmail = "mail@mail.com",
            CustomerName = "Fran",
            CustomerPhone = "5476541"
        };
        var repository = TestServices.GetMockRepository(booking);
        var unitOfWork = TestServices.GetMockUnitOfWork<Booking>(repository);
        var handler = new DeleteBookingHandler(unitOfWork);
        var response = await handler.Handle(new DeleteBookingRequest() { Booking = booking }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
}