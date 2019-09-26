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
        [DataRow("23asdf,sdf12,*&,^*&,asdf,#!#!<,$@#@,FSDS,()*)(,2147483647", 2147483647)] //last input is valid 
        [DataRow("12312,dsfs,adf,adsfas2f,adf2fsda,adfc,&^*", 12312)] // all values invalid expect first
        [DataRow(" , , , , , , , , ,", 0)] // space for all inputs
        [DataRow("18446744073709551615,18446744073709551615,18446744073709551615,18446744073709551615", 0)] //input higher than lmax long value
        [DataRow("-4,-4,-5,-3", -16)] //negative numbers
        [DataRow("(*(<,*(*)(,900,)(*)(", 900)] //single valid input
        [DataRow("1,2\n3,4,5\n6\n7,8\n9,10\n11,12", 78)] //mix of commas and new line char
        [DataRow("12312\ndsfs\nadf\nadsfas2f\nadf2fsda\nadfc\n&^*", 12312)] // all new line char delimiters
        [DataRow(",\n,\n,\n,5\n,\n", 5)] //both delimiters together
        [DataRow("\n\n\n1\n\n", 1)] //Single valid number between new line delimiters

        public void Add_Tests(string input, int expected)
        {
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
