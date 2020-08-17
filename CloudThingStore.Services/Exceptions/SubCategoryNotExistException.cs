using System;

namespace CloudThingStore.Services.Exceptions
{
    public class SubCategoryNotExistException : Exception
    {
        public SubCategoryNotExistException() : base("Sub Category Not Exist")
        {

        }
    }
}
