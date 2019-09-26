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

            return numbers.Sum();
        }

    }
}
