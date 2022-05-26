namespace Saweat.Application.Handlers.Commands.OpeningPeriods;

public class UpdateOpeningPeriodHandler : IRequestHandler<UpdateOpeningPeriodRequest, Response<OpeningPeriod>>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IValidator<OpeningPeriod> _validator;

    public UpdateOpeningPeriodHandler(IUnitOfWork unitOfWork, IValidator<OpeningPeriod> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Response<OpeningPeriod>> Handle(UpdateOpeningPeriodRequest request, CancellationToken cancellationToken)
    {
        var openingPeriod = request.OpeningPeriod;

        var validationResult = await _validator.ValidateAsync(openingPeriod, cancellationToken);
        if (validationResult.Errors.Any()) return Response<OpeningPeriod>.CreateResponse(openingPeriod, false, validationResult.Errors.Select(e => e.ErrorMessage));

        var repository = _unitOfWork.GetRepository<OpeningPeriod>();

        await (openingPeriod.OpeningId > 0
            ? repository.UpdateAsync(openingPeriod, cancellationToken)
            : repository.InsertAsync(openingPeriod, cancellationToken));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<OpeningPeriod>.CreateResponse(openingPeriod);
    }
}
