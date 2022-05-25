namespace Saweat.Application.Handlers.Commands.Allergens;

public class UpdateAllergenRequest : IRequest<Response<Allergen>>
{
    public Allergen? Allergen { get; set; }
}
