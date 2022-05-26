namespace Saweat.Application.Handlers.Commands.Users;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Response<ApplicationUser>>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IValidator<ApplicationUser> _validator;

    public UpdateUserHandler(IUnitOfWork unitOfWork, IValidator<ApplicationUser> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Response<ApplicationUser>> Handle(UpdateUserRequest? request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.User, cancellationToken).ConfigureAwait(false);
        if (validationResult.Errors.Any())
        {
            var errors = validationResult.Errors.Select(E => E.ErrorMessage).ToArray();
            return Response<ApplicationUser>.CreateResponse(request.User, false, errors);
        }
        var repository = _unitOfWork.GetRepository<ApplicationUser>();
        await repository.UpdateAsync(request.User, cancellationToken).ConfigureAwait(false);
        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return Response<ApplicationUser>.CreateResponse(request.User);
    }
}
