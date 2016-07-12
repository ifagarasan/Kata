using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Infrastructure.Console;
using SocialNetwork.Model.Social.Engine;
using SocialNetwork.Model.User;
using SocialNetwork.UnitTests.Model.Command;
using DisplayWall = SocialNetwork.Action.Command.DisplayWall;

namespace SocialNetwork.UnitTests.Action
{
    [TestClass]
    public class DisplayWallShould
    {
        private Mock<ISocialEngine> _socialEngineMock;
        private Mock<IConsole> _consoleMock;

        [TestInitialize]
        public void Setup()
        {
            _consoleMock = new Mock<IConsole>();
            _consoleMock.Setup(m => m.Write(It.IsAny<string>()));

            _socialEngineMock = new Mock<ISocialEngine>();
        }

        [TestMethod]
        public void PrintWall()
        {
            var user = new User("test");
            var message = "Bob - I'm in London! (1 minute ago)";
            var userMessages = new List<string> { message };

            _socialEngineMock.Setup(m => m.RetrieveWall(It.IsAny<User>())).Returns(userMessages);

            new DisplayWall(_socialEngineMock.Object, _consoleMock.Object, user).Execute();

            _socialEngineMock.Verify(m => m.RetrieveWall(user));
            _consoleMock.Verify(m => m.Write(message));
        }
    }
}
