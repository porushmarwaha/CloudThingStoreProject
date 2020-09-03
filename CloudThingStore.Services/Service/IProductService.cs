using CloudThingStore.Services.Entities;
using System.Collections.Generic;

namespace CloudThingStore.Services.Service
{
    public interface IProductService
    {
        Product Add(string categoryName, string subCategoryName, string name, decimal price);
        bool Delete(int id);
        List<Product> Get();
        Product Update(int id, string newName, decimal newPrice);
        void WriteToFile(string path);
    }
}