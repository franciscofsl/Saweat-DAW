namespace Saweat.Application.Handlers.Commands.Users;

public class CreateUser : IRequest<Response<ApplicationUser>>
{
    public ApplicationUser User { get; set; }
}

public class UpdateUser : IRequest<Response<ApplicationUser>>
{
    public ApplicationUser User { get; set; }
}