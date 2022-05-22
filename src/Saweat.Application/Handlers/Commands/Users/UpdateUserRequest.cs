namespace Saweat.Application.Handlers.Commands.Users;

public class UpdateUserRequest : IRequest<Response<ApplicationUser>>
{
    public ApplicationUser? User { get; set; }
}
