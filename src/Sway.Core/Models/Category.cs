namespace Sway.Core.Models;

public class Category
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string? ParentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
