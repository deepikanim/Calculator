using System;
using System.Linq;

namespace Calculator
{
    public class StringCalculator
    {
        public long Add(string input)
        {
            var delimiters = GetDelimiters(input);

            var numbers = input
                            .Split(delimiters)
                            .Select(s =>
                            {
                                return long.TryParse(s.Trim(), out long i) ? i : 0;
                            }).ToList();

            var negatives = numbers.FindAll(a => a < 0);

            if (negatives.Count > 0)
            {
                throw new ArgumentException($"Negative numbers not allowed: {string.Join(",", negatives)}");
            }

            return numbers.FindAll(a => a <= 1000).Sum();
        }

        private char[] GetDelimiters(string input)
        {
            int startIndex = input.IndexOf("//");
            int endIndex = input.IndexOf('\n');

            string delimiter = null;
            if (startIndex >= 0 && endIndex >= 0)
            {
                delimiter = input.Substring(startIndex + 2, endIndex - startIndex - 2);
            }
            if (!string.IsNullOrWhiteSpace(delimiter))
            {
                return new char[] { ',', '\n', Convert.ToChar(delimiter) };
            }
            else
            {
                return new char[] { ',', '\n' };
            }
        }

    }
}
