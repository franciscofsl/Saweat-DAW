using Saweat.Application.Handlers.Commands.News;
using Saweat.Application.Validators.Entities.News;

namespace Saweat.Application.Test.Handlers.Commands.News;

public class UpdateNewHandlerTest
{
    [Fact]
    public async Task Create_valid_new()
    {
        var currentNew = new New
        {
            PublishedDate = DateTime.Now,
            CreatedDate = DateTime.Now,
            Title = "New",
            Content = "New",
            Photo = "Photo",
            Visible = true
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<New>(); 
        var handler = new UpdateNewHandler(unitOfWork, new NewValidator());
        var response = await handler.Handle(new UpdateNewRequest
        {
            New = currentNew
        }, default);
        response.ValidationErrors.Should().BeEmpty();
    }

    [Fact]
    public async Task Update_existing_new()
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
        var unitOfWork = TestServices.GetMockUnitOfWork<New>();
        var handler = new UpdateNewHandler(unitOfWork, new NewValidator());
        var response = await handler.Handle(new UpdateNewRequest
        {
            New = currentNew
        }, default);
        response.ValidationErrors.Should().BeEmpty();
    } 

    [Fact]
    public async Task Create_new_without_title_return_error()
    {
        var currentNew = new New
        {
            PublishedDate = DateTime.Now,
            CreatedDate = DateTime.Now,
            Content = "New",
            Photo = "Photo",
            Visible = true
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<New>();
        var handler = new UpdateNewHandler(unitOfWork, new NewValidator());
        var response = await handler.Handle(new UpdateNewRequest
        {
            New = currentNew
        }, default);
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("La noticia no tiene titulo.");
    }

    [Fact]
    public async Task Create_new_without_content_return_error()
    {
        var currentNew = new New
        {
            PublishedDate = DateTime.Now,
            CreatedDate = DateTime.Now,
            Title = "New",
            Photo = "Photo",
            Visible = true
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<New>();
        var handler = new UpdateNewHandler(unitOfWork, new NewValidator());
        var response = await handler.Handle(new UpdateNewRequest
        {
            New = currentNew
        }, default);
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("La noticia no tiene contenido.");
    }
    
    [Fact]
    public async Task Create_new_without_image_return_error()
    {
        var currentNew = new New
        {
            PublishedDate = DateTime.Now,
            CreatedDate = DateTime.Now,
            Title = "New",
            Content = "New",
            Visible = true
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<New>();
        var handler = new UpdateNewHandler(unitOfWork, new NewValidator());
        var response = await handler.Handle(new UpdateNewRequest
        {
            New = currentNew
        }, default);
        response.ValidationErrors.Should().HaveCount(1);
        response.ValidationErrors[0].Should().Be("No se ha incluido una imagen.");
    }
}