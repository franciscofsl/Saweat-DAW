using System;

namespace Saweat.Application.Test.Handlers.Commands.OpeningTime;

public class DeleteOpeningPeriodHandlerTest
{
    [Fact]
    public async Task Delete_opening_period()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var repository = TestServices.GetInstance().GetService<IRepository<OpeningPeriod>>();
        var openingPeriod = new OpeningPeriod
        {
            Day = DayOfWeek.Tuesday,
            StartHour = new TimeSpan(17,0,0),
            EndHour = new TimeSpan(17,0,5),
        };
        var response = await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = openingPeriod});
        await mediator.Send(new DeleteOpeningPeriodRequest { OpeningPeriod = openingPeriod });
        bool exists = await repository.ExistsAsync(o => o.OpeningId == openingPeriod.OpeningId);
        exists.Should().BeFalse();
    }
}