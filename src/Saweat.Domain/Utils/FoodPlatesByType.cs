namespace Saweat.Domain.Utils;

public class FoodPlatesByType
{
    public IEnumerable<FoodPlate> SpecialFoodPlates { get; set; }
    public IEnumerable<FoodPlate> MeatFoodPlates { get; set; }
    public IEnumerable<FoodPlate> VegetableFoodPlates { get; set; }
    public IEnumerable<FoodPlate> MixedFoodPlates { get; set; }
    public IEnumerable<FoodPlate> DrinkFoodPlates { get; set; }
    public IEnumerable<FoodPlate> AlcoholicDrinkFoodPlates { get; set; }
    public IEnumerable<FoodPlate> DessertFoodPlates { get; set; }
}