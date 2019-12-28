using System;
using System.Reflection;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = new MyClass();
            TypeInfo typeInfo = typeof(MyClass).GetTypeInfo();
            var attrs = typeInfo.GetCustomAttributes();
            foreach(var attr in attrs)
                Console.WriteLine("Attribute on MyClass: " + attr.GetType().Name);

        }
    }
}