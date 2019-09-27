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

            while(true)
            {
                Console.WriteLine("\nEnter numbers:");

                var input = Console.ReadLine();

                try
                {
                    var sum = calculator.Add(input);

                    Console.WriteLine($"Sum is : {sum}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
                         
        }
    }
}
