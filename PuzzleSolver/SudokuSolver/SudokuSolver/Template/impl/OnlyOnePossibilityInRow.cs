using System;
using System.Collections.Generic;
using SudokuSolver.BoardState;

namespace SudokuSolver.Template.impl
{
    public class OnlyOnePossibilityInRow : Strategy
    {
        public override bool FindChange(Board board)
        {
            for (int y = 0; y < board.Size; y += 1)
            {
                if (board.Puzzle[y].FindAll(FindAllEmpty).Count == 1)
                {
                    int emptyCellIndex = -1;
                    List<char> possibleCells = new List<char>();
                    for (int i = 0; i < board.Symbols.Count; i += 1)
                    {
                        possibleCells.Add(board.Symbols[i]);
                    }

                    for (int x = 0; x < board.Puzzle[y].Count; x += 1)
                    {
                        if (board.Puzzle[y][x].Value.Equals('-'))
                        {
                            emptyCellIndex = x;
                        }
                        possibleCells.Remove(board.Puzzle[y][x].Value);
                    }
                    board.Puzzle[y][emptyCellIndex].Value = possibleCells[0];
                    return true;
                }
            }
            return false;
        }
        private bool FindAllEmpty(Cell cell)
        {
            if (cell.Value.Equals('-'))
            {
                return true;
            }
            return false;
        }
    }
}
