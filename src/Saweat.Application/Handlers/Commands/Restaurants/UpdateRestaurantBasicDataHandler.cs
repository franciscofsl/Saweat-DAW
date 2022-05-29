namespace Saweat.Application.Handlers.Commands.Restaurants;

public class UpdateRestaurantBasicDataHandler : IRequestHandler<UpdateRestaurantBasicDataRequest, Response<Restaurant>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRestaurantBasicDataHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Restaurant>> Handle(UpdateRestaurantBasicDataRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Restaurant>();
        await repository.UpdateAsync(request.Restaurant, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Restaurant>.CreateResponse(request.Restaurant);
    }
}
