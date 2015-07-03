using Contracts;
using System;
using System.ComponentModel.Composition;

namespace ExtendedOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    [ExportMetadata("OperationName", "Multiplication")]
    public class Multiply : IOperation
    {
        public int Operate(int left, int right)
        {
            long product = Math.BigMul(left, right);
            long intMaxValue = int.MaxValue;
            if (intMaxValue < product)
            {
                throw new OverflowException("Resulting product too large.");
            }
            return (int) product;
        }
    }
}