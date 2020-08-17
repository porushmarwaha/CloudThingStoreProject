using System;

namespace CloudThingStore.Services.Exceptions
{
    public class ProductNotExistException : Exception
    {
        public ProductNotExistException() : base("Product Not Exist") { }
    }
}
