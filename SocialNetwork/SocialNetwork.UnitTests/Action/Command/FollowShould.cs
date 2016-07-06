using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Follow = SocialNetwork.Action.Command.Follow;

namespace SocialNetwork.UnitTests.Action.Command
{
    [TestClass]
    public class FollowShould: CommandShould
    {
        [TestMethod]
        public void Follow()
        {
            SocialEngineMock.Setup(m => m.Follow(It.IsAny<string>(), It.IsAny<string>()));

            var args = new[] { "Alice", "Bob" };

            new Follow(SocialEngineMock.Object, ConsoleMock.Object, args).Execute();

            SocialEngineMock.Verify(m => m.Follow(args[0], args[1]));
        }
    }
}
