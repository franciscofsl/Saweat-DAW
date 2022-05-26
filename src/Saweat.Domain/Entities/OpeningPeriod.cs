namespace Saweat.Domain.Entities;

public class OpeningPeriod
{
    public int OpeningId { get; set; }

    public DayOfWeek Day { get; set; }

    public TimeSpan StartHour { get; set; }

    public TimeSpan EndHour { get; set; }
}
