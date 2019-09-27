using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();

            while(true)
            {
                Console.WriteLine("\nEnter numbers:");

                var input = Console.ReadLine();
                input = Regex.Unescape(input);                

                try
                {
                    var sum = calculator.Add(input);

                    Console.WriteLine($"Sum is : {sum}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
                
            }
                         
        }
    }
}
