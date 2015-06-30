using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace SimpleCalculator
{
    [Export(typeof(ICalculator))]
    class MySimpleCalculator : ICalculator
    {
        /**
         * On ComposeParts MEF initializes the list with all parts found that match the contract
         * (Contract: Parts have to be of type IOperation)
         **/
        [ImportMany]
        IEnumerable<Lazy<IOperation, IOperationData>> operations;

        public String Calculate(String input)
        {
            int left;
            int right;
            Char operation;
            // finds the operator
            int fn = FindFirstNonDigit(input);
            if (fn < 0)
                return "Could not parse command.";

            try
            {
                // separate out the operands
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch
            {
                return "Could not parse command.";
            }

            operation = input[fn];

            foreach (Lazy<IOperation, IOperationData> i in operations)
            {
                if (i.Metadata.Symbol.Equals(operation))
                    return i.Value.Operate(left, right).ToString();
            }
            return "Operation Not Found!";
        }

        private int FindFirstNonDigit(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!(Char.IsDigit(s[i])))
                    return i;
            }
            return -1;
        }
    }
}