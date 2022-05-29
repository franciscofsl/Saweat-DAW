namespace Saweat.Application.Handlers.Commands.Restaurants;

public class UpdateRestaurantBasicDataRequest : IRequest<Response<Restaurant>>
{
    public Restaurant Restaurant { get; set; }
}
