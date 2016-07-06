using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action;
using SocialNetwork.Action.Command;
using SocialNetwork.Action.Command.Input;
using SocialNetwork.Action.Format;
using SocialNetwork.Infrastructure;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model;

namespace SocialNetwork.FeatureTests
{
    [TestClass]
    public class Timeline
    {
        [TestMethod]
        public void ShouldDisplayAllMessagesForUser()
        {
            Mock<IConsole> consoleMock = new Mock<IConsole>();

            consoleMock.SetupSequence(m => m.Read())
                .Returns("Alice -> I love the weather today")
                .Returns("Bob -> Damn! We lost!")
                .Returns("Bob -> Good game though.")
                .Returns("Alice")
                .Returns("Bob")
                .Returns("exit");

            var expectedIndex = 0;
            var expected = new[]
            {
                "I love the weather today (5 minutes ago)",
                "Good game though. (1 minute ago)",
                "Damn! We lost! (2 minutes ago)"
            };

            consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback<string>((message) =>
            {
                Assert.AreEqual(expected[expectedIndex++], message);
            });

            ITaskDispatcher taskDispatcher = new TaskDispatcher(new InputBuilder(), consoleMock.Object);

            var now = DateTime.Now;

            var presentDateProviderMock = new Mock<IDateProvider>();
            presentDateProviderMock.Setup(m => m.Now()).Returns(now);

            var sequenceDateProviderMock = new Mock<IDateProvider>();
            sequenceDateProviderMock.SetupSequence(m => m.Now()).Returns(now.AddMinutes(5)).Returns(now.AddMinutes(1)).Returns(now.AddMinutes(2));

            ICommandFactory commandFactory = new CommandFactory(
                new SocialEngine(new Repository(new DateProvider()),
                new PostFormatter(new TimeOffsetCalculator(sequenceDateProviderMock.Object), new TimeFormatter())), consoleMock.Object);

            ISocialPlatform socialPlatform = new SocialPlatform(taskDispatcher, commandFactory);

            socialPlatform.Run();

            consoleMock.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
