namespace Pomodoro
{
    public class ShortPause: Cycle
    {
        public ShortPause() : base("Short Pause", Util.MinutesToMiliseconds(5)) { }
    }
}