using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StaticAPI
{
    partial class API
    {
        public IEnumerable<Type> Controllers { get; set; }
        public MethodInfo[] GetMethods(Type controller)
        {
            return controller.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        }
        private void Playground()
        {
            var methods = this.Controllers.First().GetMethods(System.Reflection.BindingFlags.DeclaredOnly);
            //methods.First().Name
        }
    }
}
