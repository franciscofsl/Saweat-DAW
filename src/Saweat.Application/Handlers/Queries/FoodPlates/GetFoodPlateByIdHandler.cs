namespace Saweat.Application.Handlers.Queries.FoodPlates;

public class GetFoodPlateByIdHandler : IRequestHandler<GetFoodPlateByIdRequest, Response<FoodPlate>>
{
    private readonly IRepository<FoodPlate> _repository;

    public GetFoodPlateByIdHandler(IRepository<FoodPlate> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<FoodPlate>> Handle(GetFoodPlateByIdRequest request, CancellationToken cancellationToken)
    {
        var foodPlate = await this._repository.GetByIdAsync(request.FoodPlateId, token: cancellationToken);
        return Response<FoodPlate>.CreateResponse(foodPlate);
    }
}
