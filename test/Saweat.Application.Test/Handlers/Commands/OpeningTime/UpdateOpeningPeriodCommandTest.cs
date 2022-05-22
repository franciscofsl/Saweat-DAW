using System;

namespace Saweat.Application.Test.Handlers.Commands.OpeningTime;

[Collection("UpdateOpeningPeriodCommandTest")]
public class UpdateOpeningPeriodCommandTest
{
    [Fact]
    public async Task Create_opening_time()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var unitOfWork = TestServices.GetInstance().GetService<IUnitOfWork>();
        var period = new OpeningPeriod
        {
            StartHour = TimeSpan.MinValue,
            EndHour = TimeSpan.MaxValue
        };
        await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = period });
        var exists = await mediator.Send(new GetOpeningPeriodsByDayRequest { Day = period.Day });
        exists.Data.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task Create_opening_time_returns_error_with_begin_time_after_end_time()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var period = new OpeningPeriod
        {
            StartHour = new TimeSpan(18, 0, 0),
            EndHour = new TimeSpan(15, 0, 0)
        };
        var response = await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = period });
        response.ValidationErrors
            .Should().HaveCountGreaterThan(0)
            .And.ContainSingle(S => S == "La fecha fin no puede ser anterior a la fecha de comienzo.");
    }

    [Fact]
    public async Task Create_opening_schedule_returns_error_when_schedule_exists_in_period_hours_and_days()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var period = new OpeningPeriod
        {
            StartHour = new TimeSpan(10, 0, 0),
            EndHour = new TimeSpan(13, 0, 0)
        };

        await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = period });
        var badPeriod = new OpeningPeriod
        {
            StartHour = new TimeSpan(11, 0, 0),
            EndHour = new TimeSpan(12, 0, 0)
        };
        var newResponse = await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = badPeriod });

        newResponse.ValidationErrors[0].Should().Be("El horario que intenta crear se esta solapando con otro horario.");
    }

    [Fact]
    public async Task Create_opening_schedule_returns_error_when_schedule_exists_at_same_period_times_and_days()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var period = new OpeningPeriod
        {
            StartHour = new TimeSpan(10, 1, 0),
            EndHour = new TimeSpan(12, 2, 0)
        };

        await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = period });
        var badPeriod = new OpeningPeriod
        {
            StartHour = new TimeSpan(10, 1, 1),
            EndHour = new TimeSpan(12, 1, 0)
        };
        var response = await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = badPeriod });

        response.ValidationErrors[0].Should().Be("El horario que intenta crear se esta solapando con otro horario.");
    }

    [Fact]
    public async Task Update_existing_opening_time()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var period = new OpeningPeriod
        {
            StartHour = new TimeSpan(17, 1, 0),
            EndHour = new TimeSpan(17, 2, 0)
        };
        await mediator.Send(new UpdateOpeningPeriodRequest{ OpeningPeriod = period });
        period.Day = DayOfWeek.Thursday;
        await mediator.Send(new UpdateOpeningPeriodRequest { OpeningPeriod = period });
    }
}