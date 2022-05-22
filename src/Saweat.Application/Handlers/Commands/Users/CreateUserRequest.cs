namespace Saweat.Application.Handlers.Commands.Users;

public class CreateUserRequest : IRequest<Response<ApplicationUser>>
{
    public ApplicationUser? User { get; set; }
}
