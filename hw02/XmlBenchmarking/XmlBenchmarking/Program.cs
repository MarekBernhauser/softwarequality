using BenchmarkDotNet.Running;
using XmlBenchmark;

namespace XmlBenchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<XmlRepair>();
        }
    }
}
