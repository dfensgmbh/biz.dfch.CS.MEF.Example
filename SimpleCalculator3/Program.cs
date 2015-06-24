using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SimpleCalculator
{

    public interface ICalculator
    {
        String Calculate(String input);
    }

    /**
     * Operation interface definition
     **/
    public interface IOperation
    {
        int Operate(int left, int right);
    }

    /**
     * Metadata of the IOperation object.
     * In this context the operation data is the symbol, which describes the operation (+, -, *,..)
     **/
    public interface IOperationData
    {
        Char Symbol { get; }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '+')]
    class Add : IOperation
    {
        public int Operate(int left, int right)
        {
            return left + right;
        }
    }

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '-')]
    class Subtract : IOperation
    {
        public int Operate(int left, int right)
        {
            return left - right;
        }
    }


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
            if (fn < 0) return "Could not parse command.";

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
                if (i.Metadata.Symbol.Equals(operation)) return i.Value.Operate(left, right).ToString();
            }
            return "Operation Not Found!";
        }

        private int FindFirstNonDigit(String s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                if (!(Char.IsDigit(s[i]))) return i;
            }
            return -1;
        }
    }


    class Program
    {
        private CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;

        private Program()
        {
            // An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            // Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            // Adds all the parts found in the given directory
            catalog.Catalogs.Add(new DirectoryCatalog("C:\\development\\projects\\GitHub\\biz.dfch.CS.MEF.Example\\SimpleCalculator3\\Extensions"));


            // Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            try
            {
                // Fill the imports of this object
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        // Exposes the calculators calculate function
        public String Calculate(String s) {
            return this.calculator.Calculate(s);
        }


        static void Main(string[] args)
        {
            Program p = new Program();
            String s;
            Console.WriteLine("This is a simple calculator, which supports some of the basic operations");
            Console.WriteLine("========================================================================");
            Console.WriteLine("Enter a mathematical expression (i.e. 1+2):");
            while (true)
            {
                s = Console.ReadLine();
                Console.WriteLine(p.Calculate(s));
            }
        }
    }
}
