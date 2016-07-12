using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.Social.Platform;

namespace SocialNetwork.FeatureTests
{
    [TestClass]
    public class Timeline
    {
        private Mock<IConsole> _consoleMock;
        private int _expectedIndex;
        private string[] _expected;
        private readonly DateTime _now = DateTime.Now;
        IInputRetriever _commandInputRetriever;
        Mock<IDateProvider> _presentDateProviderMock;
        Mock<IDateProvider> _sequenceDateProviderMock;
        ISocialPlatform _socialPlatform;

        [TestInitialize]
        public void Setup()
        {
            _expectedIndex = 0;

            _presentDateProviderMock = new Mock<IDateProvider>();
            _sequenceDateProviderMock = new Mock<IDateProvider>();

            _presentDateProviderMock.Setup(m => m.Now()).Returns(_now);

            _consoleMock = new Mock<IConsole>();

            _consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback<string>((message) =>
            {
                Assert.AreEqual(_expected[_expectedIndex++], message);
            });

            _commandInputRetriever = new InputRetriever(new InputParser(), _consoleMock.Object);

            ICommandFactory commandFactory = new CommandFactory(
                new Repository(new DateProvider()), new PostFormatter(new TimeOffsetCalculator(_sequenceDateProviderMock.Object),
                new TimeFormatter()), _consoleMock.Object);

            _socialPlatform = new SocialPlatform(_commandInputRetriever, commandFactory);
        }

        [TestMethod]
        public void ShouldDisplayAllMessagesForUser()
        {
            _consoleMock.SetupSequence(m => m.Read())
                .Returns("Alice -> I love the weather today")
                .Returns("Bob -> Damn! We lost!")
                .Returns("Bob -> Good game though.")
                .Returns("Alice")
                .Returns("Bob")
                .Returns("exit");

            _expected = new[]
            {
                "I love the weather today (5 minutes ago)",
                "Good game though. (1 minute ago)",
                "Damn! We lost! (2 minutes ago)"
            };

            _sequenceDateProviderMock.SetupSequence(m => m.Now()).Returns(_now.AddMinutes(5)).Returns(_now.AddMinutes(1)).Returns(_now.AddMinutes(2));

            _socialPlatform.Run();

            _consoleMock.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
