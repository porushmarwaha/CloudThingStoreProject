using NUnit.Framework;
using System;

namespace CloudThingStoreServices.Test.Categories
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class ProductSubCategoryAttribute : CategoryAttribute
    {
    }
}
