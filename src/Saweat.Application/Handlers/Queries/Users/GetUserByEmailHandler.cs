namespace Saweat.Application.Handlers.Queries.Users;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailRequest, Response<ApplicationUser>>
{
    private readonly IRepository<ApplicationUser> _repository;

    public GetUserByEmailHandler(IRepository<ApplicationUser> repository)
    {
        _repository = repository;
    }

    public async Task<Response<ApplicationUser>> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
    {
        var elements = await _repository.GetAllAsync(filter: u => u.Email == request.Email, token: cancellationToken);
        return Response<ApplicationUser>.CreateResponse(elements.FirstOrDefault());
    }
}
