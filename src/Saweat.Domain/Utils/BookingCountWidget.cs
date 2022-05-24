namespace Saweat.Domain.Utils;

public class BookingCountWidget
{
    public int TodayBookings { get; set; }
    public int TodayCancels { get; set; }
    public int NextBookings { get; set; }
    public int PendingBookings { get; set; }
    public int NextCancels { get; set; }
}