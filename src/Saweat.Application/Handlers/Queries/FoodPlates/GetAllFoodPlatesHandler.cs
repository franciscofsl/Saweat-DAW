using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Saweat.Application.Handlers.Queries.FoodPlates;

public class GetAllFoodPlatesHandler : IRequestHandler<GetAllFoodPlatesRequest, Response<IEnumerable<FoodPlate>>>
{
    private readonly IRepository<FoodPlate> _repository;

    public GetAllFoodPlatesHandler(IRepository<FoodPlate> repository)
    {
        _repository = repository;
    }

    public async Task<Response<IEnumerable<FoodPlate>>> Handle(GetAllFoodPlatesRequest request, CancellationToken cancellationToken)
    {
        Func<IQueryable<FoodPlate>, IIncludableQueryable<FoodPlate, object>> include =
            i => i.Include(a => a.FoodPlateType);
        var foodPlates = await _repository.GetAllAsync(include: include, token: cancellationToken);
        return Response<IEnumerable<FoodPlate>>.CreateResponse(foodPlates);
    }
}
