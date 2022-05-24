using Moq;

namespace Saweat.Application.Test.Handlers.Commands.Users;

public class CreationUserTest
{
    [Fact]
    public async Task Create_user()
    {
        var newUser = new ApplicationUser
        {
            Email = "test@email.com"
        };
        var repositoryMock = new Mock<IRepository<ApplicationUser>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(u => u.GetRepository<ApplicationUser>()).Returns(repositoryMock.Object);
        var handler = new CreateUserHandler(unitOfWorkMock.Object);
        var response = await handler.Handle(new CreateUserRequest { User = newUser }, default);
        response.Success.Should().BeTrue();
    }
}