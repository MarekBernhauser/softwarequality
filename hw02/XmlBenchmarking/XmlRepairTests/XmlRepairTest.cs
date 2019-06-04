using NUnit.Framework;
using System.IO;
using System.Xml;
using XmlBenchmark;

namespace Tests
{
    public class Tests
    {
        private string _file;
        private string _path;

        [SetUp]
        public void Setup()
        {
            _path = "../../../../test.xml";
            _file = File.ReadAllText(_path);
        }

        [Test]
        public void ValidXmlAfterLinq()
        {
            var document = new XmlDocument();
            var repairedFile = XmlRepair.RemoveInvalidCarsLinq(_file);
            Assert.DoesNotThrow(() => document.LoadXml(repairedFile));
        }

        [Test]
        public void ValidXmlAfterForEach()
        {
            var document = new XmlDocument();
            var repairedFile = XmlRepair.RemoveInvalidCharsForEach(_file);
            Assert.DoesNotThrow(() => document.LoadXml(repairedFile));
        }

        [Test]
        public void ValidXmlAfterFor()
        {
            var document = new XmlDocument();
            var repairedFile = XmlRepair.RemoveInvalidCharsFor(_file);
            Assert.DoesNotThrow(() => document.LoadXml(repairedFile));
        }
        [Test]
        public void ValidXmlAfterDoubleLoop()
        {
            var document = new XmlDocument();
            var repairedFile = XmlRepair.RemoveInvalidCharsDoubleLoop(_file);
            Assert.DoesNotThrow(() => document.LoadXml(repairedFile));
        }
    }
}