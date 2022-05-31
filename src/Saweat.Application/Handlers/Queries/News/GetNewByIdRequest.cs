namespace Saweat.Application.Handlers.Queries.News;

public class GetNewByIdRequest : IRequest<Response<New>>
{
    public int NewId { get; set; }
}
