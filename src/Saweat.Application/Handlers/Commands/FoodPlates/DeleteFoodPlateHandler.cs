namespace Saweat.Application.Handlers.Commands.FoodPlates;

public class DeleteFoodPlateHandler : IRequestHandler<DeleteFoodPlateRequest, Response<FoodPlate>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFoodPlateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<FoodPlate>> Handle(DeleteFoodPlateRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<FoodPlate>();
        await repository.DeleteAsync(request.FoodPlate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<FoodPlate>.CreateResponse(request.FoodPlate);
    }
}
