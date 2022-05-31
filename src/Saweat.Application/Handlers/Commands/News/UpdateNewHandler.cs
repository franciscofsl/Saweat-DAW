namespace Saweat.Application.Handlers.Commands.News;

public class UpdateNewHandler : IRequestHandler<UpdateNewRequest, Response<New>>
{
    private readonly IValidator<New> _validator;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateNewHandler(IUnitOfWork unitOfWork, IValidator<New> validator)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<New>> Handle(UpdateNewRequest request, CancellationToken cancellationToken)
    {
        var newToUpdate = request.New;
        var validationResult = await _validator.ValidateAsync(newToUpdate, cancellationToken);
        if (validationResult != null && validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return Response<New>.CreateResponse(newToUpdate, false, errors);
        }

        var repository = _unitOfWork.GetRepository<New>();
        if (newToUpdate.NewId > 0)
        {
            await repository.UpdateAsync(newToUpdate, cancellationToken);
        }
        else
        {
            newToUpdate.CreatedDate = DateTime.Now;
            await repository.InsertAsync(newToUpdate, cancellationToken);
        }
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<New>.CreateResponse(newToUpdate);
    }
}
