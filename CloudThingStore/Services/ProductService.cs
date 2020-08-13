using System.Collections.Generic;
using CloudThingStore.Entities;
using CloudThingStore.Exceptions;
namespace CloudThingStore.Services {
    public class ProductService {
        private int _count = 0;
        private List<Product> _Products;
        private ProductCategoryService _CategoryService;
        public ProductService (ProductCategoryService categoryService) {
            _Products = new List<Product> ();
            _CategoryService = categoryService;
        }

        public Product Add (string categoryName, string subCategoryName, string name, decimal price) {
            int category = -1;
            int subCategory = -1;

            if (_Category (categoryName) != null)
                category = _Category (categoryName).Id;

            if (_SubCategory (categoryName, subCategoryName) != null)
                subCategory = _SubCategory (categoryName, subCategoryName).Id;

            var product = new Product { Id = ++_count, Name = name, Price = price, CategoryId = category, SubCategoryId = subCategory };
            _Products.Add (product);
            return product;
        }
        public List<Product> Get () => _Products;

        public Product Update (int id, string newName, decimal newPrice) {

            var product = _Products.Find (element => element.Id == id);

            if (product == null)
                throw new ProductNotExistException ();

            product.Name = newName;
            product.Price = newPrice;

            return product;
        }
        public bool Delete (int id) {
            var product = _Products.Find (element => element.Id == id);

            if (product == null)
                throw new ProductNotExistException ();

            return _Products.Remove (product);
        }
        private ProductCategory _Category (string categoryName) => _CategoryService.Get (categoryName);
        private ProductSubCategory _SubCategory (string categoryName, string subCategoryName) {
            if (_Category (categoryName) != null)
                return _Category (categoryName).SubCategories.Find (element => element.Name == subCategoryName);
            return null;
        }
    }
}