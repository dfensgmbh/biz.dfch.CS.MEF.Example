/**
 * Metadata of the IOperation object.
 * In this context the operation data is the symbol, which describes the operation (+, -, *,..)
 **/
using System.ComponentModel.Composition;

namespace SimpleCalculator
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '-')]
    class Subtract : IOperation
    {
        public int Operate(int left, int right)
        {
            return left - right;
        }
    }
}