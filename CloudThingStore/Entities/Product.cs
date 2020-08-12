namespace CloudThingStore.Entities
{
    public class Product
    {
        public int Id {get; internal set;}
        public string Name {get; set;}
        public float Price {get; set;}
        public int CategoryId {get; set;}
        public int SubCategoryId {get; set;}
         
    }
}