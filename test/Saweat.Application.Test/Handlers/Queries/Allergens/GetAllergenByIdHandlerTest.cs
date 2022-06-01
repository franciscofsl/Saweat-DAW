using Saweat.Application.Handlers.Queries.Allergens;

namespace Saweat.Application.Test.Handlers.Queries.Allergens;

public class GetAllergenByIdHandlerTest
{
    [Fact]
    public async Task Get_allergen_by_id_return_correct_allergen()
    {
        var allergen = new Allergen
        {
            AllergenId = 2
        };
        var repository = TestServices.GetMockRepositoryById(allergen);
        var handler = new GetAllergenByIdHandler(repository);
        var response = await handler.Handle(new GetAllergenByIdRequest(2), default);
        response.Data.AllergenId.Should().Be(2);
    } 
}