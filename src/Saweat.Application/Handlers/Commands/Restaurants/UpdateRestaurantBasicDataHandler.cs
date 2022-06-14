namespace Saweat.Application.Handlers.Commands.Restaurants;

public class UpdateRestaurantBasicDataHandler : IRequestHandler<UpdateRestaurantBasicDataRequest, Response<Restaurant>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<Restaurant> _validator;

    public UpdateRestaurantBasicDataHandler(IUnitOfWork unitOfWork, IValidator<Restaurant> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Response<Restaurant>> Handle(UpdateRestaurantBasicDataRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Restaurant, cancellationToken);
        if (validationResult != null && validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return Response<Restaurant>.CreateResponse(request.Restaurant, false, errors);
        }
        var repository = _unitOfWork.GetRepository<Restaurant>();
        await repository.UpdateAsync(request.Restaurant, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Restaurant>.CreateResponse(request.Restaurant);
    }
}
