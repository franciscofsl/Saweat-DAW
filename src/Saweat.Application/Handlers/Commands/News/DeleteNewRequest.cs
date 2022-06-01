namespace Saweat.Application.Handlers.Commands.News;

public class DeleteNewRequest : IRequest<Response<New>>
{
    public New New { get; set; }
}
