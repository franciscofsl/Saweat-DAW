namespace Saweat.Application.Test.Handlers.Commands.OpeningTime;

public class DeleteOpeningPeriodHandlerTest
{
    [Fact]
    public async Task Delete_opening_period()
    {
        var openingPeriod = new OpeningPeriod
        {
            Day = DayOfWeek.Tuesday,
            StartHour = new TimeSpan(17, 0, 0),
            EndHour = new TimeSpan(17, 0, 5),
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<OpeningPeriod>();
        var handler = new DeleteOpeningPeriodHandler(unitOfWork);
        var response = await handler.Handle(new DeleteOpeningPeriodRequest { OpeningPeriod = openingPeriod }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
}