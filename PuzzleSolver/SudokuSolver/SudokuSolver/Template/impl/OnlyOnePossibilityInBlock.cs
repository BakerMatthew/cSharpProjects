using System;
using System.Collections.Generic;
using SudokuSolver.BoardState;

namespace SudokuSolver.Template.impl
{
    public class OnlyOnePossibilityInBlock : Strategy
    {
        public override bool FindChange(Board board)
        {
            for (int yBlock = 0; yBlock < board.Puzzle.Count; yBlock += board.BlockSize)
            {
                for (int xBlock = 0; xBlock < board.Puzzle.Count; xBlock += board.BlockSize)
                {
                    int emptyCellIndexX = -1;
                    int emptyCellIndexY = -1;
                    List<char> possibleCells = new List<char>();
                    for (int i = 0; i < board.Symbols.Count; i += 1)
                    {
                        possibleCells.Add(board.Symbols[i]);
                    }

                    for (int y = yBlock; y < yBlock + board.BlockSize; y += 1)
                    {
                        for (int x = xBlock; x < xBlock + board.BlockSize; x += 1)
                        {
                            if (board.Puzzle[y][x].Value.Equals('-'))
                            {
                                emptyCellIndexX = x;
                                emptyCellIndexY = y;
                            }
                            possibleCells.Remove(board.Puzzle[y][x].Value);
                        }
                    }

                    if (possibleCells.Count == 1 && emptyCellIndexX != -1 && emptyCellIndexY != -1)
                    {
                        board.Puzzle[emptyCellIndexY][emptyCellIndexX].Value = possibleCells[0];
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
