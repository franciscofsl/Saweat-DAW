namespace Saweat.Application.Handlers.Queries.Users;

public class GetApplicationUser : IRequest<Response<ApplicationUser>>
{
    public string Email { get; set; }
}
