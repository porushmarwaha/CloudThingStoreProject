using CloudThingStore.Services.Entities;
using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;
using CloudThingStoreServices.Test.Categories;
using NUnit.Framework;

namespace CloudThingStoreServices.Test
{
    [Product]
    class ProductServiceClassShould
    {
        private ProductCategoryService _category;
        private ProductService _product;
        private ProductSubCategoryService _subCategory;


        [SetUp]
        public void SetUp()
        {
            _category = new ProductCategoryService();
            _product = new ProductService(_category);
            _subCategory = new ProductSubCategoryService(_category);
        }
     
        
        // Add Method
        
        [Test]
        public void ReturnAddMethodWithProductCorrectValuesAndOnlyProductDetails()
        {
            var actual = _product.Add("Food" ,"Fruits" , "Mango" ,80);

            Assert.That(actual, Has.Property("CategoryId")
                                        .EqualTo(-1)
                                        .And
                                        .Property("SubCategoryId")
                                        .EqualTo(-1)
                                        .And
                                        .Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Mango")
                                        .And
                                        .Property("Price")
                                        .EqualTo(80)
                        );
        }
        [Test]
        public void ReturnAddMethodWithProductCorrectValuesAndProductWithCategoryDetails()
        {
            _category.Add("Food");

            var actual = _product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(actual, Has.Property("CategoryId")
                                        .EqualTo(1)
                                        .And
                                        .Property("SubCategoryId")
                                        .EqualTo(-1)
                                        .And
                                        .Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Mango")
                                        .And
                                        .Property("Price")
                                        .EqualTo(80)
                        );

        }
        [Test]
        public void ReturnAddMethodWithProductCorrectValuesAndProductWithCategoryAndSubcategoryDetails()
        {    
            _category.Add("Food");

            _subCategory.Add(1, "Fruits");

            var actual = _product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(actual, Has.Property("CategoryId")
                                        .EqualTo(1)
                                        .And
                                        .Property("SubCategoryId")
                                        .EqualTo(1)
                                        .And
                                        .Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Mango")
                                        .And
                                        .Property("Price")
                                        .EqualTo(80)
                        );
        }

        
        // Update
        
        [Test]
        public void ReturnUpdateProductObjectWithProductCorrectValues()
        {
            _category.Add("Food");

            _subCategory.Add(1, "Fruits");

            _product.Add("Food", "Fruits", "Mango", 80);

            var actual = _product.Update(1, "Apple", 110);

            Assert.That(actual , Has.Property("CategoryId")
                                        .EqualTo(1)
                                        .And
                                        .Property("SubCategoryId")
                                        .EqualTo(1)
                                        .And
                                        .Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Apple")
                                        .And
                                        .Property("Price")
                                        .EqualTo(110)
                        );
        }
        [Test]
        public void ReturnUpdatePWithProductInCorrectUpdateValues()
        {
            _category.Add("Food");

            _subCategory.Add(1, "Fruits");

            _product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(() => _product.Update(5, "Apple", 110), Throws.TypeOf<ProductNotExistException>());
        }

        
        //Delete Method

        [Test]
        public void ReturnDeleteMethodWithCorrectValues()
        {
            _category.Add("Food");

            _subCategory.Add(1, "Fruits");

            _product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(() => _product.Delete(1) , Is.True);
        }
        [Test]
        public void ReturnDeleteMethodWithInCorrectValues()
        {
            _category.Add("Food");

            _subCategory.Add(1, "Fruits");

            _product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(() => _product.Delete(10), Is.False);
        }

        
        //Get Method
        
        [Test]
        public void ReturnOfGetMethodWithValues()
        {
            _product.Add("Food", "Fruits", "Mango", 80);
            _product.Add("Food", "Fruits", "Apple", 90); 
            _product.Add("Food", "Fruits", "Guava", 100);

            var actual = _product.Get();

            Assert.That(actual, Has.Exactly(3).Items);

            Assert.That(actual, Has.Exactly(1)
                                        .Matches<Product>(
                                            item =>  item.Id == 3 &&
                                                     item.CategoryId == -1 &&
                                                     item.SubCategoryId == -1 &&
                                                     item.Name == "Guava" &&
                                                     item.Price == 100
                ));
        }
        [Test]
        public void ReturnOfGetMethodWithNull()
        {
            var actual = _product.Get();

            Assert.That(actual, Is.Empty);
        }
    }
}
