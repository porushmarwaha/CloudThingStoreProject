using NUnit.Framework;
using System;

namespace CloudThingStoreServices.Test.Categories
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    class ProductAttribute : CategoryAttribute
    {
    }
}
