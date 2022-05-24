namespace Saweat.Application.Test.Handlers.Commands.Users;

public class CreationUserTest
{
    [Fact]
    public async Task Create_user()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var newUser = new ApplicationUser
        {
            Email = "test@email.com"
        };
        await mediator.Send(new CreateUserRequest { User = newUser });
        var repository = TestServices.GetInstance().GetService<IRepository<ApplicationUser>>();
        var exists = await repository.ExistsAsync(u => u.Email == newUser.Email);
        exists.Should().BeTrue();
    }
}