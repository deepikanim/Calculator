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
        [DataRow("2,5",7)] //basic positive test case
        [DataRow("@,@",0)] //both numbers invalid inputs
        [DataRow("2312,*&^*&", 2312)] //2nd entry invalid input
        [DataRow("&^*,222", 222)] // first entry invalid input
        [DataRow(" , ", 0)] // space for both inputs
        [DataRow("2,2,2,2", 4)] //more than 2 inputs
        [DataRow("-4,-4", -8)] //negative numbers
        [DataRow("(*(<,*(*)(,900,)(*)(", 0)] //more than 2 invalid entries and number after 2
        public void Add_Tests(string input, int expected)
        {
            var actual = calculator.Add(input);
            Assert.AreEqual(actual, expected);
        }
    }
}
