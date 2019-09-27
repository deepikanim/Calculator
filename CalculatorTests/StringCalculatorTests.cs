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
        [DataRow("//&\n5,5&7", 17)] //basic positive case for custom delimiter (special character)
        [DataRow("//6\n6,6\n6,6,6\n6,7", 7)] //number as custom delimiter
        [DataRow("///\n5,5/5/5", 20)] // "/" as custom delimter
        [DataRow("//D\n5D5D5d5", 10)] //alphabet as delimiter and check case
        [DataRow("//-\n--3-3\n3,3", 12)] //negative sign as delimiter (should not throw exception for negative number)
        [DataRow("//[\n5[8", 13)] // "[" should be supported as single character delimiter
        [DataRow("//[%]\n5,6%7\n", 18)] // old delimiter still supported and single character delimiter can be give in new format
        [DataRow("//[!!!]\n5,7,\n!!!8,!!5,!!!7!4", 20)] //delimiter with multiple special characters
        [DataRow("//[1000]\n5100061000,7\n8", 26)] //higest supported number as delimter
        [DataRow("//[0]\n500500", 10)] //zero delimiter 
        [DataRow("//[00]\n500050050", 60)] // double zero delimiter identified
        [DataRow("//[0@g]\n6,5\n450@g", 56)] // mixture of delimiter with number, spl char, alphabet
        [DataRow("//[,]\n5,5\n,5", 15)] //existing delimiter 
        [DataRow("//[\n]\n5,5\n,5", 15)] //existing delimiter 
        [DataRow("//[1][2][3][4][5][6][7][8][9]\n5,5\n,500,3,0\n0,4", 0)] //every number is a delimiter except 0, result should always be 0
        [DataRow("//[!!][&&][QaQ][1000]\n2!!3&&4QaQ51000,5QAQ,5!,6&",14)] // mutiple types of delimiters
        [DataRow("//[,][\n]\n2,2\n2j\n2",6)]  //existing delimiter as custom delimiter
        [DataRow("//[\r]\n6\r6",12)]//cr character test
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
        [DataRow("//g\n-3,3\n-7g2323g-3,2", "Negative numbers not allowed: -3,-7,-3")] //negative number exception thrown with single custom delimiter

        public void Add_NegativeNumbers(string input, string expectedmessage)
        {

            var ex = Assert.ThrowsException<ArgumentException>(() => calculator.Add(input));

            Assert.AreEqual(expectedmessage, ex.Message);

        }
    }
}
