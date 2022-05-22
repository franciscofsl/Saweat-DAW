namespace Saweat.Application.Handlers.Queries.Users;

public class GetUserByEmailRequest : IRequest<Response<ApplicationUser>>
{
    public string? Email { get; set; }
}
