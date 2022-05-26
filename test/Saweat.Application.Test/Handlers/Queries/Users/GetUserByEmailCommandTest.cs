using Saweat.Application.Handlers.Queries.Users;

namespace Saweat.Application.Test.Handlers.Queries.Users;

public class GetUserByEmailCommandTest
{
    [Fact]
    public async Task Get_user_by_email()
    {
        var users = new[]
        {
            new ApplicationUser
            {
                Email = "test@email.com"
            }
        };
        var repositoryMock = TestServices.GetMockRepository(users);

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(u => u.GetRepository<ApplicationUser>())
            .Returns(repositoryMock);

        var handler = new GetUserByEmailHandler(repositoryMock);
        var response = await handler.Handle(new GetUserByEmailRequest
        {
            Email = "test@email.com"
        }, default);
        response.Data.Should().NotBeNull();
        response.Data.Email.Should().Be("test@email.com");
    }
}
