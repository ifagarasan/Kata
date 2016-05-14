using System;

namespace TicTackToe
{
    public class InvalidBoardException: Exception
    {
        public InvalidBoardException() { }

        public InvalidBoardException(string message): base(message) { }
    }
}