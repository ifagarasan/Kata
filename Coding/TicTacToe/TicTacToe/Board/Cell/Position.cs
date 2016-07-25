namespace TicTacToe.Board.Cell
{
    public class Position
    {
        private readonly Index _row;
        private readonly Index _column;

        public Position(Index row, Index column)
        {
            _row = row;
            _column = column;
        }

        public Index Column() => _column;

        public Index Row() => _row;
    }
}