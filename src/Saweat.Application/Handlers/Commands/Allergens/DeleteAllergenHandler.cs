namespace Saweat.Application.Handlers.Commands.Allergens;

public class DeleteAllergenHandler : IRequestHandler<DeleteAllergenRequest, Response<Allergen>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAllergenHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<Response<Allergen>> Handle(DeleteAllergenRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<Allergen>();
        await repository.DeleteAsync(request.Allergen, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<Allergen>.CreateResponse(request.Allergen);
    }
}
