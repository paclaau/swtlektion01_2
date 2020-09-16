using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Calculator.Unit.Test
{
    [TestFixture]
    public class CalculatorUnitTests
    {
        private Calculator uut;

        [SetUp]
        public void Setup()
        {
            uut = new Calculator();
        }

        #region Add Method
        [Test]
        public void Add_TwoPositiveNumbers_ReturnPositiveNumber()
        {
            var result = uut.Add(2, 5);
            Assert.That(result,Is.EqualTo(7));
        }

        [Test]
        public void Add_PositiveAndLowerNegativeNumber_ReturnPositiveNumber()
        {
            var result = uut.Add(5, -2);
            Assert.That(result,Is.EqualTo(3));
        }

        [Test]
        public void Add_PositiveAndHigherNegativeNumber_ReturnNegativeNumber()
        {
            var result = uut.Add(5, -7);
            Assert.That(result,Is.EqualTo(-2));
        }

        [Test]
        public void Add_TwoNegativeNumbers_ReturnNegativeNumber()
        {
            var result = uut.Add(-5, -7);
            Assert.That(result,Is.EqualTo(-12));
        }
        #endregion

        #region Subtract Method
        [TestCase(12, 5, 7)]
        [TestCase(-5, 7, -12)]
        [TestCase(-12, -7, -5)]
        public void Subtract_PositiveAndNegativeNumbers_ReturnIsCorrect(int a, int b, int c)
        {
            var result = uut.Subtract(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        [TestCase(12, 5, 7)]
        [TestCase(-5, 7, -12)]
        [TestCase(-12, -7, -5)]
        public void Subtract_PositiveAndNegativeNumbers_AccumulatorIsCorrect(int a, int b, int c)
        {
            uut.Subtract(a, b);
            Assert.That(uut.Accumulator, Is.EqualTo(c));
        }
        #endregion

        #region Divide Method
        [Test]
        public void DivideTwoPositiveIntegers_ReturnPositiveNumber()
        {
            var result = uut.Divide(10, 5);
            Assert.That(result,Is.EqualTo(2));
        }
        [Test]
        public void DivideTwoPositiveDoubles_ReturnPositiveNumber()
        {
            var result = uut.Divide(10.5, 2.4);
            Assert.That(result, Is.EqualTo(4.375));
        }
        [Test]
        public void DividePositiveNumberWithNegativeNumber_ReturnNegativeNumber()
        {
            var result = uut.Divide(10, -1);
            Assert.That(result, Is.EqualTo(-10));
        }
        [Test]
        public void DivideNegativeNumberWithPositiveNumber_ReturnNegativeNumber()
        {
            var result = uut.Divide(-10, 1);
            Assert.That(result, Is.EqualTo(-10));
        }
        [Test]
        public void DivideTwoNegativeIntegers_ReturnPositiveNumber()
        {
            var result = uut.Divide(-10, -5);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Divide_DivideByZero_ThrowDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(delegate { uut.Divide(10, 0); });
        }
        #endregion

        #region Multiply Method
        [TestCase(5,10,50)]
        [TestCase(2,8,16)]
        [TestCase(0,1,0)]
        [TestCase(0,0,0)]
        [TestCase(1,-6,-6)]
        [TestCase(-5,-7,35)]
        public void Multiply_PositiveAndNegativeNumbers_ResultIsCorrect(int a, int b, int c)
        {
            var result = uut.Multiply(a, b);
            Assert.That(result, Is.EqualTo(c));
        }

        [TestCase(5, 10, 50)]
        [TestCase(2, 8, 16)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(1, -6, -6)]
        [TestCase(-5, -7, 35)]
        public void Multiply_PositiveAndNegativeNumbers_AccumulatorIsCorrect(int a, int b, int c)
        {
            uut.Multiply(a, b);
            Assert.That(uut.Accumulator, Is.EqualTo(c));
        }
        #endregion

        #region Power Method

        [TestCase(2,4,16)]
        [TestCase(16,2,256)]
        [TestCase(0.5,-1,2)]
        [TestCase(200,0,1)]
        public void Power_TestWithPositiveNegativeAndZeroExponents_ResultIsCorrect(double x, double exp, double expectedResult)
        {
            var result = uut.Power(x, exp);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion

        #region Overloaded Add Method
        [Test]
        public void OverloadedAddDoubleAndAccumulator_ReturnsCorrectNumber(double a)
        {
            uut.Add(5, 5);
            var result = uut.Add(4);
            Assert.That(result, Is.EqualTo(14));
        }
        #endregion

        #region Overloaded Subtract Method

        #endregion

        #region Overloaded Divide Method

        #endregion

        #region Overloaded Multiply

        #endregion

        #region Overloaded Power Method

        #endregion

        #region Accumulator
        [Test]
        public void Add_TwoPositiveNumbers_AccumulatorIsCorrect()
        {
            uut.Add(2, 5);
            Assert.That(uut.Accumulator, Is.EqualTo(7));
        }

        [Test]
        public void Add_TwoNegativeNumbers_AccumulatorIsCorrect()
        {
            uut.Add(-2, -7);
            Assert.That(uut.Accumulator, Is.EqualTo(-9));
        }
        #endregion

        #region Clear

        #endregion 
    }
}