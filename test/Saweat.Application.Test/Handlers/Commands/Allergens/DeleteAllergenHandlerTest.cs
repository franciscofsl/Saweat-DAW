using Saweat.Application.Handlers.Commands.Allergens;

namespace Saweat.Application.Test.Handlers.Commands.Allergens;

public class DeleteAllergenHandlerTest
{ 
    [Fact]
    public async Task Update_valid_allergen()
    {
        var allergen = new Allergen
        {
            AllergenId = 1,
            Name = "Lacteo",
            AllergenCode = "LCT",
            Icon = ""
        };
        var repository = TestServices.GetMockRepository(allergen);
        var unitOfWork = TestServices.GetMockUnitOfWork<Allergen>(repository);
        var handler = new DeleteAllergenHandler(unitOfWork);
        var response = await handler.Handle(new DeleteAllergenRequest { Allergen = allergen }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
}