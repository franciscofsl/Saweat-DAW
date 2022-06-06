namespace Saweat.Application.Handlers.Queries.FoodPlates;

public class GetFoodPlateByIdRequest : IRequest<Response<FoodPlate>>
{
    public GetFoodPlateByIdRequest(int foodPlateId)
    {
        FoodPlateId = foodPlateId;
    }

    public int FoodPlateId { get; }
}
