namespace Saweat.Persistence.Contexts.Configurations;

public partial class OpeningPeriodConfiguration : IEntityTypeConfiguration<OpeningPeriod>
{
    public void Configure(EntityTypeBuilder<OpeningPeriod> entity)
    {
        entity.ToTable("OpeningPeriods");

        entity.HasKey(p => p.OpeningId);

        entity.Property(p => p.StartHour).IsRequired();

        entity.Property(p => p.EndHour).IsRequired();

        entity.HasData(new OpeningPeriod[]
        {
            new OpeningPeriod
            {
                OpeningId = 1,
                Day = DayOfWeek.Monday,
                StartHour = new TimeSpan(13, 0, 0),
                EndHour = new TimeSpan(16, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 2,
                Day = DayOfWeek.Monday,
                StartHour = new TimeSpan(20, 0, 0),
                EndHour = new TimeSpan(0, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 3,
                Day = DayOfWeek.Tuesday,
                StartHour = new TimeSpan(13, 0, 0),
                EndHour = new TimeSpan(16, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 4,
                Day = DayOfWeek.Tuesday,
                StartHour = new TimeSpan(20, 0, 0),
                EndHour = new TimeSpan(0, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 5,
                Day = DayOfWeek.Wednesday,
                StartHour = new TimeSpan(13, 0, 0),
                EndHour = new TimeSpan(16, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 6,
                Day = DayOfWeek.Wednesday,
                StartHour = new TimeSpan(20, 0, 0),
                EndHour = new TimeSpan(0, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 7,
                Day = DayOfWeek.Thursday,
                StartHour = new TimeSpan(13, 0, 0),
                EndHour = new TimeSpan(16, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 8,
                Day = DayOfWeek.Thursday,
                StartHour = new TimeSpan(20, 0, 0),
                EndHour = new TimeSpan(0, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 9,
                Day = DayOfWeek.Friday,
                StartHour = new TimeSpan(13, 0, 0),
                EndHour = new TimeSpan(16, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 10,
                Day = DayOfWeek.Friday,
                StartHour = new TimeSpan(20, 0, 0),
                EndHour = new TimeSpan(0, 0, 0)
            },
            new OpeningPeriod
            {
                OpeningId = 11,
                Day = DayOfWeek.Saturday,
                StartHour = new TimeSpan(13, 0, 0),
                EndHour = new TimeSpan(0, 0, 0)
            }
        });

        this.OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<OpeningPeriod> entity);
}