namespace Saweat.Domain.Entities;

public class New
{
    public int NewId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime PublishedDate { get; set; }
    public string Photo { get; set; }
    public bool Visible { get; set; }
}