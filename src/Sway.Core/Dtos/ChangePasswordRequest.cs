namespace Sway.Core.Dtos;

using System;

public sealed class ChangePasswordRequest
{
    public Guid UserId { get; set; }

    public string OldPassword { get; set; }

    public string NewPassword { get; set; }
}
