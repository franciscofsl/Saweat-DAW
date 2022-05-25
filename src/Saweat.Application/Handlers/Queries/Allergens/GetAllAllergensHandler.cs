﻿namespace Saweat.Application.Handlers.Queries.Allergens;

public class GetAllAllergensHandler : IRequestHandler<GetAllAllergensRequest, Response<IEnumerable<Allergen>>>
{
    private readonly IRepository<Allergen> _repository;

    public GetAllAllergensHandler(IRepository<Allergen> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<IEnumerable<Allergen>>> Handle(GetAllAllergensRequest request, CancellationToken cancellationToken)
    {
        var allergens = await this._repository.GetAllAsync(token: cancellationToken);
        return Response<IEnumerable<Allergen>>.CreateResponse(allergens);
    }
}