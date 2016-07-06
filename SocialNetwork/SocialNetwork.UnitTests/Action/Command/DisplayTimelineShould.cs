using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action;
using SocialNetwork.Infrastructure;
using DisplayTimeline = SocialNetwork.Action.Command.DisplayTimeline;

namespace SocialNetwork.UnitTests.Action.Command
{
    [TestClass]
    public class DisplayTimelineShould: CommandShould
    {
        [TestMethod]
        public void PrintTimeline()
        {
            var message = "I'm in London! (1 minute ago)";
            var userMessages = new List<string> { message };

            SocialEngineMock.Setup(m => m.RetrieveTimeline(It.IsAny<string>())).Returns(userMessages);

            var args = new[] { "test" };

            new DisplayTimeline(SocialEngineMock.Object, ConsoleMock.Object, args).Execute();

            SocialEngineMock.Verify(m => m.RetrieveTimeline(args[0]));
            ConsoleMock.Verify(m => m.Write(message));
        }
    }
}
