namespace Saweat.Domain.Entities;

public class ApplicationUser
{
    public string Email { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lastnames { get; set; } = string.Empty;
}