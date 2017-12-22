using System;
using PersonMatcher.Algorithm;
using PersonMatcher.model;

namespace PersonMatcherAlgorithm.impl
{
    public class NameAndMotherAlgorithm : MatchingAlgorithm
    {
        public override bool FindMatches(PersonCollection list, PersonMatchPairCollection pairs)
		{
            for (int firstIndex = 0; firstIndex < list.Count - 1; firstIndex += 1)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < list.Count; secondIndex += 1)
                {
                    if (list[firstIndex].FirstName == list[secondIndex].FirstName &&
                        list[firstIndex].LastName == list[secondIndex].LastName &&
                        list[firstIndex].MotherFirstName == list[secondIndex].MotherFirstName &&
                        list[firstIndex].MotherLastName == list[secondIndex].MotherLastName)
                    {
                        pairs.Add(Tuple.Create(list[firstIndex], list[secondIndex]));
                    }
                }
            }

			return pairs.Count > 0 ? true : false;
		}
    }
}
