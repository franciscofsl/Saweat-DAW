namespace Saweat.Application.Handlers.Commands.Users;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, Response<ApplicationUser>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<ApplicationUser>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<ApplicationUser>();
        await repository.InsertAsync(request.User, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<ApplicationUser>.CreateResponse(request.User);
    }
}
