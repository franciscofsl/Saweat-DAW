namespace Saweat.Application.Handlers.Commands.News;

public class RemoveNewRequest : IRequest<Response<New>>
{
    public New New { get; set; }
}
