using Saweat.Application.Handlers.Commands.Restaurants;
using Saweat.Application.Validators.Entities.Restaurants;

namespace Saweat.Application.Test.Handlers.Commands.Restaurants;

public class UpdateRestaurantBasicDataHandlerTest
{
    [Fact]
    public async Task Create_valid_new()
    {
        var restaurant = new Restaurant
        {
            
        };
        var unitOfWork = TestServices.GetMockUnitOfWork<Restaurant>();
        var handler = new UpdateRestaurantBasicDataHandler(unitOfWork, new RestaurantValidator());
        var response = await handler.Handle(new UpdateRestaurantBasicDataRequest
        {
            Restaurant= restaurant
        }, default);
        response.ValidationErrors.Should().BeEmpty();
    }
}