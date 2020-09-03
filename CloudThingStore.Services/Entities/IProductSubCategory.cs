using System.Collections.Generic;

namespace CloudThingStore.Services.Entities
{
    public interface IProductSubCategory
    {
        int CategoryId { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set; }
    }
}