using System;
using System.Collections.Generic;

namespace PersonMatcher.model
{
    /// <summary>
    /// Wrapper class to store Person matches.
    /// Uses a two-tuple to store matches:
    ///     First element: Person object
    ///         The first Person object of the found match
    ///     Second element: Person object
    ///         The second Person object of the found match
    /// </summary>
    public class PersonMatchPairCollection : List<Tuple<Person, Person>>
	{
		// A wrapper class, currently has nothing to impelement
	}
}
