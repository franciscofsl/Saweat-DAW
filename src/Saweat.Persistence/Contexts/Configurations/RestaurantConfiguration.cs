namespace Saweat.Persistence.Contexts.Configurations;

public partial class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> entity)
    {
        entity.ToTable("Restaurants");

        entity.Property(e => e.RestaurantId).HasMaxLength(25);

        entity.Property(e => e.Photo).IsRequired(false);

        entity.Property(e => e.Address).HasMaxLength(2000);

        entity.Property(e => e.City).HasMaxLength(2000);

        entity.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.LongDescription)
            .HasMaxLength(2000);

        entity.Property(e => e.PostalCode).HasMaxLength(5);

        entity.Property(e => e.Provincy).HasMaxLength(100);

        entity.HasData(new Restaurant
        {
            RestaurantId = "sutakito",
            Description = "Sutakito Mexicano",
            LongDescription = "La mejor comida mexicana artesanal en Santander",
            Address = "Francisco de Quevedo 12, Bajo",
            City = "Santander",
            PostalCode = "30001",
            Provincy = "Cantabria",
            Phone = "642 63 99 73",
            Enabled = true,
            Photo = "https://sutakitomexicano.com/wp-content/uploads/2021/04/cropped-logo-sutakito.png"
        });

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Restaurant> entity);
}