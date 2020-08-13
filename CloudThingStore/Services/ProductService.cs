using System.Collections.Generic;
using CloudThingStore.Entities;
using CloudThingStore.Exceptions;
namespace CloudThingStore.Services {
    public class ProductService {
        private int _count = 0;
        private readonly ProductCategoryService _CategoryService;

        public ProductService(ProductCategoryService service){
            _CategoryService = service;
        }
        public Product Add(string catogryName , string subCategoryName, string name, float price){
            var category = _CategoryService.Get(catogryName);

            if(category == null )
                throw new CategoryNotExistException();

            var subCategory = category.SubCategories.Find(element => element.Name == subCategoryName);

            if (subCategory == null)
                throw new SubCategoryNotExistException();
            
            if(subCategory.Products.Exists(element => element.Name == name))
                throw new DuplicateProductException();
            
            var product = new Product{ Id = ++_count ,CategoryId = category.Id, SubCategoryId = subCategory.Id, Name = name, Price = price };
            subCategory.Products.Add(product);
            return product;
        }
        public List<Product> Get(){
            var categories = _CategoryService.Get();

            if(categories == null)
                throw new ProductNotExistException();

            var products = new List<Product>();

            foreach(var category in categories)
                foreach(var subcategory in category.SubCategories)
                    foreach(var product in subcategory.Products)
                        products.Add(product);
                
            return products;           
        }
        // Method is created based on refernce type
        public Product Update(int id ,string newName , float newPrice){
            //Go get the existing proeduct from the list based on id
            //Confirm that the product exists for given id . If not throw exception
            //Once you get reference to existing product, update the name and price
            //Send the updated product back.
            
            var products = Get(); //Ask weather is tight couple or not
        
            var product  = products.Find(element => element.Id == id);

            if(product == null)
                throw new ProductNotExistException(); //Product ID not exist Exception is required
            
            if(products.Exists(element => element.Name == newName))
                throw new DuplicateProductException();
            
            product.Name = newName;
            product.Price = newPrice;

            return product;
        }
        public bool Delete(int id){
            var products = Get();

            var product = products.Find(element => element.Id == id);
            
            if(product == null)
                throw new ProductNotExistException();
            
            return products.Remove(product);
        }
    }
}