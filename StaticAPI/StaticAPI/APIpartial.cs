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
        public IEnumerable<MethodInfo> GetMethods(Type controller)
        {
            return controller.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        }
        public string TypescriptType(Type type)
        {
            return "unknown";
        }
        private void Playground()
        {
            var methods = this.Controllers.First().GetMethods(System.Reflection.BindingFlags.DeclaredOnly);
            var param = methods.First().GetParameters().First();
            //param.ParameterType
        }
    }
}
