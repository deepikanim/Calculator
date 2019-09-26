using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();

            do
            {
                Console.WriteLine("\nEnter 1 or 2 numbers (separated by comma(,)).");

                var input = Console.ReadLine();

                var sum = calculator.Add(input);

                Console.WriteLine($"Sum is : {sum}");
            }
            while (true);

                         
        }
    }
}
