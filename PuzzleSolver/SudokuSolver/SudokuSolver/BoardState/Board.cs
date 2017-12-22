using System;
using System.Collections.Generic;
using System.IO;

namespace SudokuSolver.BoardState
{
    public class Board
    {
        public Board(string inputFilename)
        {
            Console.WriteLine(inputFilename);
            string[] inputBody = File.ReadAllLines(inputFilename);

            // Get Size
            Size = (int)char.GetNumericValue(inputBody[0][0]);

            // Get Block Size
            BlockSize = Convert.ToInt32(Math.Sqrt(Size));

            // Get Symbols
            Symbols = new List<char>();
            for (int i = 0; i < inputBody[1].Length; i += 1)
            {
                if (inputBody[1][i] != ' ')
                {
                    Symbols.Add(inputBody[1][i]);
                }
            }

            // Get Puzzle
            Puzzle = new List<List<Cell>>();
            for (int i = 2, boardIndex = 0; i < inputBody.Length - 1; i += 1, boardIndex += 1)
            {
                Puzzle.Add(new List<Cell>());
                for (int j = 0; j < inputBody[i].Length; j += 1)
                {
                    if (inputBody[i][j] != ' ')
                    {
                        Puzzle[boardIndex].Add(new Cell(inputBody[i][j], Symbols));
                    }
                }
            }

            // Deep copy Puzzle
            OriginalPuzzle = new List<List<Cell>>();
            for (int y = 0; y < Puzzle.Count; y += 1)
            {
                OriginalPuzzle.Add(new List<Cell>());
                for (int x = 0; x < Puzzle[y].Count; x += 1)
                {
                    OriginalPuzzle[y].Add(new Cell(Puzzle[y][x].Value, Symbols));
                }
            }
        }

        public int Size { get; set; }
        public int BlockSize { get; set; }
        public List<char> Symbols { get; set; }
        public List<List<Cell>> Puzzle { get; set; }
        private List<List<Cell>> OriginalPuzzle { get; set; }

        private string GetPrintHeader()
        {
            string header = "";
            header += Size.ToString();
            header += '\n';
            for (int i = 0; i < Symbols.Count; i += 1)
            {
                header += Symbols[i];
                header += ' ';
            }
            return header;
        }

        private string GetBoardToString()
        {
            string board = "";
            for (int i = 0; i < Puzzle.Count; i += 1)
            {
                for (int j = 0; j < Puzzle[i].Count; j += 1)
                {
                    board += Puzzle[i][j].Value;
                    board += " ";
                }
                board += '\n';
            }
            return board;
        }

        private string GetOriginalBoardToString()
        {
            string board = "";
            for (int i = 0; i < OriginalPuzzle.Count; i += 1)
            {
                for (int j = 0; j < OriginalPuzzle[i].Count; j += 1)
                {
                    board += OriginalPuzzle[i][j].Value;
                    board += " ";
                }
                board += '\n';
            }
            return board;
        }

        public void PrintBoardToConsole(string hasWonMessage, string time)
        {
            Console.WriteLine(GetPrintHeader());
            Console.WriteLine(GetOriginalBoardToString());
            Console.WriteLine("\n" + hasWonMessage);
            Console.WriteLine(GetBoardToString());
            Console.WriteLine(time);
        }

        public void PrintBoardToTextFile(string hasWonMessage, string outputFilename, string time)
        {
            FileStream fStream = new FileStream(outputFilename, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fStream);
            writer.WriteLine(GetPrintHeader());
            writer.WriteLine(GetOriginalBoardToString());
            writer.WriteLine("\n" + hasWonMessage);
            writer.WriteLine(GetBoardToString());
            writer.WriteLine(time);
            writer.Close();
        }

        public bool HasWon()
        {
            for (int y = 0; y < Puzzle.Count; y += 1)
            {
                for (int x = 0; x < Puzzle.Count; x += 1)
                {
                    if (Puzzle[y][x].Value.Equals('-'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
