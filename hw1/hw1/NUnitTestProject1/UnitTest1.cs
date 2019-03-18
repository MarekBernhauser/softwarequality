using Converter;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        private AcronymConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new AcronymConverter();
        }

        [Test]
        public void CorrectInputToConvert()
        {
            var phrase = "Don't repeat yourself";

            Assert.AreEqual(_converter.ConvertToAcronym(phrase), "DRY");
        }

        [Test]
        public void NullStringThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _converter.ConvertToAcronym(null));
        }

        [Test]
        public void EmptyStringReturnsEmpty()
        {
            var phrase = "";

            Assert.AreEqual(_converter.ConvertToAcronym(phrase), "");
        }
    }
}
