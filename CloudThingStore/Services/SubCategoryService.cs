using CloudThingStore.Entities;

namespace CloudThingStore.Services
{
    public class SubCategoryService
    {
        public ProductCategoryService categoryService = new ProductCategoryService();
        private int _count = 0;
        public ProductSubCategory Add(int id , string name){
            var category = categoryService.Get(id);
            var subCategory = new ProductSubCategory { id = ++_count, name = name.ToLower()};
            category.subCategories.Add(subCategory);
            return subCategory;
        }
 
    }
}