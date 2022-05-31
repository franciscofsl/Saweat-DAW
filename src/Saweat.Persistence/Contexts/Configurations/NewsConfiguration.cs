namespace Saweat.Persistence.Contexts.Configurations;

public partial class NewsConfiguration : IEntityTypeConfiguration<New>
{
    public void Configure(EntityTypeBuilder<New> entity)
    {
        entity.ToTable("News");

        entity.Property(a => a.CreatedDate).HasDefaultValue(DateTime.Now);
        entity.Property(a => a.PublishedDate).HasDefaultValue(DateTime.Now);
        entity.Property(a => a.Visible).HasDefaultValue(false);
        entity.Property(a => a.Photo).IsRequired();
    }

    partial void OnConfigurePartial(EntityTypeBuilder<New> entity);

}