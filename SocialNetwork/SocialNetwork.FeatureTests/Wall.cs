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
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.Social.Platform;

namespace SocialNetwork.FeatureTests
{
    [TestClass]
    public class Wall
    {
        Mock<IConsole> _consoleMock;
        IInputRetriever _commandInputRetriever;
        private DateTime _now = DateTime.Now;
        Mock<IDateProvider> _presentDateProviderMock;
        Mock<IDateProvider> _sequenceDateProviderMock;
        ICommandFactory _commandFactory;
        ISocialPlatform _socialPlatform;

        string[] _expected;
        int _expectedIndex;

        [TestInitialize]
        public void Setup()
        {
            _expectedIndex = 0;

            _consoleMock = new Mock<IConsole>();

            _consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback<string>(message =>
            {
                Assert.AreEqual(_expected[_expectedIndex++], message);
            });

            _commandInputRetriever = new InputRetriever(new InputParser(), _consoleMock.Object);

            _sequenceDateProviderMock = new Mock<IDateProvider>();
            _presentDateProviderMock = new Mock<IDateProvider>();

            _presentDateProviderMock.Setup(m => m.Now()).Returns(_now);

            _commandFactory = new CommandFactory(
                new SocialEngine(new Repository(new DateProvider()),
                    new PostFormatter(new TimeOffsetCalculator(_sequenceDateProviderMock.Object), new TimeFormatter())), _consoleMock.Object);

            _socialPlatform = new SocialPlatform(_commandInputRetriever, _commandFactory);
        }

        [TestMethod]
        public void ShouldDisplayMessagesFromFollowedUsers()
        {
            _consoleMock.SetupSequence(m => m.Read())
                .Returns("Alice -> I love the weather today")
                .Returns("Bob -> Damn! We lost!")
                .Returns("Bob -> Good game though.")

                .Returns("Charlie -> I\'m in New York today! Anyone want to have a coffee?")
                .Returns("Charlie follows Alice")
                .Returns("Charlie wall")
                .Returns("Charlie follows Bob")
                .Returns("Charlie wall")

                .Returns("exit");

            _expected = new[]
            {
                "Charlie - I\'m in New York today! Anyone want to have a coffee? (2 seconds ago)",
                "Alice - I love the weather today (5 minutes ago)",
                "Charlie - I\'m in New York today! Anyone want to have a coffee? (15 seconds ago)",
                "Bob - Good game though. (1 minute ago)",
                "Bob - Damn! We lost! (2 minutes ago)",
                "Alice - I love the weather today (5 minutes ago)"
            };

            _sequenceDateProviderMock.SetupSequence(m => m.Now())
                .Returns(_now.AddSeconds(2))
                .Returns(_now.AddMinutes(5))
                .Returns(_now.AddSeconds(15))
                .Returns(_now.AddMinutes(1))
                .Returns(_now.AddMinutes(2))
                .Returns(_now.AddMinutes(5));

            _socialPlatform.Run();

            _consoleMock.Verify(m => m.Write(It.IsAny<string>()), Times.Exactly(6));
        }
    }
}