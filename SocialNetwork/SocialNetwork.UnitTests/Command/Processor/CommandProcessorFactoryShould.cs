using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Command;
using SocialNetwork.Command.Processor;

namespace SocialNetwork.UnitTests.Command.Processor
{
    [TestClass]
    public class CommandProcessorFactoryShould
    {
        [TestMethod]
        public void ReturnsPostCommandProcessor()
        {
            var username = "test";
            var content = "content";

            Post command = new Post(username, content);

            CommandProcessorFactory commandProcessorFactory = new CommandProcessorFactory(null, null);

            var commandProcessor = commandProcessorFactory.Create(command);

            Assert.IsInstanceOfType(commandProcessor, typeof(PostProcessor));
        }
    }
}
