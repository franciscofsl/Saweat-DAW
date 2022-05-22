namespace Saweat.Application.Handlers.Commands.OpeningPeriods;

public class UpdateOpeningPeriodRequest : IRequest<Response<OpeningPeriod>>
{
    public OpeningPeriod? OpeningPeriod { get; set; }
}
