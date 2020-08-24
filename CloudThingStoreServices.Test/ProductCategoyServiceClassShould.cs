using CloudThingStore.Services.Entities;
using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;
using NUnit.Framework;

namespace CloudThingStoreServices.Test
{
    [Category("Product Category Service")]
    class ProductCategoyServiceClassShould
    {
        
        // Add Method
        [Test]
        public void ReturnProductCaegoryObjectByAddMethod()
        {
            var categories = new ProductCategoryService();
            var actual =  categories.Add("Computers");

            Assert.That(actual, Has.Property("Name").EqualTo("Computers"));
        }
        [Test]
        public void ReturnOfEmptyStringInAddMethod()
        {
            var categories = new ProductCategoryService();
            var actual = categories.Add("");

            Assert.That(actual, Has.Property("Name").Contains(string.Empty));
        }
        [Test]
        public void NotAllowDuplicateCategoryInAddMethod()
        {
            var category = new ProductCategoryService();
            category.Add("Computers");

            Assert.That(() => category.Add("Computers") , Throws.TypeOf<DuplicateCategoryException>());
        }



        // Update Methods

        [Test]
        public void CheckUpdateMethodWithCorrectValues()
        {
            var category = new ProductCategoryService();
            category.Add("Computers");
            category.Add("Laptops");

            var actual = category.Update(1, "Electronics");

            Assert.That(actual, Has.Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Electronics")
                                );
            actual = category.Update(2, "Food");

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
            var category = new ProductCategoryService();
            category.Add("Computers");

            Assert.That(() => category.Update(1,"Computers") , Throws.TypeOf<DuplicateCategoryException>());
        }
        [Test]
        public void CheckWhenCategoryIdDoesNotExist()
        {
            var category = new ProductCategoryService();
            category.Add("Computers");

            Assert.That(() => category.Update(10, "Computers"), Throws.TypeOf<CategoryNotExistException>());
        }
        [Test]
        public void CheckWhenCategoryIdDoesNotExistAndListIsNull()
        {
            var category = new ProductCategoryService();

            Assert.That(() => category.Update(1, "Computers"), Throws.TypeOf<CategoryNotExistException>());
        }



        // Get Method
        
        [Test]
        public void ReturnEntireProductCaegoryList()
        {
            var category = new ProductCategoryService();
            
            category.Add("Computers");
            category.Add("Laptops");
            category.Add("Food");

            var actual = category.Get();

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
            var category = new ProductCategoryService();

            category.Add("Computers");
            category.Add("Laptops");
            category.Add("Food");

            var actual = category.Get(2);

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
            var category = new ProductCategoryService();

            category.Add("Computers");
            category.Add("Laptops");
            category.Add("Food");

            var actual = category.Get("Laptops");

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
            
            var categories = new ProductCategoryService();
            var actual = categories.Get();

            Assert.That(actual, Is.Empty);
        }
        [Test]
        public void ReturnWhenNotExistingIdIsProvidedToGetMethod()
        {
            var category = new ProductCategoryService();
            var actual = category.Get(1);

            Assert.That(actual, Is.EqualTo(null));
        }
        [Test]
        public void ReturnWhenNotExistingNameIsProvidedToGetMethod()
        {
            var category = new ProductCategoryService();
            var actual = category.Get("Computers");

            Assert.That(actual, Is.EqualTo(null));
        }




        // Delete Method
        [Test]
        public void ReturnBoolValueOfDeleteMethodWhenIdExisted()
        {
            var category = new ProductCategoryService();
            category.Add("Computers");
            category.Add("Laptops");
            category.Add("Food");

            var actual = category.Delete(1);

            Assert.That(actual, Is.EqualTo(true));
        }

        [Test]
        public void ReturnOfDeleteMethodWhenWrongIdIsProvided()
        {
            var category = new ProductCategoryService();
            var actual = category.Delete(1);

            Assert.That(actual, Is.EqualTo(false));
        }

    }
}
