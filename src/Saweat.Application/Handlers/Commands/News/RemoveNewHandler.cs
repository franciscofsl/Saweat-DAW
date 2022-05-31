namespace Saweat.Application.Handlers.Commands.News;

public class RemoveNewHandler : IRequestHandler<RemoveNewRequest, Response<New>>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveNewHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<New>> Handle(RemoveNewRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<New>();
        await repository.DeleteAsync(request.New, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<New>.CreateResponse(request.New);
    }
}
