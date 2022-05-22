namespace Saweat.Persistence.Contexts.Configurations;

public partial class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> entity)
    {
        entity.ToTable("Booking");  

        entity.Property(B => B.CustomerEmail).HasMaxLength(250);

        entity.Property(B => B.CustomerName).HasMaxLength(25);

        entity.Property(B => B.CustomerPhone).HasMaxLength(20);

        entity.Property(B => B.StartDate).HasColumnType("datetime");

        entity.Property(B => B.PeopleAmount).HasDefaultValue(1);

        entity.Ignore(B => B.EndDate);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Booking> entity);
}