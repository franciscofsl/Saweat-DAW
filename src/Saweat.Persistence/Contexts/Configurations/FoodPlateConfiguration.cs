namespace Saweat.Persistence.Contexts.Configurations;

public partial class FoodPlateConfiguration : IEntityTypeConfiguration<FoodPlate>
{
    public void Configure(EntityTypeBuilder<FoodPlate> entity)
    {
        entity.HasKey(e => e.PlateFoodId);

        entity.Property(e => e.Description)
            .HasMaxLength(200)
            .IsFixedLength()
            .IsRequired(false);

        entity.Property(e => e.Name)
            .HasMaxLength(30)
            .IsFixedLength();

        entity.Property(e => e.Photo).IsRequired();

        entity.HasOne(d => d.FoodPlateType)
            .WithMany(p => p.FoodPlates)
            .HasForeignKey(d => d.Type)
            .OnDelete(DeleteBehavior.ClientSetNull);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<FoodPlate> entity);
}
