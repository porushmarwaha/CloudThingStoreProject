
using CloudThingStore.Services.Entities;
using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;
using NUnit.Framework;

namespace CloudThingStoreServices.Test
{
    [Category ("Product Service")]
    class ProductServiceClassShould
    {
        [Test]
        public void ReturnAddMethodWithProductCorrectValuesAndOnlyProductDetails()
        {
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            var actual = product.Add("Food" ,"Fruits" , "Mango" ,80);

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
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            category.Add("Food");

            var actual = product.Add("Food", "Fruits", "Mango", 80);

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
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            var subCategory = new ProductSubCategoryService(category);
            
            category.Add("Food");

            subCategory.Add(1, "Fruits");

            var actual = product.Add("Food", "Fruits", "Mango", 80);

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
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            var subCategory = new ProductSubCategoryService(category);

            category.Add("Food");

            subCategory.Add(1, "Fruits");

            product.Add("Food", "Fruits", "Mango", 80);

            var actual = product.Update(1, "Apple", 110);

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
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            var subCategory = new ProductSubCategoryService(category);

            category.Add("Food");

            subCategory.Add(1, "Fruits");

            product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(() => product.Update(5, "Apple", 110), Throws.TypeOf<ProductNotExistException>());
        }

        //Delete Method

        [Test]
        public void ReturnDeleteMethodWithCorrectValues()
        {
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            var subCategory = new ProductSubCategoryService(category);

            category.Add("Food");

            subCategory.Add(1, "Fruits");

            product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(() => product.Delete(1) , Is.True);
        }
        [Test]
        public void ReturnDeleteMethodWithInCorrectValues()
        {
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            var subCategory = new ProductSubCategoryService(category);

            category.Add("Food");

            subCategory.Add(1, "Fruits");

            product.Add("Food", "Fruits", "Mango", 80);

            Assert.That(() => product.Delete(10), Is.False);
        }

        //Get Method
        [Test]
        public void ReturnOfGetMethodWithValues()
        {
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            product.Add("Food", "Fruits", "Mango", 80);
            product.Add("Food", "Fruits", "Apple", 90); 
            product.Add("Food", "Fruits", "Guava", 100);

            var actual = product.Get();

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
            var category = new ProductCategoryService();
            var product = new ProductService(category);

            var actual = product.Get();

            Assert.That(actual, Is.Empty);
        }
    }
}
