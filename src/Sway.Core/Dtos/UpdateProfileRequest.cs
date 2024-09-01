namespace Sway.Core.Dtos;

using System;

public sealed class UpdateProfileRequest
{
    public Guid UserId { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Description { get; set; }

    public string PhotoUrl { get; set; }

    public DateTime DateOfBirth { get; set; }
}
