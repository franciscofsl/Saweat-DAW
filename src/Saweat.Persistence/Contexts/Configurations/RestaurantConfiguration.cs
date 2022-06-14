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
        entity.Property(e => e.Email).HasMaxLength(500);
        entity.Property(e => e.EmailPassword).HasMaxLength(500);
         
        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Restaurant> entity);
}