using System;
using System.Linq;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace SimpleCalculator
{


    class Program
    {
        private readonly CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;

        private Program()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            
            // An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            // Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            // Adds all the parts found in the given directory
            try
            {
                catalog.Catalogs.Add(new DirectoryCatalog("C:\\development\\projects\\GitHub\\biz.dfch.CS.MEF.Example\\SimpleCalculator3\\Extensions"));
            }
            catch (Exception ex)
            {
                //N/A
            }
            try
            {
                catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(baseDirectory, "Extensions")));
            }
            catch (Exception ex)
            {
                //N/A
            }
            try
            {
                catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(baseDirectory, "..", "..", "Extensions")));
            }
            catch (Exception ex)
            {
                //N/A
            }


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
        public String Calculate(String s) 
        {
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
