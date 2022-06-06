using Saweat.Domain.Enums;

namespace Saweat.Domain.Entities;

public class FoodPlateType
{
    public FoodPlateType()
    {
        this.FoodPlates = new HashSet<FoodPlate>();
    }

    public FoodType Type { get; set; }
    public string Description { get; set; }

    public virtual ICollection<FoodPlate> FoodPlates { get; set; }

    public override string ToString()
    {
        return this.Description;
    }
}
