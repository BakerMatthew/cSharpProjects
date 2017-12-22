using System;
namespace SudokuSolver
{
    public static class StatusMessages
    {
        public const string VALID_ARGUMENTS = "Valid arguments:\n" +
            "  " + HELP_ARGUMENT + " : Displays valid command line arguments.\n" +
            "  <input file name> : Reads puzzle from the given input file and writes result to console.\n" +
            "  <input file name> <output file name> : Reads puzzle from the given input file and writes result to given output file.\n";
        public const string EXIT_MESSAGE = "Exiting Program.\n";
        public const string NO_ARGUMENTS_ERROR = "ERROR: No arguments given.\n";
        public const string INVALID_IN_TEXT_FILE_ERROR = "ERROR: Input file must be a valid .txt file.\n";
        public const string INVALID_OUT_TEXT_FILE_ERROR = "ERROR: Output file must be a valid .txt file.\n";
        public const string FILE_NOT_FOUND_ERROR = "ERROR: Input file not found.\n";
		
        public const string HELP_ARGUMENT = "-h";
        public const string EXTENSION_TEXT = ".txt";
		
        public const uint INPUT_FILE_INDEX = 0;
        public const uint OUTPUT_FILE_INDEX = 1;
        public const uint EXPECTED_MAX_ARGUMENT_COUNT = 2;
    }
}
