namespace Saweat.Application.Handlers.Commands.Allergens;

public class DeleteAllergenRequest : IRequest<Response<Allergen>>
{
    public Allergen? Allergen { get; set; }
}
