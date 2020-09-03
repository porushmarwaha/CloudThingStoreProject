using CloudThingStore.Services.Entities;

namespace CloudThingStore.Services.Service
{
    public interface IProductSubCategoryService
    {
        ProductSubCategory Add(int categoryId, string name);
        bool Delete(int categoryId, string name);
        ProductSubCategory Update(int categoryId, string oldName, string newName);
    }
}