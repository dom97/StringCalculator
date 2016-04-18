using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorTests
    {
        StringCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new StringCalculator();
        }

        [TestMethod]
        public void VerifyThatIntegerIsReturned()
        {
            var result = calculator.Add("0");

            Assert.IsInstanceOfType(result, typeof(Int32));
        }

        [TestMethod]
        public void PassingEmptyStringReturnsZero()
        {
            var result = calculator.Add(String.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void PassingASingleIntegerReturnsThatInteger()
        {
            var result = calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void PassingTwoIntegersWhichAreCommaDelimetedReturnsTheSumOfThoseIntegers()
        {
            var result = calculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void PassingMultipleIntegersReturnsTheSumOfThoseIntegers()
        {
            var result = calculator.Add("1,2,1,2");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void PassingIntegersDelimetedByNewLinesReturnsTheSumOfThoseIntegers()
        {
            var numbers = String.Format("1{0}2", Environment.NewLine);
            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void UsingAlternateDelimeterReturnsSumOfIntegers()
        {
            var numbers = String.Format("//;{0}1;2", Environment.NewLine);
            var result = calculator.Add(numbers);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void PassingASingleNegateiveNumberWithoutADelimeterThrowsAnExceptionListingThatNumber()
        {
            var numbers = String.Format("-1", Environment.NewLine);

            try
            {
                calculator.Add(numbers);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Negatives not allowed: -1");
            }
        }

        [TestMethod]
        public void PassingAPositiveIntegerFollowedByANegateiveIntegerThrowsAnExceptionListingThatNumber()
        {
            var numbers = String.Format("//;{0}1;-2", Environment.NewLine);

            try
            {
                calculator.Add(numbers);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Negatives not allowed: -2");
            }
        }

        [TestMethod]
        public void PassingANegativeIntegerFollowedByAPositiveIntegerThrowsAnExceptionListingThatNumber()
        {
            var numbers = String.Format("//;{0}-1;2", Environment.NewLine);

            try
            {
                calculator.Add(numbers);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Negatives not allowed: -1");
            }
        }

        [TestMethod]
        public void PassingMultipleNegativeIntegersThrowsAnExceptionListingTheNumbers()
        {
            var numbers = String.Format("//;{0}-1;-2", Environment.NewLine);

            try
            {
                calculator.Add(numbers);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Negatives not allowed: -1, -2");
            }
        }

        [TestMethod]
        public void PassingASingleIntegerLargerThanOneThousandIsIgnored()
        {
            var numbers = "1001";
            var result = calculator.Add(numbers);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AMultipleIntegersWithOneBeingLargerThanOneThousandReturnsAResultExcludingThatInteger()
        {
            var numbers = "1001,2,3";
            var result = calculator.Add(numbers);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void PassingADelimeterOfMultipleCharactersReturnsProperSum()
        {
            var numbers = String.Format("//[***]{0}1***2***3", Environment.NewLine);
            var result = calculator.Add(numbers);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void PassingMultipleDelimetersReturnsProperSum()
        {
            var numbers = String.Format("//[*][%]{0}1*2%3", Environment.NewLine);
            var result = calculator.Add(numbers);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void PassingMultipleDelimetersWhichAreLongerThanOneCharactersReturnsProperSum()
        {
            var numbers = String.Format("//[**][%%]{0}1**2%%3", Environment.NewLine);
            var result = calculator.Add(numbers);

            Assert.AreEqual(6, result);
        }
    }
}
