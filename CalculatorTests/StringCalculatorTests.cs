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
        public void Add_Tests(string input, int expected)
        {
            var actual = calculator.Add(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
