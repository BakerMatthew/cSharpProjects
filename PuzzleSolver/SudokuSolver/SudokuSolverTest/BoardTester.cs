using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuSolverTest
{
    [TestClass]
    public class BoardTester
    {
        [TestMethod]
        public void TheBoardTester()
        {
            // Given
            string inputFile = "Puzzle-4x4-0001.txt";

            //When
            Board board = new Board(inputFile);

            // Then
            Assert.AreEqual(4, board.Size());
            Assert.AreEqual(2, board.BlockSize());
            Assert.AreEqual(new List<char>() { '1', '2', '3', '4' }, board.Symbols());
        }

        [TestMethod]
        public void TheBadFileBoardTester()
        {
            // Given
            string inputFile = "Puzzle-4x4-0001-bad.txt";

            //When
            Board board = new Board(inputFile);

            // Then
            Assert.AreEqual(4, board.Size());
            Assert.AreEqual(2, board.BlockSize());
            Assert.AreEqual(new List<char>() { '1', '2', '3', '4' }, board.Symbols());
        }

        [TestMethod]
        public void TheBadExtensionBoardTester()
        {
            // Given
            string inputFile = "Puzzle-4x4-0001.bad";

            //When
            Board board = new Board(inputFile);

            // Then
            Assert.AreEqual(4, board.Size());
            Assert.AreEqual(2, board.BlockSize());
            Assert.AreEqual(new List<char>() { '1', '2', '3', '4' }, board.Symbols());
        }
    }
}
