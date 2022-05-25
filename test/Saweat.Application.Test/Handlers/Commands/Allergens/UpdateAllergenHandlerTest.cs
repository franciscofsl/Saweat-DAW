using Saweat.Application.Handlers.Commands.Allergens;

namespace Saweat.Application.Test.Handlers.Commands.Allergens;

public class UpdateAllergenHandlerTest
{
    [Fact]
    public async Task Create_valid_allergen()
    {
        var allergen = new Allergen
        {
            Name = "Lacteo",
            AllergenCode = "LCT",
            Icon = ""
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<Allergen>();
        var handler = new UpdateAllergenHandler(unitOfWork);
        var response = await handler.Handle(new UpdateAllergenRequest { Allergen = allergen }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
    
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
        var handler = new UpdateAllergenHandler(unitOfWork);
        var response = await handler.Handle(new UpdateAllergenRequest { Allergen = allergen }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
}