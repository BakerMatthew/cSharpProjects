namespace PersonMatcher.model
{
    public static class ErrorMessage
    {
		public static string USAGE_MESSAGE = "Usage: PersonMatcher ALGORITHM_INT INPUTFILE.EXTENSION [OUTPUTFILE.EXTENSION]";
		public static string ARGUMENT_COUNT_FORMAT = "Incorrect argument count. Expected: 2 or 3. Found: {0}.";
		public static string NULL_IO_MANAGER = "IOManager was null.";
		public static string BAD_ALGORITHM_FORMAT = "Error with argument ALGORITHM_INT. Expected: an {integer}. Found: {0}";
        public static string BAD_ALGORITHM_SELECTION_FORMAT = "Error with argument ALGORITHM_INT. Expected: an {integer} between 0 and {0}. Found: {1}";
		public static string BAD_INPUTFILE_FORMAT = "Error with argument INPUTFILE_STRING. Expected: a {string.extension}. Found: {0}";
	}
}
