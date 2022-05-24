namespace Saweat.Persistence.Contexts.Configurations;

public partial class OpeningPeriodConfiguration : IEntityTypeConfiguration<OpeningPeriod>
{
    public void Configure(EntityTypeBuilder<OpeningPeriod> entity)
    {
        entity.ToTable("OpeningPeriods");

        entity.HasKey(p => p.OpeningId);

        entity.Property(p => p.StartHour).IsRequired();

        entity.Property(p => p.EndHour).IsRequired(); 

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<OpeningPeriod> entity);
}