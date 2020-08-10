using System.Collections.Generic;
namespace CloudThingStore.Entities {
    public class ProductCategory {
        public int id { get; set; }
        public string name { get; set; }
        public List<ProductSubCategory> subCategories {get; set;}
    }
}