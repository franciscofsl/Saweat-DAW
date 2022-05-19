namespace Saweat.Application.Test.Handlers.Users;

public class CreationUserTest
{
    [Fact]
    public async Task Create_user()
    {
        var mediator = TestServices.Instance.GetService<IMediator>();
        var newUser = new ApplicationUser
        {
            Email = "test@email.com"
        };
        await mediator.Send(new CreateUser { User = newUser });
        var repository = TestServices.Instance.GetService<IRepository<ApplicationUser>>();
        var exists = await repository.ExistsAsync(U => U.Email == newUser.Email);
        exists.Should().BeTrue();
    }
}