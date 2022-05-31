namespace Saweat.Application.Handlers.Queries.News;

public class GetNewByIdHandler : IRequestHandler<GetNewByIdRequest, Response<New>>
{
    private readonly IRepository<New> _repository;

    public GetNewByIdHandler(IRepository<New> repository)
    {
        _repository = repository;
    }

    public async Task<Response<New>> Handle(GetNewByIdRequest request, CancellationToken cancellationToken)
    {
        var newById = await _repository.GetAllAsync(filter: n => n.NewId == request.NewId, token: cancellationToken);
        return Response<New>.CreateResponse(newById.FirstOrDefault());
    }
}
