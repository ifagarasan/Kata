namespace Pomodoro
{
    public interface ICycle
    {
        string Label { get; }
        int DurationInMiliseconds { get; }
    }
}