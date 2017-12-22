using System;
using NUnit.Framework;
namespace PersonMatcherTest
{
	/** Visual Studio was upset with me so I couldn't make a successful test project for PersonMatcher.
	 * For some reason, my PersonMatcher project isn't compatible or isn't a correct version to create a test project of.
     * But, this is how I would test ValidateInput
     
    [TestFixture]
    public class ValidateInputTest
    {
        [Test]
        public void ValidateJsonInputTest()
        {
            // Given
            string[] input = new string[] { "1", "JSON_PersonTestSet_3.json", "Json_output.txt" };

            // When
            bool result = Person.ValidateInput(input);

            // Then
            Assert.True(result);
        }

        [Test]
        public void ValidateEmptyJsonInputTest()
        {
            // Given
            string[] input = new string[] { "1", "JSON_PersonTestSet_1.json", "Json_output.txt" };

            // When
            bool result = Person.ValidateInput(input);

            // Then
            Assert.True(result);
        }

        [Test]
        public void ValidateXmlInputTest()
        {
            // Given
            string[] input = new string[] { "2", "XML_PersonTestSet_3.json", "Xml_output.txt" };

            // When
            bool result = Person.ValidateInput(input);

            // Then
            Assert.True(result);
        }

        [Test]
        public void ValidateEmptyXmlInputTest()
        {
            // Given
            string[] input = new string[] { "2", "XML_PersonTestSet_1.json", "Xml_output.txt" };

            // When
            bool result = Person.ValidateInput(input);

            // Then
            Assert.True(result);
        }

        [Test]
        public void ValidateConsoleInputTest()
        {
            // Given
            string[] input = new string[] { "3", "JSON_PersonTestSet_3.json" };

            // When
            bool result = Person.ValidateInput(input);

            // Then
            Assert.True(result);
        }

		[Test]
		public void ValidateInputBadLowerBoundTest()
		{
			// Given
			string[] input = new string[] { "0", "JSON_PersonTestSet_3.json" };
			string expectedMessage = string.Format(ErrorMessage.BAD_ALGORITHM_FORMAT, "0") + '\n' + ErrorMessage.USAGE_MESSAGE;

			// When
			FormatException e = Assert.Throws<FormatException>(() => Person.ValidateInput(input));

			// Then
			Assert.That(e.Message == expectedMessage);
		}

		[Test]
		public void ValidateInputBadUpperBoundTest()
		{
			// Given
			string[] input = new string[] { "10", "JSON_PersonTestSet_3.json" };
			string expectedMessage = string.Format(ErrorMessage.BAD_ALGORITHM_FORMAT, "10") + '\n' + ErrorMessage.USAGE_MESSAGE;

			// When
			FormatException e = Assert.Throws<FormatException>(() => Person.ValidateInput(input));

			// Then
			Assert.That(e.Message == expectedMessage);
		}

		[Test]
		public void ValidateInputBadInputfileTest()
		{
			// Given
			string[] input = new string[] { "1", "JSON_PersonTestSet_3.json.xml" };
			string expectedMessage = string.Format(ErrorMessage.BAD_INPUTFILE_FORMAT, args[1]) + '\n' + ErrorMessage.USAGE_MESSAGE;

			// When
			FormatException e = Assert.Throws<FormatException>(() => Person.ValidateInput(input));

			// Then
			Assert.That(e.Message == expectedMessage);
		}

        [Test]
        public void ValidateInputBadExtensionTest()
        {
            // Given
            string[] input = new string[] { "1", "JSON_PersonTestSet_3.json.xml" };
            string expectedMessage = string.Format(ErrorMessage.BAD_INPUTFILE_FORMAT, inputfile) + '\n' + ErrorMessage.USAGE_MESSAGE;

            // When
            FormatException e = Assert.Throws<FormatException>(() => Person.ValidateInput(input));

            // Then
            Assert.That(e.Message == expectedMessage);
        }


        [Test]
        public void ValidateInputBadArgumentCountTest()
        {
            // Given
            string[] input = new string[] { "1", "JSON_PersonTestSet_3.json.xml" };
            string expectedMessage = string.Format(ErrorMessage.ARGUMENT_COUNT_FORMAT, args.Length) + '\n' + ErrorMessage.USAGE_MESSAGE;

            // When
            ArgumentException e = Assert.Throws<ArgumentException>(() => Person.ValidateInput(input));

            // Then
            Assert.That(e.Message == expectedMessage);
        }
    }
    */
}
