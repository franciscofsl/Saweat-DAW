namespace Saweat.Persistence.Contexts.Configurations;

public partial class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> entity)
    {
        entity.ToTable("Users");

        entity.HasKey(e => e.Email);

        entity.Property(U => U.Name).IsRequired(false);
        entity.Property(U => U.Lastnames).IsRequired(false);

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<ApplicationUser> entity);
}