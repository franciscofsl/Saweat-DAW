namespace Saweat.Application.Extensions;

public static class DateTimeExtensions
{
    public static bool Between(this DateTime date, TimeSpan start, TimeSpan end)
    {
        var time = date.TimeOfDay;
        return time >= start && time <= end;
    }
}
