using CloudThingStore.Services.Entities;
using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;
using CloudThingStoreServices.Test.Categories;
using NUnit.Framework;

namespace CloudThingStoreServices.Test
{
    [ProductCategory]
    class ProductCategoyServiceClassShould
    {
        private ProductCategoryService _categories;
        private ProductCategoryService _category;

       
        //Setup Code
        
        [SetUp]
        public void Setup()
        {
            _categories = new ProductCategoryService();
            _category = new ProductCategoryService();
        }
        

        // Add Method
        
        [Test]
        public void ReturnProductCaegoryObjectByAddMethod()
        {
            var actual =  _categories.Add("Computers");

            Assert.That(actual, Has.Property("Name").EqualTo("Computers"));
        }
        [Test]
        public void ReturnOfEmptyStringInAddMethod()
        {
            var actual = _categories.Add("");

            Assert.That(actual, Has.Property("Name").Contains(string.Empty));
        }
        [Test]
        public void NotAllowDuplicateCategoryInAddMethod()
        {
            _category.Add("Computers");

            Assert.That(() => _category.Add("Computers") , Throws.TypeOf<DuplicateCategoryException>());
        }


        // Update Methods

        [Test]
        public void CheckUpdateMethodWithCorrectValues()
        {
            _category.Add("Computers");
            _category.Add("Laptops");

            var actual = _category.Update(1, "Electronics");

            Assert.That(actual, Has.Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Electronics")
                                );
            actual = _category.Update(2, "Food");

            Assert.That(actual, Has.Property("Id")
                                        .EqualTo(2)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Food")
                                );
        }
        [Test]
        public void NotAllowDuplicateCategoryInUpdateMethod()
        {
           
            _category.Add("Computers");

            Assert.That(() => _category.Update(1,"Computers") , Throws.TypeOf<DuplicateCategoryException>());
        }
        [Test]
        public void CheckWhenCategoryIdDoesNotExist()
        {
            _category.Add("Computers");

            Assert.That(() => _category.Update(10, "Computers"), Throws.TypeOf<CategoryNotExistException>());
        }
        [Test]
        public void CheckWhenCategoryIdDoesNotExistAndListIsNull() => 
            Assert.That(() => _category.Update(1, "Computers"), Throws.TypeOf<CategoryNotExistException>());


        // Get Method
        
        [Test]
        public void ReturnEntireProductCaegoryList()
        {   
            _category.Add("Computers");
            _category.Add("Laptops");
            _category.Add("Food");

            var actual = _category.Get();

            Assert.That(actual, Has.Exactly(3).Items);

            Assert.That(actual, Has.Exactly(1)
                                        .Matches<ProductCategory>(
                                            item => item.Id == 3 &&
                                                    item.Name == "Food"
                                        ));
        }
        [Test]
        public void ReturnProductCategoryObjectById()
        {
            _category.Add("Computers");
            _category.Add("Laptops");
            _category.Add("Food");

            var actual = _category.Get(2);

            Assert.That(actual, Has.Property("Id")
                                        .EqualTo(2)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Laptops")
                       );
        }
        [Test]
        public void ReturnProductCategoryObjectByName()
        {
        
            _category.Add("Computers");
            _category.Add("Laptops");
            _category.Add("Food");

            var actual = _category.Get("Laptops");

            Assert.That(actual, Has.Property("Name")
                                        .EqualTo("Laptops")
                                        .And
                                        .Property("Id")
                                        .EqualTo(2)
                       );


        }
        [Test]
        public void ReturnListFromGetMethod()
        {
            
            var actual = _categories.Get();

            Assert.That(actual, Is.Empty);
        }
        [Test]
        public void ReturnWhenNotExistingIdIsProvidedToGetMethod()
        {
            var actual = _category.Get(1);

            Assert.That(actual, Is.EqualTo(null));
        }
        [Test]
        public void ReturnWhenNotExistingNameIsProvidedToGetMethod()
        {
            var actual = _category.Get("Computers");

            Assert.That(actual, Is.EqualTo(null));
        }

        
        // Delete Method
        
        [Test]
        public void ReturnBoolValueOfDeleteMethodWhenIdExisted()
        {
            _category.Add("Computers");
            _category.Add("Laptops");
            _category.Add("Food");

            var actual = _category.Delete(1);

            Assert.That(actual, Is.EqualTo(true));
        }
        [Test]
        public void ReturnOfDeleteMethodWhenWrongIdIsProvided()
        {
            var actual = _category.Delete(1);

            Assert.That(actual, Is.EqualTo(false));
        }

    }
}
