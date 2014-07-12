using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace StaticAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = args[0];
            var output = args.Length > 1 ? args[1] : "API.ts";
            var assembly = Assembly.LoadFrom(input);
            var t4 = new API();
            t4.Controllers = assembly.GetTypes().Where(t => t.Name.EndsWith("Controller"));
            File.WriteAllText(output, t4.TransformText());
        }
    }
}
