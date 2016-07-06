using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Action;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.UnitTests.Action.Command
{
    [TestClass]
    public abstract class CommandShould
    {
        protected Mock<ISocialEngine> SocialEngineMock { get; private set; }

        protected Mock<IConsole> ConsoleMock { get; private set; }

        [TestInitialize]
        public virtual void Setup()
        {
            ConsoleMock = new Mock<IConsole>();
            ConsoleMock.Setup(m => m.Write(It.IsAny<string>()));

            SocialEngineMock = new Mock<ISocialEngine>();
        }
    }
}
