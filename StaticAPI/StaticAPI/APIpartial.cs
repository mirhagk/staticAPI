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
        public string GetHttpMethod(MethodInfo method)
        {
            return "Get";
        }
        public bool HasDataPart(MethodInfo method)
        {
            if (GetHttpMethod(method) == "Post")
                return true;
            return false;
        }
        public string GetParams(MethodInfo method)
        {
            return "[" + string.Join(",", method.GetParameters().Select(p => p.Name)) + "]";
        }
        public string GetData(MethodInfo method)
        {
            throw new NotImplementedException();
        }
        public List<Type> CustomTypes = new List<Type>();
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
            if (type == typeof(string) || type == typeof(long) || type == typeof(Guid))
                return "string";
            if (type == typeof(object))
                return "Object";
            if (typeof(Array).IsAssignableFrom(type))
                return TypescriptType(type.GetElementType()) + "[]";
            var ienumerableInterfaces = type.GetInterfaces().Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)).Select(t => t.GetGenericTypeDefinition());

            if (ienumerableInterfaces.Any())
            {
                if (ienumerableInterfaces.Count() > 1)
                {
                    if (multipleInterfaceSetting == MultipleInterfaceSetting.TreatAsAny)
                        return "any";
                    throw new NotImplementedException();
                }
                return TypescriptType(type.GetGenericArguments().First()) + "[]";
                //TODO Not sure if the above is the correct way to determine the type
                //return TypescriptType(ienumerableInterfaces.First().GetGenericArguments().First()) + "[]";
            }

            //Record this type so that we can generate an interface for it later
            if (!CustomTypes.Contains(type))
                CustomTypes.Add(type);
            if (type.IsGenericType)
            {
                return type.Name.Substring(0, type.Name.Length - 2) + "<" +
                    string.Join(",", type.GetGenericArguments().Select(t => TypescriptType(t))) + ">";
            }
            //Must be a non-generic custom type, just return the name
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
