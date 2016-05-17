namespace Pomodoro
{
    public class Cycle : ICycle
    {
        public string Label { get; }
        public int DurationInMiliseconds { get; }

        public Cycle(string label, int durationInMiliseconds)
        {
            Label = label;
            DurationInMiliseconds = durationInMiliseconds;
        }
    }
}