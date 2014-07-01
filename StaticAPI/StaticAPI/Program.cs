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
            var assembly = Assembly.LoadFile(args[0]);
            foreach (var type in assembly.DefinedTypes.Where(t => t.Name.EndsWith("Controller")))
                Console.WriteLine("{0} {1}", type.Name, type);
        }
    }
}
