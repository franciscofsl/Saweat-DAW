namespace Saweat.Application.Handlers.Queries.Allergens;

public class GetAllergenByIdHandler : IRequestHandler<GetAllergenByIdRequest, Response<Allergen>>
{
    private readonly IRepository<Allergen> _repository;

    public GetAllergenByIdHandler(IRepository<Allergen> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<Allergen>> Handle(GetAllergenByIdRequest request, CancellationToken cancellationToken)
    {
        var allergen = await _repository.GetByIdAsync(request.AllergenId, token: cancellationToken);
        return Response<Allergen>.CreateResponse(allergen);
    }
}
