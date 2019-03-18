using System;
using System.Linq;

namespace Converter
{
    /// <summary>
    /// Converts string to acronym
    /// </summary>
    public class AcronymConverter
    {
        /// <summary>
        /// Converts string to acronym
        /// </summary>
        /// <param name="phrase">String to be converted.</param>
        /// <returns>acronym</returns>
        public string ConvertToAcronym(string phrase)
        {
            if(phrase == null)
            {
                throw new ArgumentNullException();
            }

            var splitString = phrase.Split(new char[] { ' ', '-' });

            var acronym = new string(splitString.Where(s => !string.IsNullOrEmpty(s)).Select(s => s[0]).ToArray()).ToUpper();

            return acronym;
        }
    }
}