using System;
using PersonMatcher.model;

namespace PersonMatcher.IO
{
	public abstract class IOManager
	{
		/// <summary>
		/// Gets or sets the ExtensionName.
		/// Used to identify what extension will be used for IO.
		/// </summary>
		public string ExtensionName { get; set; }

		/// <summary>
		/// Gets or sets the ExtenstionDescription.
		/// Gives more information for the used extension.
		/// </summary>
		public string ExtensionDescription { get; set; }

		/// <summary>
		/// Read values from filename into list using the given extension.
		/// </summary>
		/// <returns>true on success</returns>
		/// <param name="list">List of Person objects.</param>
		/// <param name="filename">Filename to read from.</param>
		public abstract bool Read(PersonCollection list, string filename);

		/// <summary>
		/// Write the values in list to filename with the given extension.
		/// </summary>
		/// <returns>true on success</returns>
		/// <param name="list">List of Person matched objects.</param>
		/// <param name="filename">Filename to write to.</param>
        public abstract bool Write(PersonMatchPairCollection list, string filename);

        public virtual bool WriteToConsole(PersonMatchPairCollection list)
		{
            if (list.Count == 0)
            {
                return false;
            }

            string printFormat = "\tId={0}, Name={1} {2} {3}, BirthDate={4}/{5}/{6}";
            foreach (Tuple<Person, Person> match in list)
            {
                Console.WriteLine("Match:\n");
				Console.WriteLine(
                    string.Format(printFormat,
								  match.Item1.ObjectId,
								  match.Item1.FirstName, match.Item1.MiddleName, match.Item1.LastName,
								  match.Item1.BirthMonth, match.Item1.BirthDay, match.Item1.BirthYear));
                Console.WriteLine(
                    string.Format(printFormat,
                                   match.Item2.ObjectId,
								   match.Item2.FirstName, match.Item2.MiddleName, match.Item2.LastName,
								   match.Item2.BirthMonth, match.Item2.BirthDay, match.Item2.BirthYear));
            }
			return true;
		}
	}
}
