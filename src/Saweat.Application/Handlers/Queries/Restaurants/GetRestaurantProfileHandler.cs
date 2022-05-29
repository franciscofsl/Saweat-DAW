namespace Saweat.Application.Handlers.Queries.Restaurants;

public class GetRestaurantProfileHandler : IRequestHandler<GetRestaurantProfileRequest, Response<Restaurant>>
{
    private readonly IRepository<Restaurant> _repository;

    public GetRestaurantProfileHandler(IRepository<Restaurant> repository)
    {
        this._repository = repository;
    }

    public async Task<Response<Restaurant>> Handle(GetRestaurantProfileRequest request, CancellationToken cancellationToken)
    {
        var elements = await this._repository.GetAllAsync(token: cancellationToken);
        return Response<Restaurant>.CreateResponse(elements.FirstOrDefault());
    }
}
