namespace Sway.Database.Seeder.Generator;

using Bogus;
using Sway.Core.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The generator class for <see cref="User"/>.
/// </summary>
internal sealed class UserGenerator : IGenerator<User>
{
    private Faker<User> faker;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserGenerator"/> class.
    /// </summary>
    public UserGenerator()
    {
        this.ConfigureUserFaker();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<User>> GenerateAsync(int count, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(this.faker.Generate(count).AsEnumerable());
    }

    private void ConfigureUserFaker()
    {
        this.faker = new Faker<User>()
            .RuleFor(x => x.FirstName, s => s.Name.FirstName())
            .RuleFor(x => x.LastName, s => s.Name.LastName())
            .RuleFor(x => x.Username, (s, o) => string.Concat(o.FirstName.ToLowerInvariant(), o.LastName.ToLowerInvariant()))
            .RuleFor(x => x.Status, s => s.PickRandom<Status>())
            .RuleFor(x => x.Role, s => s.PickRandom<Role>())
            .RuleFor(x => x.Email, (s, o) =>
            {
                return s.Internet.Email(firstName: o.FirstName, lastName: o.LastName);
            })
            .RuleFor(x => x.Phone, s => s.Phone.PhoneNumber())
            .RuleFor(x => x.PhotoUrl, s => s.Internet.Avatar())
            .RuleFor(x => x.Description, (s, o) => $"Hi, I am {o.FirstName} {o.LastName}")
            .RuleFor(x => x.DateOfBirth, s => s.Date.Past());
    }
}
