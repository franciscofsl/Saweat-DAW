using Saweat.Application.Handlers.Commands.News;

namespace Saweat.Application.Test.Handlers.Commands.News;

public class RemoveNewHandlerTest
{
    [Fact]
    public async Task Delete_new()
    {
        var currentNew = new New
        {
            PublishedDate = DateTime.Now,
            CreatedDate = DateTime.Now,
            Title = "New",
            Content = "New",
            Photo = "Photo",
            Visible = true,
            NewId = 1
        };
        var repository = TestServices.GetMockRepository(currentNew);
        var unitOfWork = TestServices.GetMockUnitOfWork(repository);
        var handler = new DeleteNewHandler(unitOfWork);
        var response = await handler.Handle(new DeleteNewRequest()
        {
            New= currentNew
        }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
}