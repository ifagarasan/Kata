using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DisplayWall = SocialNetwork.Action.Command.DisplayWall;

namespace SocialNetwork.UnitTests.Action.Command
{
    [TestClass]
    public class DisplayWallShould: CommandShould
    {
        [TestMethod]
        public void PrintWall()
        {
            var message = "Bob - I'm in London! (1 minute ago)";
            var userMessages = new List<string> { message };

            SocialEngineMock.Setup(m => m.RetrieveWall(It.IsAny<string>())).Returns(userMessages);

            var args = new [] { "test" };

            new DisplayWall(SocialEngineMock.Object, ConsoleMock.Object, args).Execute();
            
            SocialEngineMock.Verify(m => m.RetrieveWall(args[0]));
            ConsoleMock.Verify(m => m.Write(message));
        }
    }
}
