using Saweat.Domain.Enums;

namespace Saweat.Domain.Entities;

public class Booking
{
    public int BookingId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate => StartDate.AddHours(1);

    public string? CustomerName { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerPhone { get; set; }

    public int PeopleAmount { get; set; }

    public string Code { get; set; }

    public BookingState State { get; set; } = BookingState.Pending;
}
