using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtendedOperations.Tests
{
    [TestClass]
    public class DivideTests
    {
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivideThrowsDivideByZeroException()
        {
            var operation = new Divide();
            var result = operation.Operate(1, 0);
            Assert.IsNull(result);
        }
        [TestMethod]
        public void TestDivideExpects0()
        {
            var operation = new Divide();
            var result = operation.Operate(1, 8);
            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void TestDivideExpects2()
        {
            var operation = new Divide();
            var result = operation.Operate(16, 8);
            Assert.AreEqual(result, 2);
        }
    }
}
