using System.Collections.Generic;

namespace CloudThingStore.Services.Entities
{
    public interface IProductCategory
    {
        int Id { get; set; }
        string Name { get; set; }
        List<ProductSubCategory> SubCategories { get; set; }
    }
}