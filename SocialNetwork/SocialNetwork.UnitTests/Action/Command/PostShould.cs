using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action.Command;

namespace SocialNetwork.UnitTests.Action.Command
{
    [TestClass]
    public class PostShould: CommandShould
    {
        [TestMethod]
        public void Insert()
        {
            SocialEngineMock.Setup(m => m.Post(It.IsAny<string>(), It.IsAny<string>()));

            var args = new[] {"test", "content"};
            new Post(SocialEngineMock.Object, ConsoleMock.Object, args).Execute();

            SocialEngineMock.Verify(m => m.Post(args[0], args[1]));
        }
    }
}
