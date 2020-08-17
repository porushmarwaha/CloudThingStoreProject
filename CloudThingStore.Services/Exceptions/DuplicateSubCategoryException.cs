using System;

namespace CloudThingStore.Services.Exceptions
{
    public class DuplicateSubCategoryException : Exception
    {
        public DuplicateSubCategoryException() : base("Duplicate Sub Category")
        {

        }
    }
}
