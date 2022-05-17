using FluentAssertions;
using Saweat.Application.Contracts.Persistence;
using Saweat.Domain.Entities;
using Saweat.Test.Common;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Saweat.Persistence.Test;

[Collection("Saweat.Persistence")]
public class RepositoryTest
{
    [Fact]
    public async Task CountAsync_returns_0_when_not_exists_entities()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var count = await repository.CountAsync(R => R.RestaurantId == "qwe");
        count.Should().Be(0);
    }

    [Fact]
    public async Task DeleteAsync_remove_entity_from_context()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurant = GetRestaurants("burgerking");
        await repository.InsertAsync(restaurant);
        await unitOfWork.SaveChangesAsync();
        await repository.DeleteAsync(restaurant);
        await unitOfWork.SaveChangesAsync();
        var count = await repository.CountAsync();
        count.Should().Be(0);
    }

    [Fact]
    public async Task DeleteAsync_remove_entities_from_context()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurants = GetRestaurants("mcdonals", "telepizza");
        await repository.InsertAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        await repository.DeleteAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        var count = await repository.CountAsync();
        count.Should().Be(0);
    }

    [Fact]
    public async Task ExistsAsync_returns_true_when_exists_entity()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurants = GetRestaurants("chilanga");
        await repository.InsertAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        var count = await repository.ExistsAsync();
        count.Should().BeTrue();
        await repository.DeleteAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
    }

    [Fact]
    public async Task ExistsAsync_returns_true_when_exists_entity_with_filter()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurants = GetRestaurants("aurant");
        await repository.InsertAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        var count = await repository.ExistsAsync(R => R.Description.Contains("aurant"));
        count.Should().BeTrue();
        await repository.DeleteAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
    }

    [Fact]
    public async Task ExistsAsync_returns_false_when_not_exists_entity()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var count = await repository.ExistsAsync();
        count.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsAsync_returns_false_when_not_exists_entity_with_filter()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var count = await repository.ExistsAsync(R => R.RestaurantId == "12345");
        count.Should().BeFalse();
    }

    [Fact]
    public async Task UpdateAsync_update_entity()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurant = GetRestaurants("987645321");
        await repository.InsertAsync(restaurant);
        await unitOfWork.SaveChangesAsync();
        var newDescription = "NUEVADESCRIPCION";
        var exists = await repository.ExistsAsync(R => R.Description == newDescription);
        exists.Should().BeFalse();
        restaurant[0].Description = newDescription;
        await repository.UpdateAsync(restaurant);
        await unitOfWork.SaveChangesAsync();
        exists = await repository.ExistsAsync(R => R.Description == newDescription);
        exists.Should().BeTrue();
        await repository.DeleteAsync(restaurant);
        await unitOfWork.SaveChangesAsync();
    }

    [Fact]
    public async Task UpdateAsync_update_entities()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurants = GetRestaurants("freshpizza");
        await repository.InsertAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        var newDescription = "NUEVADESCRIPCION";
        var exists = await repository.ExistsAsync(R => R.Description == newDescription);
        exists.Should().BeFalse();
        restaurants.FirstOrDefault(new Restaurant()).Description = newDescription;
        await repository.UpdateAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        exists = await repository.ExistsAsync(R => R.Description == newDescription);
        exists.Should().BeTrue();
        await repository.DeleteAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
    }

    [Fact]
    public async Task GetAllAsync_returns_all_elements_without_parameters()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurants = GetRestaurants("qwerty", "ytrewq");
        await repository.InsertAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        var elements = await repository.GetAllAsync();
        elements.Count.Should().Be(2);
        await repository.DeleteAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
    }

    [Fact]
    public async Task GetAllAsync_returns_all_elements_with_where()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurants = GetRestaurants("asd", "dsa");
        await repository.InsertAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        var elements = await repository.GetAllAsync(R => R.RestaurantId != string.Empty);
        elements.Count.Should().Be(2);
        await repository.DeleteAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
    }

    [Fact]
    public async Task GetById_returns_null_when_not_exists_id()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurant = await repository.GetByIdAsync("Restaurant");
        restaurant.Should().BeNull();
    }

    [Fact]
    public async Task GetById_returns_entity_by_id()
    {
        var unitOfWork = TestServices.Instance.GetService<IUnitOfWork>();
        var repository = unitOfWork.GetRepository<Restaurant>();
        var restaurants = GetRestaurants("30042022");
        await repository.InsertAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
        var restaurant = await repository.GetByIdAsync("30042022");
        restaurant.Should().NotBeNull();
        await repository.DeleteAsync(restaurants);
        await unitOfWork.SaveChangesAsync();
    }

    private static Restaurant[] GetRestaurants(params string[] restaurantIds)
    {
        return restaurantIds.Select(I => new Restaurant
        {
            RestaurantId = I,
            Description = I,
            Address = I,
            City = I,
            PostalCode = I,
            Provincy = I,
            LongDescription = I,
            Phone = I
        }).ToArray();
    }
}
