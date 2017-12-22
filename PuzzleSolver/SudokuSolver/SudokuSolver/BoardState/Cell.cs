using System;
using System.Collections.Generic;

namespace SudokuSolver.BoardState
{
    public class Cell
    {
        public Cell(char value, List<char> possibleValues)
        {
            Value = value;
            PossibleValues = new List<char>();
            for (int i = 0; i < possibleValues.Count; i += 1)
            {
                PossibleValues.Add(possibleValues[i]);
            }
        }

        public char Value { get; set; }
        public List<char> PossibleValues { get; set; }
    }
}
