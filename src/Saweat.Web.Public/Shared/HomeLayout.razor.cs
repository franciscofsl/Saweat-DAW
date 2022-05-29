using MediatR;
using Microsoft.AspNetCore.Components;
using Saweat.Application.Handlers.Queries.Restaurants;
using Saweat.Domain.Entities;
using System.Threading.Tasks;

namespace Saweat.Web.Public.Layouts;

public partial class HomeLayoutComponent
{
    public Restaurant Restaurant;

    [Inject]
    public IMediator Mediator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (this.Restaurant is null)
        {
            var response = await this.Mediator.Send(new GetRestaurantProfileRequest());
            this.Restaurant = response.Data;
        }
    }
}
