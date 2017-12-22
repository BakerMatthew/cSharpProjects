using PersonMatcher.model;

namespace PersonMatcher.Algorithm
{
    public abstract class MatchingAlgorithm
    {
        public abstract bool FindMatches(PersonCollection list, PersonMatchPairCollection pairs);
    }
}
