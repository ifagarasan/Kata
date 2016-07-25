using TicTacToe.Board.Cell;

namespace TicTacToe.Board
{
    public interface IBoard
    {
        bool Full();
        Symbol Winner();
        bool HasWinner();
        Cell.Cell Retrieve(Position position);

        void Mark(Position position, Symbol symbol);
    }
}