using Saweat.Domain.Enums;

namespace Saweat.Persistence.Contexts.Configurations;

public partial class FoodPlateTypeConfiguration : IEntityTypeConfiguration<FoodPlateType>
{
    public void Configure(EntityTypeBuilder<FoodPlateType> entity)
    {
        entity.HasKey(e => e.Type);

        entity.Property(e => e.Description)
            .HasMaxLength(200)
            .IsFixedLength();

        entity.HasData(GetFoodPlateTypes());

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<FoodPlateType> entity);

    private static FoodPlateType[] GetFoodPlateTypes()
    {
        return new FoodPlateType[]
        {
            new FoodPlateType{ Type = FoodType.Undefinied, Description = "Indefinido" },
            new FoodPlateType{ Type = FoodType.Special, Description = "Especiales" },
            new FoodPlateType{ Type = FoodType.Meat, Description = "Carnes" },
            new FoodPlateType{ Type = FoodType.Vegetable, Description = "Vegetales" },
            new FoodPlateType{ Type = FoodType.Mixed, Description = "Mixtos" },
            new FoodPlateType{ Type = FoodType.Drink, Description = "Bebidas" },
            new FoodPlateType{ Type = FoodType.AlcoholicDrink, Description = "Bebidas Alcoholicas" },
            new FoodPlateType{ Type = FoodType.Dessert, Description = "Postres" }
        };
    }
}
