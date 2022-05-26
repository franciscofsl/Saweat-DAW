using Saweat.Application.Validators.Entities.OpeningPeriods;

namespace Saweat.Application.Test.Handlers.Commands.OpeningTime;

public class UpdateOpeningPeriodCommandTest
{
    [Fact]
    public async Task Create_opening_time()
    {
        var period = new OpeningPeriod
        {
            StartHour = TimeSpan.MinValue,
            EndHour = TimeSpan.MaxValue
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<OpeningPeriod>();
        var handler = new UpdateOpeningPeriodHandler(unitOfWork,
        new OpeningPeriodValidator(unitOfWork.GetRepository<OpeningPeriod>()));
        var response = await handler.Handle(new UpdateOpeningPeriodRequest
        {
            OpeningPeriod = period
        }, default);
        response.ValidationErrors.Should().BeEmpty();
    }

    [Fact]
    public async Task Create_opening_time_returns_error_with_begin_time_after_end_time()
    {
        var period = new OpeningPeriod
        {
            StartHour = new TimeSpan(18, 0, 0),
            EndHour = new TimeSpan(15, 0, 0)
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<OpeningPeriod>();
        var handler = new UpdateOpeningPeriodHandler(unitOfWork,
        new OpeningPeriodValidator(unitOfWork.GetRepository<OpeningPeriod>()));
        var response = await handler.Handle(new UpdateOpeningPeriodRequest
        {
            OpeningPeriod = period
        }, default);
        response.ValidationErrors
            .Should().HaveCountGreaterThan(0)
            .And.ContainSingle(s => s == "La fecha fin no puede ser anterior a la fecha de comienzo.");
    }

    [Fact]
    public async Task Create_opening_schedule_returns_error_when_schedule_exists_in_period_hours_and_days()
    {
        var periods = new[]
        {
            new OpeningPeriod
            {
                StartHour = new TimeSpan(10, 0, 0),
                EndHour = new TimeSpan(13, 0, 0)
            }
        };
        var badPeriod = new OpeningPeriod
        {
            StartHour = new TimeSpan(11, 0, 0),
            EndHour = new TimeSpan(12, 0, 0)
        };
        var repository = TestServices.GetMockRepository(periods);
        var unitOfWork = TestServices.GetMockUnitOfWork(repository);
        var handler = new UpdateOpeningPeriodHandler(unitOfWork, new OpeningPeriodValidator(repository));
        var response = await handler.Handle(new UpdateOpeningPeriodRequest
        {
            OpeningPeriod = badPeriod
        }, default);
        response.ValidationErrors[0].Should().Be("El horario que intenta crear se esta solapando con otro horario.");
    }

    [Fact]
    public async Task Update_existing_opening_time()
    {
        var period = new OpeningPeriod
        {
            StartHour = new TimeSpan(17, 1, 0),
            EndHour = new TimeSpan(17, 2, 0)
        };
        var repository = TestServices.GetMockRepository(period);
        var unitOfWork = TestServices.GetMockUnitOfWork(repository);
        var handler = new UpdateOpeningPeriodHandler(unitOfWork,
        new OpeningPeriodValidator(unitOfWork.GetRepository<OpeningPeriod>()));
        var response = await handler.Handle(new UpdateOpeningPeriodRequest
        {
            OpeningPeriod = period
        }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
}
