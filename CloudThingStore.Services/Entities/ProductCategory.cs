using System.Collections.Generic;

namespace CloudThingStore.Services.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductSubCategory> SubCategories { get; set; }
        public ProductCategory()
        {
            this.SubCategories = new List<ProductSubCategory>();
        }
    }
}
