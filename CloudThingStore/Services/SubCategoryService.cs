using System.Collections.Generic;
using CloudThingStore.Entities;
using CloudThingStore.Exceptions;
namespace CloudThingStore.Services {
    public class SubCategoryService {
        private int _count = 0;
        public ProductCategoryService _Service { get; set; }
        public SubCategoryService(ProductCategoryService service){
            this._Service = service;
        }
        public ProductSubCategory Add (int categoryId, string name ) {
            //Get Product Category from Product Category Service class 
            var category = _Service.Get (categoryId);

            //Check if the category is null then throw an excetion
            if(category == null)
                throw new CategoryNotExistException(categoryId);

            //Check if the name already existed then throw an exception
            if(category.SubCategories.Exists(element => element.Name == name))
                throw new DuplicateCategoryException(name);
            
            // Add sub product category  
            var subCategory = new ProductSubCategory { CategoryId = categoryId, Id = ++_count, Name = name.ToLower () };
            category.SubCategories.Add (subCategory);
            return subCategory;
        }
    }
}   