namespace Saweat.Application.Handlers.Commands.FoodPlates;

public class DeleteFoodPlateRequest : IRequest<Response<FoodPlate>>
{
    public FoodPlate FoodPlate { get; set; }
}
