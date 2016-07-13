using System;

namespace Pomodoro.Exceptions
{
    public class InvalidTimeOffsetException: Exception
    {
        public InvalidTimeOffsetException() { }

        public InvalidTimeOffsetException(string message): base(message) { }
    }
}