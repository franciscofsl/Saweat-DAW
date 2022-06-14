namespace Saweat.Application.Handlers.Queries.News;

public class GetAllNewsHandler : IRequestHandler<GetAllNewsRequest, Response<IEnumerable<New>>>
{
    private readonly IRepository<New> _repository;

    public GetAllNewsHandler(IRepository<New> repository)
    {
        _repository = repository;
    }

    public async Task<Response<IEnumerable<New>>> Handle(GetAllNewsRequest request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetAllAsync(tracking: false, token: cancellationToken);
        return Response<IEnumerable<New>>.CreateResponse(news);
    }
}
