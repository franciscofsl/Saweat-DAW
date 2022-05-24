namespace Saweat.Application.Test.Handlers.Commands.Users;

public class UpdateUserTest
{
    [Fact]
    public async Task Update_valid_user()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var user = new ApplicationUser
        {
            Email = "user@email.com"
        };
        await mediator.Send(new CreateUserRequest { User = user });
        user.Name = "Name";
        user.Lastnames = "Lastnames";
        await mediator.Send(new UpdateUserRequest { User = user });
        var repository = TestServices.GetInstance().GetService<IRepository<ApplicationUser>>();
        var exists = await repository.ExistsAsync(U => U.Email == user.Email && U.Name == "Name");
        exists.Should().BeTrue();
    }

    [Fact]
    public async Task Update_user_command_returns_error_with_name_error()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var user = new ApplicationUser
        {
            Email = "updateUserWithoutName@email.com"
        };
        await mediator.Send(new CreateUserRequest { User = user });
        user.Lastnames = "Lastnames";
        var response = await mediator.Send(new UpdateUserRequest { User = user });
        response.ValidationErrors
            .Should().HaveCount(1)
            .And.ContainSingle(S => S == "El nombre del usuario es obligatorio");
    }

    [Fact]
    public async Task Update_user_command_returns_error_with_empty_lastnames_error()
    {
        var mediator = TestServices.GetInstance().GetService<IMediator>();
        var user = new ApplicationUser
        {
            Email = "updateUserWithoutLastnames@email.com"
        };
        await mediator.Send(new CreateUserRequest { User = user });
        user.Name = "Name";
        var response = await mediator.Send(new UpdateUserRequest { User = user });
        response.ValidationErrors
            .Should().HaveCount(1)
            .And.ContainSingle(S => S == "Los apellidos del usuario son obligatorios");
    }
}