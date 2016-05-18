namespace Pomodoro
{
    public class Cycle : ICycle
    {
        public string Label { get; }
        public uint DurationInMiliseconds { get; }

        public Cycle(string label, uint durationInMiliseconds)
        {
            Label = label;
            DurationInMiliseconds = durationInMiliseconds;
        }
    }
}