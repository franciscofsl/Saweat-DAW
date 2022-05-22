namespace Saweat.Application.Handlers.Commands.OpeningPeriods;

public class DeleteOpeningPeriodRequest : IRequest<Response<OpeningPeriod>>
{
    public OpeningPeriod? OpeningPeriod { get; set; }
}
