namespace Saweat.Application.Handlers.Queries.News;

public class GetVisibleNewsHandler : IRequestHandler<GetVisibleNewsRequest, Response<IEnumerable<New>>>
{
    private readonly IRepository<New> _repository;

    public GetVisibleNewsHandler(IRepository<New> repository)
    {
        _repository = repository;
    }

    public async Task<Response<IEnumerable<New>>> Handle(GetVisibleNewsRequest request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetAllAsync(filter: n => n.Visible && n.PublishedDate <= DateTime.Now, tracking: false, token: cancellationToken);
        return Response<IEnumerable<New>>.CreateResponse(news.OrderByDescending(n => n.PublishedDate));
    }
}
