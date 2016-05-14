using System;

namespace TicTackToe
{
    public class BoardValidator : IBoardValidator
    {
        public void Validate(BoardData data)
        {
            if (data.Winners.Count > 1)
                throw new InvalidBoardException();
        }
    }
}