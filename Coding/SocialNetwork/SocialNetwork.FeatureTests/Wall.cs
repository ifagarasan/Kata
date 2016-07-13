﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Repository;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model.Command;
using SocialNetwork.Model.Command.Input;
using SocialNetwork.Model.Post;
using SocialNetwork.Model.Post.Format;
using SocialNetwork.Model.Post.Writer;
using SocialNetwork.Model.Social.Platform;

namespace SocialNetwork.FeatureTests
{
    [TestClass]
    public class Wall
    {
        Mock<IConsole> _consoleMock;
        private DateTime _now = DateTime.Now;
        Mock<IDateProvider> _presentDateProviderMock;
        Mock<IDateProvider> _sequenceDateProviderMock;
        ICommandFactory _commandFactory;
        ISocialPlatform _socialPlatform;

        string[] _expected;
        int _expectedIndex;
        private IPostWriter _wallWriter;

        [TestInitialize]
        public void Setup()
        {
            _expectedIndex = 0;

            _consoleMock = new Mock<IConsole>();

            _consoleMock.Setup(m => m.Write(It.IsAny<string>())).Callback<string>(message =>
            {
                Assert.AreEqual(_expected[_expectedIndex++], message);
            });

            _sequenceDateProviderMock = new Mock<IDateProvider>();
            _presentDateProviderMock = new Mock<IDateProvider>();
            _presentDateProviderMock.Setup(m => m.Now()).Returns(_now);

            var postTimeFormatter = new PostTimeFormatter(new TimeOffsetCalculator(_sequenceDateProviderMock.Object), new TimeFormatter());
            _wallWriter = new PostWriter(new WallPostFormatter(postTimeFormatter), _consoleMock.Object);

            _commandFactory = new CommandFactory(new PostRepository(new DateProvider()), new UserRepository(), _wallWriter, null);
            _socialPlatform = new SocialPlatform(new InputParser(), _consoleMock.Object, _commandFactory);
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