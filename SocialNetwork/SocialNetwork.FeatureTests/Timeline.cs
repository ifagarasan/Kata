using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command.Processor;

namespace SocialNetwork.FeatureTests
{
    [TestClass]
    public class Timeline
    {
        [TestMethod]
        public void ShoulDisplayAllMessagesForUser()
        {
            Mock<IConsole> consoleMock = new Mock<IConsole>();

            consoleMock.SetupSequence(m => m.Read())
                .Returns("Alice->I love the weather today")
                .Returns("Bob->Damn!We lost!")
                .Returns("Bob->Good game though.")
                .Returns("Alice")
                .Returns("Bob")
                .Returns("exit");

            var expectedIndex = 0;
            var expected = new string[]
            {
                "I love the weather today (5 minutes ago)",
                "Good game though. (1 minute ago)",
                "Damn! We lost! (2 minutes ago)"
            };

            consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback<string>((message) =>
            {
                Assert.AreEqual(expected[expectedIndex++], message);
            });

            ICommandDispatcher commandDispatcher = new CommandDispatcher(new CommandTranslator(), consoleMock.Object);
            ICommandProcessorFactory commandProcessorFactory = new CommandProcessorFactory(new SocialEngine(new Repository()), consoleMock.Object);

            ISocialPlatform socialPlatform = new SocialPlatform(commandDispatcher, commandProcessorFactory);

            socialPlatform.Run();

            consoleMock.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
