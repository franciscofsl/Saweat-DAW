namespace Saweat.Application.Handlers.Queries.Users;

public class GetLoggedUserHandler : IRequestHandler<GetApplicationUser, Response<ApplicationUser>>
{
    private readonly IRepository<ApplicationUser> _repository;

    public GetLoggedUserHandler(IRepository<ApplicationUser> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<ApplicationUser>> Handle(GetApplicationUser request, CancellationToken cancellationToken)
    {
        var elements = await this._repository.GetAllAsync(token: cancellationToken);


        return Response<ApplicationUser>.CreateResponse(elements.FirstOrDefault());
    }
}
