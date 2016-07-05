using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;

namespace SocialNetwork.UnitTests.Command.Processor
{
    [TestClass]
    public class FollowProcessorShould
    {
        [TestMethod]
        public void Follow()
        {
            var socialEngineMock = new Mock<ISocialEngine>();
            socialEngineMock.Setup(m => m.Follow(It.IsAny<string>(), It.IsAny<string>()));

            var consoleMock = new Mock<IConsole>();

            FollowProcessor processor = new FollowProcessor(socialEngineMock.Object, consoleMock.Object);

            var username = "Alice";
            var followUsername = "Bob";

            var command = new Follow(username, followUsername);

            processor.Process(command);

            socialEngineMock.Setup(m => m.Follow(username, followUsername));
        }
    }
}
