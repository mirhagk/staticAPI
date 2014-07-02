using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace StaticAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = args[0];
            Console.WriteLine(file);
            var assembly = Assembly.LoadFrom(file);
            
            foreach (var type in assembly.GetTypes().Where(t=>t.Name.EndsWith("Controller")))
                Console.WriteLine("{0} {1}", type.Name, type);
            Console.ReadKey();
        }
    }
}
