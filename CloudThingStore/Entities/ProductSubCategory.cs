using System.Collections.Generic;
namespace CloudThingStore.Entities {
    public class ProductSubCategory {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public List<Product> Products {get; set;}
        public ProductSubCategory(){
            this.Products = new List<Product>();
        }
    }
}