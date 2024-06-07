namespace Sway.Core.Models;

using System;

public class UserCredential
{
    public string UserId { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string PasswordSalt { get; set; }

    public string HashAlgorithm { get; set; }

    public string? PreviousPasswordHash { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
