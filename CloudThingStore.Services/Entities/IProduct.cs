namespace CloudThingStore.Services.Entities
{
    public interface IProduct
    {
        int CategoryId { get; set; }
        int Id { get; }
        string Name { get; set; }
        decimal Price { get; set; }
        int SubCategoryId { get; set; }
    }
}