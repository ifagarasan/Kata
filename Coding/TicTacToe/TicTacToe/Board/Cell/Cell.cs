namespace TicTacToe.Board.Cell
{
    public class Cell
    {
        private Symbol _symbol;
        private readonly Position _position;

        public Cell(Index row, Index index, Symbol symbol)
        {
            _position = new Position(row, index);
            _symbol = symbol;
        }

        public Index Row() => _position.Row();

        public Index Column() => _position.Column();

        public Symbol Mark(Symbol symbol) => _symbol = symbol;

        public Symbol Retrieve() => _symbol;
    }
}