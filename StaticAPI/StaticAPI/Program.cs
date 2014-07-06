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
            var file = args[0];
            var assembly = Assembly.LoadFrom(file);
            var t4 = new API();
            t4.Controllers = assembly.GetTypes().Where(t => t.Name.EndsWith("Controller"));
            File.WriteAllText("API.ts", t4.TransformText());
        }
    }
}
