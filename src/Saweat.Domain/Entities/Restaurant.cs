namespace Saweat.Domain.Entities;

public class Restaurant
{ 
    public string RestaurantId { get; set; }

    public string Description { get; set; }

    public string LongDescription { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string PostalCode { get; set; }

    public string Provincy { get; set; }

    public string Photo { get; set; }

    public string Phone { get; set; }

    public bool Enabled { get; set; }

    public string Email { get; set; }
    public string EmailPassword { get; set; }
}
