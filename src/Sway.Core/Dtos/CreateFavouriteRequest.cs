namespace Sway.Core.Dtos;

using System;

public sealed class CreateFavouriteRequest
{
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }
}
