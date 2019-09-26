using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator
    {      

        public int Add(string input)
        {
            int sum = 0;
            int count = 0;

            var numbers = input.Split(',');

            foreach(var num in numbers)
            {
                count++;

                if(count > 2)
                {
                    break;
                }

                if(int.TryParse(num, out int result))
                {
                    sum += result;
                }
            }

            return sum;
        }
    }
}
