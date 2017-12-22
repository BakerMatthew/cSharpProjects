using System;
using System.Collections.Generic;
using SudokuSolver.BoardState;
using SudokuSolver.Template;
using SudokuSolver.Template.impl;

namespace SudokuSolver
{
    public class Solver
    {
        readonly List<Strategy> strategies;

        public Solver()
        {
            strategies = new List<Strategy>() {
                new OnlyOnePossibilityInRow(),
                new OnlyOnePossibilityInColumn(),
                new OnlyOnePossibilityInBlock()
            };
        }

        public void SolvePuzzle(Board board)
        {
            ApplyStrategies(board);
        }

        public string GetTimes()
        {
            string times = "";
            TimeSpan ts = new TimeSpan();
            foreach (Strategy strategy in strategies)
            {
                ts += strategy.watch.Elapsed;
                times += strategy.ToString();
                times += ", ";
                times += strategy.GetUses();
                times += ", ";
                times += strategy.GetTime();
                times += '\n';
            }
            times += "Total Time: ";
            times += String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                   ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            return times;
        }

        private void ApplyStrategies(Board board)
        {
            bool hasChanged = true;
            while (hasChanged)
            {
                hasChanged = false;
                foreach (Strategy strategy in strategies)
                {
                    if (strategy.RunStrategy(board))
                    {
                        hasChanged = true;
                        break;
                    }
                }
            }
        }
    }
}
