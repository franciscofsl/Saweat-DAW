namespace Saweat.Application.Validators.Entities.FoodPlates;

public class FoodPlateValidator : AbstractValidator<FoodPlate>
{
    public FoodPlateValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("El producto no tiene nombre.");

        RuleFor(n => n.Price)
            .NotNull()
            .WithMessage("El producto no tiene precio.");
    }
}
