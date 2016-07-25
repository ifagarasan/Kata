using TicTacToe.Board;
using TicTacToe.Board.Cell;
using static TicTacToe.Board.Cell.Index;
using static TicTacToe.Board.Cell.Symbol;

namespace TicTacToe.FeatureTests.Test
{
    public static class BoardMother
    {
        public static IBoard MakeEmpty() => new TicTacToe.Board.Board();

        public static IBoard Make(Symbol[] symbols)
        {
            var board = MakeEmpty();

            board.Mark(new Position(One, One), symbols[0]);
            board.Mark(new Position(One, Two), symbols[1]);
            board.Mark(new Position(One, Three), symbols[2]);
                       
            board.Mark(new Position(Two, One), symbols[3]);
            board.Mark(new Position(Two, Two), symbols[4]);
            board.Mark(new Position(Two, Three), symbols[5]);
                       
            board.Mark(new Position(Three, One), symbols[6]);
            board.Mark(new Position(Three, Two), symbols[7]);
            board.Mark(new Position(Three, Three), symbols[8]);

            return board;
        }

        public static IBoard MakeStalemate() => Make(new[]
        {
            Cross, O, Cross,
            O, Cross, O,
            O, Cross, O
        });

        public static IBoard MakeInProgress()
        {
            return Make(new[]
            {
                Cross, O, Cross,
                O, Empty, O,
                O, Cross, O
            });
        }

        public static IBoard MakeCrossWin()
        {
            return Make(new[]
            {
                Cross, Cross, Cross,
                O, Empty, O,
                O, Cross, O
            });
        }

        public static IBoard MakeLineWinner(Index row, Symbol symbol)
        {
            var board = MakeEmpty();

            board.Mark(new Position(row, One), symbol);
            board.Mark(new Position(row, Two), symbol);
            board.Mark(new Position(row, Three), symbol);

            return board;
        }

        public static IBoard MakeColumnWinner(Index column, Symbol symbol)
        {
            var board = MakeEmpty();

            board.Mark(new Position(One, column), symbol);
            board.Mark(new Position(Two, column), symbol);
            board.Mark(new Position(Three, column), symbol);

            return board;
        }

        public static IBoard MakeMainDiagonalWinner(Symbol symbol)
        {
            var board = MakeEmpty();

            board.Mark(new Position(One, One), symbol);
            board.Mark(new Position(Two, Two), symbol);
            board.Mark(new Position(Three, Three), symbol);

            return board;
        }

        public static IBoard MakeSecondaryDiagonalWinner(Symbol symbol)
        {
            var board = MakeEmpty();

            board.Mark(new Position(One, Three), symbol);
            board.Mark(new Position(Two, Two), symbol);
            board.Mark(new Position(Three, One), symbol);

            return board;
        }
    }
}
