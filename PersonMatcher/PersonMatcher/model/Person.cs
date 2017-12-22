using System.Runtime.Serialization;

namespace PersonMatcher.model
{
    [DataContract]
    public class Person
    {
		/// <summary>
		/// An unique identifier for the object, not the person
        /// </summary>
		[DataMember]
		public int ObjectId { get; set; }

		/// <summary>
		/// A state file number -- highly unique, but only available to
        /// people born in Utah and some bad values may exit
        /// </summary>
		[DataMember]
		public string StateFileNumber { get; set; }

		/// <summary>
        /// A federal tax identifier – highly unique,
        /// but is only occasionally available and prone to error
        /// </summary>
		[DataMember]
		public string SocialSecurityNumber { get; set; }

		/// <summary>
		/// The person’s first name – newborns may have empty or bad first names
        /// </summary>
		[DataMember]
		public string FirstName { get; set; }

		/// <summary>
		/// The person’s middle name – often null
		/// </summary>
		[DataMember]
		public string MiddleName { get; set; }

		/// <summary>
		/// The person’s last name
		/// </summary>
		/// <value>The last name.</value>
		[DataMember]
		public string LastName { get; set; }

		/// <summary>
		/// The year of the person’s birth date
		/// </summary>
		[DataMember]
		public int BirthYear { get; set; }

		/// <summary>
		/// The month of the person’s birth date
		/// </summary>
		[DataMember]
		public int BirthMonth { get; set; }

		/// <summary>
		/// The day of the person’s birth date
		/// </summary>
		[DataMember]
		public int BirthDay { get; set; }

		/// <summary>
		/// The person’s gender – “F” or “M”, blank, or bad data
        /// </summary>
		[DataMember]
		public string Gender { get; set; }

		/// <summary>
		/// A number assigned to babies born in Utah – highly unique,
        /// but only available for children born in Utah medical facilities
        /// </summary>
		[DataMember]
		public string NewbornScreeningNumber { get; set; }

		/// <summary>
		/// The person was born with a twin, triplet, etc. – “T”, “F”, or blank
        /// </summary>
		[DataMember]
		public string IsPartOfMultipleBirth { get; set; }

		/// <summary>
		/// If the person was part of a multiple birth, then this is person’s
        /// birth order relative to the others. For example,
        /// The first of a set of twins born would have a value of 1 and
        /// the second would have a value of 2
		/// </summary>
		[DataMember]
		public int BirthOrder { get; set; }

		/// <summary>
		/// The county in which the person was born
		/// </summary>
		[DataMember]
		public string BirthCounty { get; set; }

		/// <summary>
		/// The person’s mother’s first name
		/// </summary>
		[DataMember]
		public string MotherFirstName { get; set; }

		/// <summary>
		/// The person’s mother’s middle name
		/// </summary>
		[DataMember]
		public string MotherMiddleName { get; set; }

		/// <summary>
		/// The person’s mother’s last name
		/// </summary>
		[DataMember]
		public string MotherLastName { get; set; }

		/// <summary>
		/// A phone number for the person
		/// </summary>
		[DataMember]
		public string Phone1 { get; set; }

		/// <summary>
		/// A phone number for the person
		/// </summary>
		[DataMember]
		public string Phone2 { get; set; }
    }
}
