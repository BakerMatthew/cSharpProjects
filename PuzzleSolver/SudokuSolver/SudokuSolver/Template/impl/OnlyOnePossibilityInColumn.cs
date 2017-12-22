using System;
using System.Collections.Generic;
using SudokuSolver.BoardState;

namespace SudokuSolver.Template.impl
{
    public class OnlyOnePossibilityInColumn : Strategy
    {
        public override bool FindChange(Board board)
        {
            for (int x = 0; x < board.Size; x += 1)
            {
                int emptyCellIndex = -1;
                List<char> possibleCells = new List<char>();
                for (int i = 0; i < board.Symbols.Count; i += 1)
                {
                    possibleCells.Add(board.Symbols[i]);
                }

                for (int y = 0; y < board.Puzzle.Count; y += 1)
                {
                    if (board.Puzzle[y][x].Value.Equals('-'))
                    {
                        emptyCellIndex = y;
                    }
                    possibleCells.Remove(board.Puzzle[y][x].Value);
                }
                if (possibleCells.Count == 1 && emptyCellIndex != -1)
                {
                    board.Puzzle[emptyCellIndex][x].Value = possibleCells[0];
                    return true;
                }
            }
            return false;
        }
    }
}
