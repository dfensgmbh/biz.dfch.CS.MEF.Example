using System;
using System.Linq;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Configuration;

namespace SimpleCalculator
{


    class Program
    {
        private readonly CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator Calculator;

        private Program()
        {

            // An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            // Adds all the parts found in the given directory
            var folder = ConfigurationManager.AppSettings["ExtensionsFolder"];
            try
            {
                if(!Path.IsPathRooted(folder))
                {
                    folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
                }
                catalog.Catalogs.Add(new DirectoryCatalog(folder));
            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("WARNING: Loading extensions from '{0}' FAILED.\n{1}", folder, ex.Message));
            }
            finally
            {
                // Adds all the parts found in the same assembly as the Program class
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
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
            return this.Calculator.Calculate(s);
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
