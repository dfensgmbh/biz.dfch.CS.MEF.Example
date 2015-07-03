using System.ComponentModel.Composition;
using Contracts;

namespace ExtendedOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '/')]
    [ExportMetadata("OperationName", "Division")]
    public class Divide : IOperation
    {
        public int Operate(int left, int right)
        {
            return left / right;
        }
    }
}
