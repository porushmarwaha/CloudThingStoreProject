using CloudThingStore.Services.Entities;
using CloudThingStore.Services.Exceptions;
using System.Collections.Generic;
using System.IO;

namespace CloudThingStore.Services.Service
{
    public class ProductService
    {
        private int _count = 0;
        private readonly List<Product> _Products;
        private readonly ProductCategoryService _CategoryService;

        public ProductService(ProductCategoryService categoryService)
        {
            _Products = new List<Product>();
            _CategoryService = categoryService;
        }

        public Product Add(string categoryName, string subCategoryName, string name, decimal price)
        {
            int category = -1;
            int subCategory = -1;

            if (null != _Category(categoryName))
                category = _Category(categoryName).Id;

            if (null != _SubCategory(categoryName, subCategoryName))
                subCategory = _SubCategory(categoryName, subCategoryName).Id;

            var product = new Product { Id = ++_count, Name = name, Price = price, CategoryId = category, SubCategoryId = subCategory };
            _Products.Add(product);

            return product;
        }
        public List<Product> Get() => _Products;

        public Product Update(int id, string newName, decimal newPrice)
        {

            var product = _Products.Find(element => element.Id == id);

            if (null == product)
                throw new ProductNotExistException();

            product.Name = newName;
            product.Price = newPrice;

            return product;
        }
        public bool Delete(int id)
        {
            var product = _Products.Find(element => element.Id == id);

            return _Products.Remove(product);
        }
        public void WriteToFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            using (StreamWriter sw = File.CreateText(path))
            {

                sw.WriteLine("");
                sw.WriteLine("Product Details");
                sw.WriteLine("");
                sw.WriteLine("-----------------------------------------------");
                sw.WriteLine("");
                foreach (var product in _Products)
                {
                    sw.WriteLine($" Product Id         - {product.Id}");
                    sw.WriteLine($" Product Name       - {product.Name}");
                    sw.WriteLine($" Product Price      - {product.Price}");
                    if (product.CategoryId > 0)
                        sw.WriteLine($" Category Id        - {product.CategoryId}");
                    if (product.SubCategoryId > 0)
                        sw.WriteLine($" Sub Category  Id   - {product.SubCategoryId}");
                    sw.WriteLine("");
                    sw.WriteLine("-----------------------------------------------");
                    sw.WriteLine("");

                }
            }
        }
        private ProductCategory _Category(string categoryName) => _CategoryService.Get(categoryName);
        private ProductSubCategory _SubCategory(string categoryName, string subCategoryName)
        {
            if (null != _Category(categoryName))
                return _Category(categoryName).SubCategories.Find(element => element.Name == subCategoryName);
            return null;
        }
    }
}
