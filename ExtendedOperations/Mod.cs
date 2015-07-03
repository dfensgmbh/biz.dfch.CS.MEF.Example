using Contracts;
using System.ComponentModel.Composition;

namespace ExtendedOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '%')]
    [ExportMetadata("OperationName", "Modulo")]
    public class Mod : IOperation
    {
        public int Operate(int left, int right)
        {
            return left % right;
        }
    }
}