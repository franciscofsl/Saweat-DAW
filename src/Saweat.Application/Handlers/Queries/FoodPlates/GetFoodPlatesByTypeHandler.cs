using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Saweat.Domain.Enums;
using Saweat.Domain.Utils;

namespace Saweat.Application.Handlers.Queries.FoodPlates;

public class GetFoodPlatesByTypeHandler : IRequestHandler<GetFoodPlatesByTypeRequest, Response<FoodPlatesByType>>
{
    private readonly IRepository<FoodPlate> _repository;

    public GetFoodPlatesByTypeHandler(IRepository<FoodPlate> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<FoodPlatesByType>> Handle(GetFoodPlatesByTypeRequest request, CancellationToken cancellationToken)
    {
        Func<IQueryable<FoodPlate>, IIncludableQueryable<FoodPlate, object>> include =
            i => i.Include(a => a.FoodPlateType);
        var foodPlates = await _repository.GetAllAsync(include: include, token: cancellationToken);
        var foodPlatesByType = new FoodPlatesByType
        {
            SpecialFoodPlates = foodPlates.Where(f => f.Type == FoodType.Special),
            MeatFoodPlates = foodPlates.Where(f => f.Type == FoodType.Meat),
            VegetableFoodPlates = foodPlates.Where(f => f.Type == FoodType.Vegetable),
            MixedFoodPlates = foodPlates.Where(f => f.Type == FoodType.Mixed),
            DrinkFoodPlates = foodPlates.Where(f => f.Type == FoodType.Drink),
            AlcoholicDrinkFoodPlates = foodPlates.Where(f => f.Type == FoodType.AlcoholicDrink),
            DessertFoodPlates = foodPlates.Where(f => f.Type == FoodType.Dessert),
        };
        return Response<FoodPlatesByType>.CreateResponse(foodPlatesByType);
    }
}