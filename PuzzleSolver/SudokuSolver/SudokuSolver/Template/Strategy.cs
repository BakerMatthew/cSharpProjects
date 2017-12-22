using System;
using System.Diagnostics;
using SudokuSolver.BoardState;

namespace SudokuSolver.Template
{
    public abstract class Strategy
    {
        public Stopwatch watch = new Stopwatch();
        private int uses = 0;

        public abstract bool FindChange(Board board);

        public bool RunStrategy(Board board)
        {
            StartTimer();
            bool changeFound = FindChange(board);
            if (changeFound)
            {
                uses += 1;
                ResolveChanges(board);
            }
            StopTimer();
            return changeFound;
        }

        private void ResolveChanges(Board board)
        {
            // Update row possibilities
            for (int y = 0; y < board.Size; y += 1)
            {
                for (int x = 0; x < board.Puzzle[y].Count; x += 1)
                {
                    for (int z = 0; z < board.Puzzle[y].Count; z += 1)
                    {
                        board.Puzzle[y][x].PossibleValues.Remove(board.Puzzle[y][z].Value);
                    }
                }
            }

            // Update column possibilities
            for (int x = 0; x < board.Size; x += 1)
            {
                for (int y = 0; y < board.Puzzle.Count; y += 1)
                {
                    for (int z = 0; z < board.Puzzle[y].Count; z += 1)
                    {
                        board.Puzzle[y][x].PossibleValues.Remove(board.Puzzle[z][x].Value);
                    }
                }
            }
        }
        private void StartTimer()
        {
            watch.Start();
        }
        private void StopTimer()
        {
            watch.Stop();
        }
        public string GetTime()
        {
            TimeSpan ts = watch.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                 ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        }
        public string GetUses()
        {
            return uses.ToString();
        }
    }
}
