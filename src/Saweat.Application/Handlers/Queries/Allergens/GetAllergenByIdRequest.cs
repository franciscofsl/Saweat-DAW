namespace Saweat.Application.Handlers.Queries.Allergens;

public class GetAllergenByIdRequest : IRequest<Response<Allergen>>
{
    public GetAllergenByIdRequest(int allergenId)
    {
        AllergenId = allergenId;
    }

    public int AllergenId { get; }
}
