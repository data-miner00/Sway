namespace Sway.Database.Seeder.UnitTests;

using Moq;
using Sway.Database.Seeder.Options;
using Sway.Database.Seeder.Sinks;

public sealed class ExecutorTests
{
    private static Mock<ISink> MockSink;
    private static Mock<ISinkFactory> MockSinkFactory;
    private static IExecutor Executor;
    private static SeedingOption SeedingOption;

    [Before(Test)]
    public void Setup()
    {
        MockSink = new Mock<ISink>();
        MockSinkFactory = new Mock<ISinkFactory>();

        MockSinkFactory
            .Setup(x => x.CreateSink(It.IsAny<SwayEntity>(), It.IsAny<SinkType>()))
            .Returns(MockSink.Object);

        SeedingOption = new SeedingOption
        {
            Count = 1,
            Entity = SwayEntity.User,
            Destination = SinkType.Database,
        };
        Executor = new Executor(MockSinkFactory.Object, SeedingOption);
    }

    [Test]
    [Retry(3)]
    public async Task ExecuteAsync_InvokedProvisionAsync()
    {
        await Executor.ExecuteAsync(default);

        MockSink.Verify(
            x => x.ProvisionAsync(1, default),
            Times.Once());
    }

    [Test]
    [DependsOn(nameof(ExecuteAsync_InvokedProvisionAsync))]
    public async Task AfterExecution_ObjectNotNull()
    {
        await Assert.That(Executor).IsNotNull();
    }
}
