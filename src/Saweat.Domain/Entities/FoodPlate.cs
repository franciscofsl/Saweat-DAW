using Saweat.Domain.Enums;

namespace Saweat.Domain.Entities;

public class FoodPlate
{
    public int PlateFoodId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Photo { get; set; }
    public FoodType Type { get; set; }
     
    public virtual FoodPlateType FoodPlateType { get; set; }
}