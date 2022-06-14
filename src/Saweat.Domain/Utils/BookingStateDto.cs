using Saweat.Domain.Enums;

namespace Saweat.Domain.Utils;

public class BookingStateDto
{
    public BookingStateDto(string name, BookingState value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; private set; }
    public BookingState Value { get; private set; }
}