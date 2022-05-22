namespace Saweat.Application.Handlers.Commands.OpeningPeriods;

public class DeleteOpeningPeriodHandler : IRequestHandler<DeleteOpeningPeriodRequest, Response<OpeningPeriod>>
{
    private readonly IUnitOfWork _unitOfWork; 

    public DeleteOpeningPeriodHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork; 
    }

    public async Task<Response<OpeningPeriod>> Handle(DeleteOpeningPeriodRequest request, CancellationToken cancellationToken)
    { 
        var repository = this._unitOfWork.GetRepository<OpeningPeriod>();
        await repository.DeleteAsync(request.OpeningPeriod, cancellationToken);
        await this._unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<OpeningPeriod>.CreateResponse(request.OpeningPeriod);
    }
}
