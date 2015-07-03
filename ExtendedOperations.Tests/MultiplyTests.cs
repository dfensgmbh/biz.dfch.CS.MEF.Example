using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtendedOperations.Tests
{
    [TestClass]
    public class MultiplyTests
    {
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void TestMultiplyThrowsOverflowException()
        {
            var operation = new Multiply();
            var result1 = operation.Operate(int.MaxValue, int.MaxValue);
            long resultExpected1 = 4611686014132420609;
            Assert.Equals(resultExpected1, result1);

            var result2 = operation.Operate(int.MaxValue, 3);
            long resultExpected2 = 6442450941;
            Assert.Equals(resultExpected2, result2);
        }
        [TestMethod]
        public void TestMultiplyExpectsMinus210()
        {
            var operation = new Multiply();
            var result = operation.Operate(5, -42);
            Assert.AreEqual(result, -210);
        }
        [TestMethod]
        public void TestMultiplyExpects32()
        {
            var operation = new Multiply();
            var result = operation.Operate(-4, -8);
            Assert.AreEqual(result, 32);
        }
        [TestMethod]
        public void TestMultiplyExpects0()
        {
            var operation = new Multiply();
            var result = operation.Operate(0, 91);
            Assert.AreEqual(result, 0);
        }
    }
}
