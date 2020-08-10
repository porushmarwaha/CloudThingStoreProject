using System;

namespace CloudThingStore.Exceptions{
    public class DuplicateCategoryException : Exception{
         public DuplicateCategoryException(string name) : base(name + " Already Existed") {
        }
    }
}