using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTackToe;
using Moq;

namespace TicTackToe_Tests
{
    [TestClass]
    public class BoardValidatorFunctionality
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidBoardException))]
        public void ThrowsInvalidBoardExceptionIfBoardDataSpecifiesMultipleWinners()
        {
            BoardData boardData = new BoardData();

            boardData.Winners.Add('X');
            boardData.Winners.Add('0');

            BoardValidator validator = new BoardValidator();

            validator.Validate(boardData);
        }
    }
}
