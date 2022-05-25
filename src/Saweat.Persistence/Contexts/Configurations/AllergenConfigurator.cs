using Saweat.Domain.Enums;

namespace Saweat.Persistence.Contexts.Configurations;

public partial class AllergenConfiguration : IEntityTypeConfiguration<Allergen>
{
    public void Configure(EntityTypeBuilder<Allergen> entity)
    {
        entity.ToTable("Allergens");

        entity.HasKey(a => a.AllergenCode);

        entity.Property(a => a.Name).HasMaxLength(50);

        entity.Property(a => a.Icon).HasMaxLength(30); 
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Allergen> entity);
      
}