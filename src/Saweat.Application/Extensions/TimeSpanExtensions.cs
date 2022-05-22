namespace Saweat.Application.Extensions;

public static class TimeSpanExtensions
{
    public static bool Between(this TimeSpan time, TimeSpan start, TimeSpan end)
    {
        return start.CompareTo(time) == -1 && time.CompareTo(end) == -1;
    }
}
