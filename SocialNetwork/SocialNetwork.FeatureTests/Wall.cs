using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;
using SocialNetwork.Date;
using SocialNetwork.Time;

namespace SocialNetwork.FeatureTests
{
    [TestClass]
    public class Wall
    {
        [TestMethod]
        public void ShouldDisplayAllMessagesForUser()
        {
            Mock<IConsole> consoleMock = new Mock<IConsole>();

            consoleMock.SetupSequence(m => m.Read())
                .Returns("Bob -> Damn! We lost!")
                .Returns("Bob -> Good game though.")
                .Returns("Bob wall")
                .Returns("exit");

            var expectedIndex = 0;
            var expected = new[]
            {
                "Good game though. (1 minute ago)",
                "Damn! We lost! (2 minutes ago)"
            };

            consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback<string>((message) =>
            {
                Assert.AreEqual(expected[expectedIndex++], message);
            });

            ICommandDispatcher commandDispatcher = new CommandDispatcher(new CommandTranslator(), consoleMock.Object);

            var now = DateTime.Now;

            var presentDateProviderMock = new Mock<IDateProvider>();
            presentDateProviderMock.Setup(m => m.Now()).Returns(now);

            var sequenceDateProviderMock = new Mock<IDateProvider>();
            sequenceDateProviderMock.SetupSequence(m => m.Now()).Returns(now.AddMinutes(1)).Returns(now.AddMinutes(2));

            ICommandProcessorFactory commandProcessorFactory = new CommandProcessorFactory(
                new SocialEngine(new Repository(new DateProvider()),
                new PostFormatter(new TimeOffsetCalculator(sequenceDateProviderMock.Object))), consoleMock.Object);

            ISocialPlatform socialPlatform = new SocialPlatform(commandDispatcher, commandProcessorFactory);

            socialPlatform.Run();

            consoleMock.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
