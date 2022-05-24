using Saweat.Application.Handlers.Queries.Users;

namespace Saweat.Application.Test.Handlers.Queries.Users;

public class GetUserByEmailCommandTest
{
    [Fact]
    public async Task Get_user_by_email()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        await mediator.Send(new CreateUserRequest { User = new ApplicationUser{Email = "mail@mail.com"}});
        var response = await mediator.Send(new GetUserByEmailRequest{Email = "mail@mail.com"});
        response.Data.Should().NotBeNull();
        response.Data.Email.Should().Be("mail@mail.com");
    }
}