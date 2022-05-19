namespace Saweat.Application.Handlers.Commands.Users;

public class CreateUserHandler : IRequestHandler<CreateUser, Response<ApplicationUser>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<ApplicationUser>> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<ApplicationUser>();
        await repository.InsertAsync(request.User, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<ApplicationUser>.CreateResponse(request.User);
    } 
}