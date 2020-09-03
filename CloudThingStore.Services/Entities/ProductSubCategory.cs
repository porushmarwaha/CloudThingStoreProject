using System.Collections.Generic;

namespace CloudThingStore.Services.Entities
{
    public class ProductSubCategory : IProductSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
