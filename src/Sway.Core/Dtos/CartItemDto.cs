﻿namespace Sway.Core.Dtos;

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

    /// <summary>
    /// Converts a cart item into object that is recognized by stored procedure for insertion.
    /// </summary>
    /// <returns>The converted object.</returns>
    public CartOrderLineDto ToOrderLineDto()
    {
        return new CartOrderLineDto
        {
            ProductId = this.ProductId,
            Quantity = this.Quantity,
            UnitPrice = this.UnitPrice,
            TotalPrice = this.Quantity * this.UnitPrice,
        };
    }
}
