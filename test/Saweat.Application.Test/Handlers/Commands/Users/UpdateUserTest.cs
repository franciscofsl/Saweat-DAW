using Moq;
using Saweat.Application.Validators.Entities.Users;

namespace Saweat.Application.Test.Handlers.Commands.Users;

public class UpdateUserTest
{
    [Fact]
    public async Task Update_valid_user()
    {
        var user = new ApplicationUser
        {
            Email = "test@email.com"
        };
        var repositoryMock = new Mock<IRepository<ApplicationUser>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(u => u.GetRepository<ApplicationUser>()).Returns(repositoryMock.Object);
        var handler = new CreateUserHandler(unitOfWorkMock.Object);
        await handler.Handle(new CreateUserRequest { User = user }, default);
        user.Name = "TestUser";
        user.Lastnames = "TestUser";
        var updateHandler = new UpdateUserHandler(unitOfWorkMock.Object, new UpdateUserValidator());
        var response = await updateHandler.Handle(new UpdateUserRequest() { User = user }, default);
        response.ValidationErrors.Should().BeEmpty();
    }

    [Fact]
    public async Task Update_user_command_returns_error_with_name_error()
    {
        var user = new ApplicationUser
        {
            Email = "updateUserWithoutName@email.com"
        };
        var repositoryMock = new Mock<IRepository<ApplicationUser>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(u => u.GetRepository<ApplicationUser>()).Returns(repositoryMock.Object);
        var handler = new CreateUserHandler(unitOfWorkMock.Object);
        await handler.Handle(new CreateUserRequest { User = user }, default); 
        user.Lastnames = "TestUser";
        var updateHandler = new UpdateUserHandler(unitOfWorkMock.Object, new UpdateUserValidator());
        var response = await updateHandler.Handle(new UpdateUserRequest() { User = user }, default);
        response.ValidationErrors
            .Should().HaveCount(1)
            .And.ContainSingle(s => s == "El nombre del usuario es obligatorio");
    }

    [Fact]
    public async Task Update_user_command_returns_error_with_empty_lastnames_error()
    {
        var user = new ApplicationUser
        {
            Email = "updateUserWithoutName@email.com"
        };
        var repositoryMock = new Mock<IRepository<ApplicationUser>>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(u => u.GetRepository<ApplicationUser>()).Returns(repositoryMock.Object);
        var handler = new CreateUserHandler(unitOfWorkMock.Object);
        await handler.Handle(new CreateUserRequest { User = user }, default);
        user.Name = "Name";
        var updateHandler = new UpdateUserHandler(unitOfWorkMock.Object, new UpdateUserValidator());
        var response = await updateHandler.Handle(new UpdateUserRequest() { User = user }, default);
        response.ValidationErrors
            .Should().HaveCount(1)
            .And.ContainSingle(s => s == "Los apellidos del usuario son obligatorios");
    }
}