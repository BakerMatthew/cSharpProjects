using System;
using PersonMatcher.Algorithm;
using PersonMatcher.IO;
using PersonMatcher.IO.impl;
using PersonMatcher.model;
using PersonMatcherAlgorithm.impl;

namespace PersonMatcher
{
    /// <summary>
    /// Expected console input:
    ///     PersonMatcher ALGORITHM_INT INPUTFILE.EXTENSION [OUTPUTFILE.EXTENSION]
    /// </summary>
    class Program
	{
		private const uint EXPECTED_ARGS_COUNT = 2;
		private const uint EXPECTED_ARGS_COUNT_WITH_FILENAME = 3;
		private static readonly IOManager[] IOManagerList = new IOManager[]
        {
            new JsonIO() { ExtensionName = "JSON", ExtensionDescription  = "JavaScript Object Notation"},
            new XmlIO() { ExtensionName = "XML", ExtensionDescription = "Extensible Markup Language"}
        };
        private static MatchingAlgorithm[] MatchingAlgorithmList = new MatchingAlgorithm[]
        {
            new NameAndBirthdayAlgorithm(),
            new NameAndMotherAlgorithm(),
            new NameAndSSNAlgorithm()
        };

        public static void Main(string[] args)
        {
			ValidateInput(args);
            
            PersonCollection personCollection = GetPersonCollectionFromArguments(args);
			
            personCollection.Read();
            personCollection.FindMatches();
            personCollection.Write();
        }

		/// <summary>
		/// Validates the input.
		/// Throws ArgumentException if input has bad format or incorrect argument count
		/// </summary>
		private static bool ValidateInput(string[] args)
		{
            if (args.Length != EXPECTED_ARGS_COUNT && args.Length != EXPECTED_ARGS_COUNT_WITH_FILENAME)
            {
                throw new ArgumentException(string.Format(ErrorMessage.ARGUMENT_COUNT_FORMAT, args.Length) +
                                            '\n' + ErrorMessage.USAGE_MESSAGE);
            }
            if (string.IsNullOrEmpty(args[0]) && !int.TryParse(args[0], out int number))
            {
                throw new FormatException(string.Format(ErrorMessage.BAD_ALGORITHM_FORMAT, args[0]) +
                                          '\n' + ErrorMessage.USAGE_MESSAGE);
            }
            if (string.IsNullOrEmpty(args[1]) && (args[1].Split('.').Length - 1) != 1)
            {
				throw new FormatException(string.Format(ErrorMessage.BAD_INPUTFILE_FORMAT, args[1]) +
										  '\n' + ErrorMessage.USAGE_MESSAGE);
            }

            return true;
		}

        private static PersonCollection GetPersonCollectionFromArguments(string[] args)
        {
			if (args.Length == EXPECTED_ARGS_COUNT)
			{
				return new PersonCollection(GetMatchingAlgorithmFromArgument(args[0]),
                                            GetFileFormatFromArgument(args[1]),
                                            args[1],
                                            null);
			}
			else if (args.Length == EXPECTED_ARGS_COUNT_WITH_FILENAME)
			{
				return new PersonCollection(GetMatchingAlgorithmFromArgument(args[0]),
                                            GetFileFormatFromArgument(args[1]),
                                            args[1],
                                            args[2]);
			}
            throw new ArgumentException(ErrorMessage.USAGE_MESSAGE);
        }

        private static MatchingAlgorithm GetMatchingAlgorithmFromArgument(string algorithm)
        {
            int algorithmChoice = Convert.ToInt32(algorithm);
            if (algorithmChoice < 0 || algorithmChoice > MatchingAlgorithmList.Length + 1)
            {
                throw new FormatException(
                    string.Format(ErrorMessage.BAD_ALGORITHM_SELECTION_FORMAT, MatchingAlgorithmList.Length, algorithmChoice) +
                    '\n' + ErrorMessage.USAGE_MESSAGE);
            }

            return MatchingAlgorithmList[algorithmChoice - 1];
        }

        private static IOManager GetFileFormatFromArgument(string inputfile)
		{
			IOManager result = null;

            string inputfileExtension = inputfile.Split('.')[1];
			foreach (IOManager io in IOManagerList)
			{
                if (inputfileExtension.ToLower().Equals(io.ExtensionName.ToLower()))
				{
					result = io;
					break;
				}
			}

            if (result == null)
            {
                throw new FormatException(string.Format(ErrorMessage.BAD_INPUTFILE_FORMAT, inputfile) +
										  '\n' + ErrorMessage.USAGE_MESSAGE);
            }
			return result;
		}
    }
}
