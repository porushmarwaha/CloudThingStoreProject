﻿using CloudThingStore.Services.Entities;
using CloudThingStore.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace CloudThingStore.Services.Service
{
    public class ProductCategoryService
    {
        private readonly List<ProductCategory> _productCategories = new List<ProductCategory>();
        private int _count = 0;
        public ProductCategory Add(string name)
        {
            if (_productCategories.Exists(element => element.Name == name))
                throw new DuplicateCategoryException();

            var category = new ProductCategory { Id = ++_count, Name = name };
            _productCategories.Add(category);

            return category;
        }
        public ProductCategory Update(int id, string name)
        {
            if (!_productCategories.Exists(element => element.Id == id))
                throw new CategoryNotExistException();

            if (_productCategories.Exists(element => element.Name == name))
                throw new DuplicateCategoryException();

            var category = _FindObjectById(id);
            category.Name = name.ToLower();

            return category;
        }
        public List<ProductCategory> Get() => _productCategories;
        public ProductCategory Get(int id) => _FindObjectById(id);
        public ProductCategory Get(string name) => _productCategories.FirstOrDefault(element => element.Name == name);
        public bool Delete(int id) => _productCategories.Remove(_FindObjectById(id));
        private ProductCategory _FindObjectById(int id) => _productCategories.FirstOrDefault(element => element.Id == id);
    }
}