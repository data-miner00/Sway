namespace Sway.Database.Seeder.Generator;

using Bogus;
using Sway.Core.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

internal sealed class UserGenerator : IGenerator<User>
{
    private Faker<User> faker;

    public UserGenerator()
    {
        this.ConfigureUserFaker();
    }

    public Task<IEnumerable<User>> GenerateAsync(int count, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(this.faker.Generate(count).AsEnumerable());
    }

    private void ConfigureUserFaker()
    {
        this.faker = new Faker<User>()
            .RuleFor(x => x.Name, s => s.Name.FullName())
            .RuleFor(x => x.Status, s => s.PickRandom<Status>())
            .RuleFor(x => x.Role, s => s.PickRandom<Role>())
            .RuleFor(x => x.Email, (s, o) =>
            {
                var splitName = o.Name.Split(' ');

                return s.Internet.Email(firstName: splitName[0], lastName: splitName[1]);
            })
            .RuleFor(x => x.Phone, s => s.Phone.PhoneNumber())
            .RuleFor(x => x.PhotoUrl, s => s.Internet.Avatar())
            .RuleFor(x => x.Description, (s, o) => $"Hi, I am {o.Name}")
            .RuleFor(x => x.DateOfBirth, s => s.Date.Past());
    }
}
