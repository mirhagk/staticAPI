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
        public enum MultipleInterfaceSetting
        {
            TreatAsAny, MostSpecific, LeastSpecific
        }
        public MultipleInterfaceSetting multipleInterfaceSetting = MultipleInterfaceSetting.TreatAsAny;
        public IEnumerable<Type> Controllers { get; set; }
        public IEnumerable<MethodInfo> GetMethods(Type controller)
        {
            return controller.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        }
        public List<string> UnrecognizedTypes = new List<string>();
        public string TypescriptType(Type type)
        {
            if (type == typeof(int)
                || type == typeof(float)
                || type == typeof(byte)
                || type == typeof(sbyte)
                || type == typeof(short)
                || type == typeof(ushort)
                || type == typeof(uint)
                || type == typeof(double)
                )
                return "number";
            if (type == typeof(void))
                return "void";
            if (type == typeof(string) || type == typeof(long))
                return "string";
            if (type == typeof(object))
                return "Object";
            if (typeof(Array).IsAssignableFrom(type))
                return TypescriptType(type.GetElementType()) + "[]";
            var ienumerableInterfaces = type.GetInterfaces().Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)).Select(t => t.GetGenericTypeDefinition());

            if (ienumerableInterfaces.Any())
            {
                if (ienumerableInterfaces.Count()>1)
                {
                    if (multipleInterfaceSetting == MultipleInterfaceSetting.TreatAsAny)
                        return "any";
                    throw new NotImplementedException();
                }
                return TypescriptType(ienumerableInterfaces.First().GetGenericArguments().First()) + "[]";
            }

            if (!UnrecognizedTypes.Contains(type.Name))
                UnrecognizedTypes.Add(type.Name);
            return type.Name;
        }
        private void Playground()
        {
            var methods = this.Controllers.First().GetMethods(System.Reflection.BindingFlags.DeclaredOnly);
            var param = methods.First().GetParameters().First();
            //param.ParameterType
        }
    }
}
