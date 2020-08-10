using System.Collections.Generic;
using System.Linq;
using CloudThingStore.Entities;
using CloudThingStore.Exceptions;
namespace CloudThingStore.Services {
    public class ProductCategoryService {
        private List<ProductCategory> _productCategories = new List<ProductCategory> ();
        private ProductCategory _category;
        private int _count = 0;
        public ProductCategory Add (string name) {
            if (_productCategories.Exists (element => element.Name == name.ToLower ()))
                throw new DuplicateCategoryException (name);

            _category = new ProductCategory { Id = ++_count, Name = name.ToLower () };
            _productCategories.Add (_category);
            return _category;
        }
        public ProductCategory Update (int id, string name) {
            if (!_productCategories.Exists (element => element.Id == id))
                throw new CategoryNotExistException (id);

            if (_productCategories.Exists (element => element.Name == name.ToLower ()))
                throw new DuplicateCategoryException (name);

            _category = _FindObjectById (id);
            _category.Name = name.ToLower ();
            return _category;
        }
        public List<ProductCategory> Get () => _productCategories;
        public ProductCategory Get (int id) => _FindObjectById (id);
        public ProductCategory Get (string name) => _productCategories.FirstOrDefault (element => element.Name == name.ToLower ());
        public bool Delete (int id) => _productCategories.Remove (_FindObjectById (id));
        private ProductCategory _FindObjectById (int id) => _productCategories.FirstOrDefault (element => element.Id == id);
    }
}