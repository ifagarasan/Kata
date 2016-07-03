using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;

namespace SocialNetwork.UnitTests.Command.Processor
{
    [TestClass]
    public class PostProcessorShould
    {
        [TestMethod]
        public void Insert()
        {
            Mock<ISocialEngine> socialEngineMock = new Mock<ISocialEngine>();
            socialEngineMock.Setup(m => m.Post(It.IsAny<string>(), It.IsAny<string>()));

            Mock<IConsole> consoleMock = new Mock<IConsole>();

            ICommandProcessor processor = new PostProcessor(socialEngineMock.Object, consoleMock.Object);

            var username = "test";
            var content = "content";

            Post command = new Post(username, content);

            processor.Process(command);
        }

        //[TestMethod]
        //public void DisplayOnDisplayUserPosts()
        //{
        //    Mock<ISocialEngine> socialEngineMock = new Mock<ISocialEngine>();
        //    socialEngineMock.Setup(m => m.Post(It.IsAny<string>(), It.IsAny<string>()));

        //    Mock<IConsole> consoleMock = new Mock<IConsole>();

        //    ICommandProcessor processor = new CommandProcessor(socialEngineMock.Object, consoleMock.Object);

        //    var username = "test";

        //    DisplayUserPosts userPosts = new DisplayUserPosts(username);

        //    processor.Process(userPosts);
        //}
    }
}
