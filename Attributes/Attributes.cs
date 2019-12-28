using System;

namespace Attributes
{
    public class MySpecialAttribute : Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class MyAttributeForClassAndStructOnly : Attribute
    {
        
    }
}