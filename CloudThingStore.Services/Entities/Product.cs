
namespace CloudThingStore.Services.Entities
{
    public class Product : IProduct
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
