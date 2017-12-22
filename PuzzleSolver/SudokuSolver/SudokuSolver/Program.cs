using System;
using System.IO;
using SudokuSolver.BoardState;

namespace SudokuSolver
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (!IsInputValid(args))
            {
                Console.WriteLine(StatusMessages.EXIT_MESSAGE);
                return;
            }

            string inputFilename = args[StatusMessages.INPUT_FILE_INDEX];
            string outputFilename = null;
            OutputState output = OutputState.console; // BRANCH: Output to Console
            if (args.Length == 2) // BRANCH: Output to given text file
            {
                output = OutputState.textFile;
                outputFilename = args[StatusMessages.OUTPUT_FILE_INDEX];
            }

            Board board = new Board(inputFilename);

            Solver solver = new Solver();
            solver.SolvePuzzle(board);

            string hasWonMessage = "Solved";
            if (!board.HasWon())
            {
                hasWonMessage = "Unsolvable";
            }

            if (board.HasWon())
            {
                switch (output)
                {
                    case OutputState.console:
                        board.PrintBoardToConsole(hasWonMessage, solver.GetTimes());
                        break;
                    case OutputState.textFile:
                        board.PrintBoardToTextFile(hasWonMessage, outputFilename, solver.GetTimes());
                        break;
                }
            }
        }

        private static bool IsInputValid(string[] args)
        {
            // Validate initial input
            if (args.Length == 0 || args.Length > StatusMessages.EXPECTED_MAX_ARGUMENT_COUNT)
            {
                Console.WriteLine(StatusMessages.NO_ARGUMENTS_ERROR + StatusMessages.VALID_ARGUMENTS);
                return false;
            }
            if (args[StatusMessages.INPUT_FILE_INDEX].Equals(StatusMessages.HELP_ARGUMENT))
            {
                Console.WriteLine(StatusMessages.VALID_ARGUMENTS);
                return false;
            }

            // Validate input text file
            if (!args[StatusMessages.INPUT_FILE_INDEX].EndsWith(StatusMessages.EXTENSION_TEXT))
            {
                Console.WriteLine(StatusMessages.INVALID_IN_TEXT_FILE_ERROR);
                return false;
            }
            // Validate input text file exists
            if (!File.Exists(args[StatusMessages.INPUT_FILE_INDEX]))
            {
                Console.WriteLine(StatusMessages.FILE_NOT_FOUND_ERROR);
                return false;
            }

            // Validate output text file
            if (args.Length == 2 && !args[StatusMessages.OUTPUT_FILE_INDEX].EndsWith(StatusMessages.EXTENSION_TEXT))
            {
                Console.WriteLine(StatusMessages.INVALID_OUT_TEXT_FILE_ERROR);
                return false;
            }

            return true;
        }
    }
}
