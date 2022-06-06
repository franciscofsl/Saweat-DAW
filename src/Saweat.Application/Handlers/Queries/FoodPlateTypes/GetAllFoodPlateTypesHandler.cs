namespace Saweat.Application.Handlers.Queries.FoodPlateTypes;

public class GetAllFoodPlateTypesHandler : IRequestHandler<GetAllFoodPlateTypesRequest, Response<IEnumerable<FoodPlateType>>>
{
    private readonly IRepository<FoodPlateType> _repository;

    public GetAllFoodPlateTypesHandler(IRepository<FoodPlateType> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<IEnumerable<FoodPlateType>>> Handle(GetAllFoodPlateTypesRequest request, CancellationToken cancellationToken)
    {
        var foodPlateTypes = await _repository.GetAllAsync(token: cancellationToken);
        return Response<IEnumerable<FoodPlateType>>.CreateResponse(foodPlateTypes);
    }
}
