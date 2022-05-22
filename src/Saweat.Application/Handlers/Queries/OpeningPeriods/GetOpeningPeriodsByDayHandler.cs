namespace Saweat.Application.Handlers.Queries.OpeningPeriods;

public class GetOpeningPeriodsByDayHandler : IRequestHandler<GetOpeningPeriodsByDayRequest, Response<OpeningPeriod[]>>
{
    private readonly IRepository<OpeningPeriod> _repository;

    public GetOpeningPeriodsByDayHandler(IRepository<OpeningPeriod> repository)
    {
        _repository = repository;
    }

    public async Task<Response<OpeningPeriod[]>> Handle(GetOpeningPeriodsByDayRequest request, CancellationToken cancellationToken)
    {
        var elements = await _repository.GetAllAsync(filter: p => p.Day == request.Day, token: cancellationToken);
        return Response<OpeningPeriod[]>.CreateResponse(elements.ToArray());
    }
}
