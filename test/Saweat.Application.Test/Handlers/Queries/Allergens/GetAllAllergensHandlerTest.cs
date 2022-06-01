using Saweat.Application.Handlers.Queries.Allergens;

namespace Saweat.Application.Test.Handlers.Queries.Allergens;

public class GetAllAllergensHandlerTest
{
    [Fact]
    public async Task Get_all_allergens_return_all_allergens()
    { 
        var repository = TestServices.GetMockRepository(GetAllergens());
        var handler = new GetAllAllergensHandler(repository);
        var response = await handler.Handle(new GetAllAllergensRequest(), default);
        response.Data.Should().HaveCount(3);
    }

    private static Allergen[] GetAllergens()
    {
        return new Allergen[]
        {
            new Allergen(),
            new Allergen(),
            new Allergen()
        };
    }
}