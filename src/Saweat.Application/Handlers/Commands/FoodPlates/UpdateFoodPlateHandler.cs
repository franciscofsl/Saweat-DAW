namespace Saweat.Application.Handlers.Commands.FoodPlates;

public class UpdateFoodPlateHandler : IRequestHandler<UpdateFoodPlateRequest, Response<FoodPlate>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<FoodPlate> _validator;

    public UpdateFoodPlateHandler(IUnitOfWork unitOfWork, IValidator<FoodPlate> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Response<FoodPlate>> Handle(UpdateFoodPlateRequest request, CancellationToken cancellationToken)
    {
        var foodPlate = request.FoodPlate; 
        var validationResult = await _validator.ValidateAsync(foodPlate, cancellationToken);
        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return Response<FoodPlate>.CreateResponse(foodPlate, false, errors);
        }
        var repository = _unitOfWork.GetRepository<FoodPlate>();
        var updateTask = foodPlate.PlateFoodId > 0
            ? repository.UpdateAsync(foodPlate, cancellationToken)
            : repository.InsertAsync(foodPlate, cancellationToken);
        await updateTask;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<FoodPlate>.CreateResponse(foodPlate);
    }
}
