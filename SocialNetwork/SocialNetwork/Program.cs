using SocialNetwork.Action;
using SocialNetwork.Action.Command;
using SocialNetwork.Action.Command.Input;
using SocialNetwork.Action.Format;
using SocialNetwork.Infrastructure.Date;
using SocialNetwork.Infrastructure.Format;
using SocialNetwork.Infrastructure.Time;
using SocialNetwork.Model;

namespace SocialNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dateProvider = new DateProvider();
            var console = new Infrastructure.Console();
            var socialEngine = new SocialEngine(new Repository(dateProvider),
                new PostFormatter(new TimeOffsetCalculator(dateProvider), new TimeFormatter()));

            var socialPlatform = new SocialPlatform(new InputRetriever(new InputBuilder(), console),
                new CommandFactory(socialEngine, console));   

            socialPlatform.Run();
        }
    }
}
