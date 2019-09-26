using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {      

        public long Add(string input)
        {
            long sum = default;

            var numbers = input.Split(',');

            foreach(var num in numbers)
            {
                if(long.TryParse(num, out long result))
                {
                    sum += result;
                }
            }

            return sum;
        }
    }
}
