namespace Sway.Core.Models;

using System;

public class ProductRating
{
    public int Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid AuthorId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public int MediaAttachedCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
