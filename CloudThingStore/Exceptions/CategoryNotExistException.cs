using System;

namespace CloudThingStore.Exceptions{
    public class CategoryNotExistException : Exception {
        public CategoryNotExistException(int id) : base(id + " - Id not Found") { 
        }
    }
}