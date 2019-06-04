using BenchmarkDotNet.Attributes;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlBenchmark
{
    public class XmlRepair
    {
        private string _fileContent;

        [GlobalSetup]
        public void Setup()
        {
            string _path = "../../../../test.xml";
            _fileContent = File.ReadAllText(_path);
        }

        [Benchmark]
        public string BenchmarkInvalidCharsLinq()
        {
            return RemoveInvalidCarsLinq(_fileContent);
        }

        [Benchmark]
        public string BenchmarkInvalidCharsForEach()
        {
            return RemoveInvalidCharsForEach(_fileContent);
        }

        [Benchmark]
        public string BenchmarkInvalidCharsFor()
        {
            return RemoveInvalidCharsFor(_fileContent);
        }

        [Benchmark]
        public string BenchmarkInvalidCharsDoubleLoop()
        {
            return RemoveInvalidCharsDoubleLoop(_fileContent);
        }


        public static string RemoveInvalidCarsLinq(string file)
        {
            return new string(file.Where(x => XmlConvert.IsXmlChar(x)).ToArray());
        }

        public static string RemoveInvalidCharsForEach(string file)
        {
            var stringBuilder = new StringBuilder();
            foreach (var c in file)
            {
                if (XmlConvert.IsXmlChar(c))
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public static string RemoveInvalidCharsFor(string file)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < file.Length; i++)
            {
                if (XmlConvert.IsXmlChar(file[i]))
                {
                    stringBuilder.Append(file[i]);
                }
            }

            return stringBuilder.ToString();
        }

        public static string RemoveInvalidCharsDoubleLoop(string file)
        {
            for (var i = 0; i < file.Length; i++)
            {
                var count = 0;
                var startIndex = i;
                while (!XmlConvert.IsXmlChar(file[i]))
                {
                    i++;
                    count++;
                }
                if (count > 0)
                {
                    file = file.Remove(startIndex, count);
                    i = startIndex + 1;
                }
            }

            return file;
        }
    }
}
