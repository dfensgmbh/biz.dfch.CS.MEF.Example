using Contracts;
using System.ComponentModel.Composition;

namespace SimpleCalculator
{
    /**
     * Metadata of the IOperation object.
     * In this context the operation data is the symbol, which describes the operation (+, -, *,..)
     **/
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '+')]
    [ExportMetadata("OperationName", "Addition")]
    class Add : IOperation
    {
        public int Operate(int left, int right)
        {
            return left + right;
        }
    }
}