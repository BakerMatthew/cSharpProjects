using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuSolverTest
{
    [TestClass]
    public class SolverTester
    {
        [TestMethod]
        public void TheSolverTester()
        {
            // Given
            Board board = new Board(Puzzle-4x4-0001.txt);
            Solver solver = new Solver();

            // When
            solver.SolvePuzzle(board);

            // Then
            Assert.IsTrue(board.HasWon());
        }

        [TestMethod]
        public void TheSolverTester()
        {
            // Given
            Board board = new Board(Puzzle-4x4-0902.txt);
            Solver solver = new Solver();

            // When
            solver.SolvePuzzle(board);

            // Then
            Assert.IsTrue(!board.HasWon());
        }
    }
}
