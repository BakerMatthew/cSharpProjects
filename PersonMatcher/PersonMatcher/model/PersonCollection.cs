using System;
using System.Collections.Generic;
using PersonMatcher.Algorithm;
using PersonMatcher.IO;

namespace PersonMatcher.model
{
    public class PersonCollection : List<Person>
	{
		public MatchingAlgorithm PersonMatchingAlgorithm { set; get; }
		public IOManager PersonIOManager { set; get; }
        public string InputFilename { set; get; }
		public string OutputFilename { set; get; }

        public PersonMatchPairCollection PersonMatchPairs { set; get; }

        public PersonCollection(MatchingAlgorithm personMatchingAlogrithm, IOManager personIOManager, string inputFilename, string outputFilename)
		{
			this.PersonMatchingAlgorithm = personMatchingAlogrithm;
			this.PersonIOManager = personIOManager;
            this.InputFilename = inputFilename;
			this.OutputFilename = outputFilename;
            this.PersonMatchPairs = new PersonMatchPairCollection();
        }

        public void Read()
        {
            if (PersonIOManager == null)
            {
                throw new InvalidOperationException(ErrorMessage.NULL_IO_MANAGER);
            }
            PersonIOManager.Read(this, InputFilename);
        }

        public void Write()
        {
			if (PersonIOManager == null)
			{
				throw new InvalidOperationException(ErrorMessage.NULL_IO_MANAGER);
			}

            if (string.IsNullOrWhiteSpace(OutputFilename))
            {
                PersonIOManager.WriteToConsole(PersonMatchPairs);
            } else {
                PersonIOManager.Write(PersonMatchPairs, OutputFilename);
            }
        }

        public void FindMatches()
        {
            PersonMatchingAlgorithm.FindMatches(this, PersonMatchPairs);
        }
    }
}
