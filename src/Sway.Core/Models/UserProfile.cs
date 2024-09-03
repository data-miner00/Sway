namespace Sway.Core.Models;

using System;

public class UserProfile
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string PhotoUrl { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
