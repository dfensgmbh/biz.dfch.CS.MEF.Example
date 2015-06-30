using System.ComponentModel.Composition;

namespace ExtendedOperations
{
    [Export(typeof(SimpleCalculator.IOperation))]
    [ExportMetadata("Symbol", '*')]
    public class Multiply : SimpleCalculator.IOperation
    {
        public int Operate(int left, int right)
        {
            return left * right;
        }
    }
}