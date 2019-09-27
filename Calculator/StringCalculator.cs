using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    /// <summary>
    ///   Models a string calculator
    /// </summary>
    public class StringCalculator
    {

        /// <summary>
        /// This method adds unlimited number of numbers separated by delimiters.
        /// </summary>
        /// <param name="input">contains delimiter separated numbers</param>
        /// <returns>sum of numbers</returns>
        public long Add(string input)
        {
            var delimiters = GetDelimiters(input);

            var numbers = input
                            .Split(delimiters.ToArray(), StringSplitOptions.None)
                            .Select(s =>
                            {
                                return long.TryParse(s.Trim(), out long i) ? i : 0;
                            }).ToList();

            //deny negative numbers
            var negatives = numbers.FindAll(a => a < 0);

            if (negatives.Count > 0)
            {
                throw new ArgumentException($"Negative numbers not allowed: {string.Join(",", negatives)}");
            }

            //ignore any number greater than 1000
            return numbers.FindAll(a => a <= 1000).Sum();
        }


        /// <summary>
        /// This method parses the input string and returns delimiters
        /// </summary>
        /// <param name="input">contains delimiter separated numbers</param>
        /// <returns>a list of string delimeters.</returns>
        private List<string> GetDelimiters(string input)
        {
            string delimiters = null;
            var delimitersList = new List<string>() { ",", "\n" }; //default delimiters

            //get string in between "//" and "\n"
            int startIndex = input.IndexOf("//");
            int endIndex = input.IndexOf("\n");

            if (startIndex >= 0 && endIndex >= 0)
            {
                delimiters = input.Substring(startIndex + 2, endIndex - startIndex - 2); 
            }

            if (!string.IsNullOrWhiteSpace(delimiters))
            {
                //1 custom single character length delimiter
                if (delimiters.Length == 1) 
                {
                    delimitersList.Add(delimiters);
                }
                //1 or more delimiters of any length
                else if (delimiters.Count(a => a.Equals('[')) == delimiters.Count(a => a.Equals(']')))
                {
                    delimiters = delimiters.Replace('[', ' ').Replace(']', ' ');

                    var customDelimiters = delimiters.Split(' ').ToList<string>();
                    delimitersList.AddRange(customDelimiters);
                }
            }

            return delimitersList;
        }

    }
}
