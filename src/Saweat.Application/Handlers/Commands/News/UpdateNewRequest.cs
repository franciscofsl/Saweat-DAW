namespace Saweat.Application.Handlers.Commands.News;

public class UpdateNewRequest : IRequest<Response<New>>
{
    public New New { get; set; }
}
