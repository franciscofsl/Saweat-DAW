namespace Saweat.Application.Handlers.Commands.Allergens;

public class UpdateAllergenHandler : IRequestHandler<UpdateAllergenRequest, Response<Allergen>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAllergenHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Allergen>> Handle(UpdateAllergenRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Allergen>();
        var allergen = request.Allergen;
        if (allergen.AllergenId == 0) await repository.InsertAsync(allergen, cancellationToken);
        else await repository.UpdateAsync(allergen, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Allergen>.CreateResponse(allergen);
    }
}
