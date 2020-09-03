using CloudThingStore.Services.Entities;
using CloudThingStore.Services.Exceptions;

namespace CloudThingStore.Services.Service
{
    public class ProductSubCategoryService : IProductSubCategoryService
    {
        private int _count = 0;
        private readonly IProductCategoryService _CategoryService;
        public ProductSubCategoryService(IProductCategoryService service)
        {
            _CategoryService = service;
        }
        public ProductSubCategory Add(int categoryId, string name)
        {
            var category = _CategoryService.Get(categoryId);

            if (null == category)
                throw new CategoryNotExistException();

            if (category.SubCategories.Exists(element => element.Name == name))
                throw new DuplicateSubCategoryException();

            var subCategory = new ProductSubCategory { CategoryId = categoryId, Id = ++_count, Name = name };
            category.SubCategories.Add(subCategory);

            return subCategory;
        }
        public ProductSubCategory Update(int categoryId, string oldName, string newName)
        {
            var category = _CategoryService.Get(categoryId);

            if (null == category)
                throw new CategoryNotExistException();

            if (!category.SubCategories.Exists(element => element.Name == oldName))
                throw new SubCategoryNotExistException();

            if (category.SubCategories.Exists(element => element.Name == newName))
                throw new DuplicateSubCategoryException();

            var subCategory = category.SubCategories.Find(element => element.Name == oldName);
            subCategory.Name = newName;

            return subCategory;
        }

        public bool Delete(int categoryId, string name)
        {
            var category = _CategoryService.Get(categoryId);

            if (null == category)
                throw new CategoryNotExistException();

            var subCategoryId = category.SubCategories.Find(element => element.Name == name);

            return category.SubCategories.Remove(subCategoryId);
        }
    }
}
