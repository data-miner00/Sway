namespace Sway.Database.Seeder.Generator;

using Bogus;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal sealed class UserGenerator
{
    private readonly IUserRepository repository;

    private Faker<User> faker;

    // Use bogus to generate data for usp_CreateNewUser
    public UserGenerator(IUserRepository repository)
    {
        this.repository = repository;

        this.ConfigureUserFaker();
    }

    public async Task ProvisionAsync(int count, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var users = this.faker.Generate(count);

        await Console.Out.WriteLineAsync();
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
            .RuleFor(x => x.PhotoUrl, s => s.Internet.Avatar())
            .RuleFor(x => x.Description, (s, o) => $"Hi, I am {o.Name}")
            .RuleFor(x => x.DateOfBirth, s => s.Date.Past());
    }
}
