using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PersonMatcher.model;

namespace PersonMatcher.IO.impl
{
    public class XmlIO : IOManager
    {
		private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<Person>));

        public override bool Read(PersonCollection list, string filename)
        {
			StreamReader reader = new StreamReader(filename);
			List<Person> fileData = XmlSerializer.Deserialize(reader.BaseStream) as List<Person>;
			if (fileData != null)
			{
				foreach (Person person in fileData)
					list.Add(person);
            } else {
                return false;
            }
            return true;
        }

        public override bool Write(PersonMatchPairCollection list, string filename)
        {
			StreamWriter writer = new StreamWriter(filename);
			for (int index = 0; index < list.Count; index += 1)
			{
                writer.WriteLine(list[index].Item1.ObjectId.ToString() + ',' + list[index].Item2.ObjectId.ToString());
			}
			writer.Close();
			return true;
        }
    }
}
