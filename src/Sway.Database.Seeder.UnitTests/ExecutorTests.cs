namespace Sway.Database.Seeder.UnitTests;

using Moq;
using Sway.Database.Seeder.Options;
using Sway.Database.Seeder.Sinks;

public sealed class ExecutorTests
{
    private Mock<ISink> mockSink;
    private Mock<ISinkFactory> mockSinkFactory;
    private IExecutor executor;
    private SeedingOption seedingOption;

    [Before(Test)]
    public void Setup()
    {
        this.mockSink = new Mock<ISink>();
        this.mockSinkFactory = new Mock<ISinkFactory>();

        this.mockSinkFactory
            .Setup(x => x.CreateSink(It.IsAny<SwayEntity>(), It.IsAny<SinkType>()))
            .Returns(this.mockSink.Object);

        this.seedingOption = new SeedingOption
        {
            Count = 1,
            Entity = SwayEntity.User,
            Destination = SinkType.Database,
        };

        this.executor = new Executor(
            this.mockSinkFactory.Object,
            this.seedingOption);
    }

    [Test]
    [Retry(3)]
    public async Task ExecuteAsync_InvokedProvisionAsync()
    {
        await this.executor.ExecuteAsync(default);

        this.mockSink.Verify(
            x => x.ProvisionAsync(1, default),
            Times.Once());
    }

    [Test]
    [DependsOn(nameof(ExecuteAsync_InvokedProvisionAsync))]
    public async Task AfterExecution_ObjectNotNull()
    {
        await Assert.That(this.executor).IsNotNull();
    }
}
