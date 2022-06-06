namespace Saweat.Application.Handlers.Commands.FoodPlates;

public class UpdateFoodPlateRequest : IRequest<Response<FoodPlate>>
{
    public FoodPlate FoodPlate { get; set; }
}
