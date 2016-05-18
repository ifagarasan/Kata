namespace Pomodoro
{
    public interface ICycle
    {
        string Label { get; }
        uint DurationInMiliseconds { get; }
    }
}