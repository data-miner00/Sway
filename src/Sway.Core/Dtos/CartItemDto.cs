namespace Sway.Core.Dtos;

using System;

public sealed class CartItemDto
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public bool IsSelected { get; set; }

    public DateTime AddedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
