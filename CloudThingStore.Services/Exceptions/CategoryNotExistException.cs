using System;

namespace CloudThingStore.Services.Exceptions
{
    public class CategoryNotExistException : Exception
    {
        public CategoryNotExistException() : base("Category Not Exist" )
        {
        }
    }
}
