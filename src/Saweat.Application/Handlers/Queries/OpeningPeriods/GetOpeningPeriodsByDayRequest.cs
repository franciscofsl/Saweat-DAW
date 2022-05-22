namespace Saweat.Application.Handlers.Queries.OpeningPeriods;

public class GetOpeningPeriodsByDayRequest : IRequest<Response<OpeningPeriod[]>>
{
    public DayOfWeek Day { get; set; }
}
