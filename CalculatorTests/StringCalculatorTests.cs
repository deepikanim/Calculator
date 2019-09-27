using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator calculator;

        [TestInitialize]    
        public void SetupStringCalculatorObj()
        {
            calculator = new StringCalculator();
        }

        [DataTestMethod]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12", 78)] //basic positive test case
        [DataRow("@,@,(*,*,)(*,)(*0,*&,KJHK,kjhkjh,jhkj", 0)] //all inputs are invalid
        [DataRow("23asdf,sdf12,*&,^*&,asdf,#!#!<,$@#@,FSDS,()*)(,2147483647", 0)] //last input is valid 
        [DataRow("1000,dsfs,adf,adsfas2f,adf2fsda,adfc,&^*", 1000)] // all values invalid expect first
        [DataRow(" , , , , , , , , ,", 0)] // space for all inputs
        [DataRow("18446744073709551615,18446744073709551615,18446744073709551615,18446744073709551615", 0)] //input higher than lmax long value       
        [DataRow("(*(<,*(*)(,900,)(*)(", 900)] //single valid input
        [DataRow("1,2\n3,4,5\n6\n7,8\n9,10\n11,12", 78)] //mix of commas and new line char
        [DataRow("12312\ndsfs\nadf\nadsfas2f\nadf2fsda\nadfc\n&^*", 0)] // all new line char delimiters
        [DataRow(",\n,\n,\n,5\n,\n", 5)] //both delimiters together
        [DataRow("\n\n\n1\n\n", 1)] //Single valid number between new line delimiters
        [DataRow("\n1001\n1001\n1001\n1001\n", 0)] //all numbers boundary value
        [DataRow("\n1001\n1000\n1000\n1001\n", 2000)] //first and last number boundary value 1001

        public void Add_Tests(string input, int expected)
        {
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("-4,-4,-5,-3", "Negative numbers not allowed: -4,-4,-5,-3")] //all numbers negitive
        [DataRow("23,-4,4,2,-9\n7\n-9,100", "Negative numbers not allowed: -4,-9,-9")] //all numbers negitive
        [DataRow("0,-0,4,2,-9\n7\n-9,100", "Negative numbers not allowed: -9,-9")] //zero should not show up in negative number
        [DataRow("-,-,-,2,9\n7\n9,-100", "Negative numbers not allowed: -100")] //single negative number last number
        [DataRow("-100,-,-,-,2,9\n7\n9,", "Negative numbers not allowed: -100")] //single negative number first number

        public void Add_NegativeNumbers(string input, string expectedmessage)
        {

            var ex = Assert.ThrowsException<ArgumentException>(() => calculator.Add(input));

            Assert.AreEqual(expectedmessage, ex.Message);

        }
    }
}
