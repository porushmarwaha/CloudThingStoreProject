using System;

namespace CloudThingStore.Services.Exceptions
{
    public class DuplicateCategoryException : Exception
    {
        public DuplicateCategoryException() : base("Duplicate Category")
        {
        }
    }
}
