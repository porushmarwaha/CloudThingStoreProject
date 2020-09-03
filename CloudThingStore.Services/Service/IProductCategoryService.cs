using CloudThingStore.Services.Entities;
using System.Collections.Generic;

namespace CloudThingStore.Services.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(string name);
        bool Delete(int id);
        List<ProductCategory> Get();
        ProductCategory Get(int id);
        ProductCategory Get(string name);
        ProductCategory Update(int id, string name);
    }
}