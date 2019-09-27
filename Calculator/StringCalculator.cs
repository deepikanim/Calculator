using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {
        public long Add(string input)
        {
            char[] delimiters = { ',', '\n' };

            input = Regex.Unescape(input);

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

    }
}
