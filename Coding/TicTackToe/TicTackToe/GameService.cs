using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTackToe
{
    public class GameService
    {
        char NoWinner = ' ';

        IBoardValidator boardValidator;

        public GameService(IBoardValidator boardValidator)
        {
            this.boardValidator = boardValidator;
        }

        public char GetWinner(char[,] board)
        {
            char winner = NoWinner;

            BoardData boardData = new BoardData();

            FindHorizontalWinner(board, boardData);
            FindVerticalWinner(board, boardData);
            FindMainDiagonalWinner(board, boardData);
            FindSecondaryDiagonalWinner(board, boardData);

            boardValidator.Validate(boardData);

            if (boardData.Winners.Count == 0)
                boardData.Winners.Add(NoWinner);

            return boardData.Winners[0];
        }

        private void FindMainDiagonalWinner(char[,] board, BoardData boardData)
        {
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                boardData.Winners.Add(board[1, 1]);
        }

        private void FindSecondaryDiagonalWinner(char[,] board, BoardData boardData)
        {
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                boardData.Winners.Add(board[1, 1]);
        }

        private void FindVerticalWinner(char[,] board, BoardData data)
        {
            for (int i = 0; i < 3; ++i)
            {
                char current = board[0, i] == board[1, i] && board[2, i] == board[2, i] ? board[0, i] : NoWinner;
                if (current != NoWinner)
                    data.Winners.Add(current);
            }
        }

        private void FindHorizontalWinner(char[,] board, BoardData data)
        {
            for (int i = 0; i < 3; ++i)
            {
                char current = board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] ? board[i, 0] : NoWinner;

                if (current != NoWinner)
                    data.Winners.Add(current);
            }
        }
    }
}
