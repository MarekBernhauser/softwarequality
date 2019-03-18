using Converter;
using System;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            AcronymConverter converter = new AcronymConverter();

            string str1 = "Don't repeat yourself";
            string str2 = "Asynchronous Javascript and XML";
            string str3 = "Complementary metal - oxide semiconductor";

            Console.WriteLine(converter.ConvertToAcronym(str1));
            Console.WriteLine(converter.ConvertToAcronym(str2));
            Console.WriteLine(converter.ConvertToAcronym(str3));
        }
    }
}
