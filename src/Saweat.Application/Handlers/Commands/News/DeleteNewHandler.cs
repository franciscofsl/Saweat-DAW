namespace Saweat.Application.Handlers.Commands.News;

public class DeleteNewHandler : IRequestHandler<DeleteNewRequest, Response<New>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNewHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<New>> Handle(DeleteNewRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<New>();
        await repository.DeleteAsync(request.New, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<New>.CreateResponse(request.New);
    }
}
