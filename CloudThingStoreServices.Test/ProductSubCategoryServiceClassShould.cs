using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;
using NUnit.Framework;

namespace CloudThingStoreServices.Test
{
    [Category("Product SubCategory Service")]
    class ProductSubCategoryServiceClassShould
    {
        // Add Method
        [Test]
        public void ReturnAddMethodObjectWithCorrectValues()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            var actual = subCategory.Add(2, "Meat");

            Assert.That(actual, Has.Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("CategoryId")
                                        .EqualTo(2)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Meat")
                        );
        }
        [Test]
        public void ReturnAddMethodOfIncorrectCategoryId()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            Assert.That(() => subCategory.Add(5, "Meat")  , Throws.TypeOf<CategoryNotExistException>() );
        }
        [Test]
        public void ReturnAddMethodOfDuplicateSubCategory()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");

            Assert.That(() => subCategory.Add(2, "Meat"), Throws.TypeOf<DuplicateSubCategoryException>());
        }
        

        // Update Method
        [Test]
        public  void ReturnUpdateMethodObjectWithCorrectValues()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");
            var actual = subCategory.Update(2, "Meat" , "Fishes");

            Assert.That(actual, Has.Property("Id")
                                        .EqualTo(1)
                                        .And
                                        .Property("CategoryId")
                                        .EqualTo(2)
                                        .And
                                        .Property("Name")
                                        .EqualTo("Fishes")
                        );
        }
        [Test]
        public void ReturnUpdateMethodOfNonExistingCategory()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");

            Assert.That(() => subCategory.Update(5, "Meat" , "Fishes"), Throws.TypeOf<CategoryNotExistException>());
        }
        [Test]
        public void ReturnUpdateMethodOfNonExistingSubCategory()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");

            Assert.That(() => subCategory.Update(2, "Vegetables", "Fishes"), Throws.TypeOf<SubCategoryNotExistException>());
        }
        [Test]
        public void ReturnUpdateMethodOfDuplicateSubCategory()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");

            Assert.That(() => subCategory.Update(2, "Meat" ,"Meat"), Throws.TypeOf<DuplicateSubCategoryException>());
        }

        //Delete Method

        [Test]
        public void ReturnDeleteMethodWithCorrectCategoryId()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");

            Assert.That(() => subCategory.Delete(2 , "Meat") , Is.True);
        }
        [Test]
        public void ReturnDeleteMethodWithIncorrectCategoryId()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");

            Assert.That(() => subCategory.Delete(3, "Meat"), Throws.TypeOf<CategoryNotExistException>());
        }
        [Test]
        public void ReturnDeleteMethodWithIncorrectSubCategoryName()
        {
            var category = new ProductCategoryService();
            var subCategory = new ProductSubCategoryService(category);

            category.Add("Computers");
            category.Add("Food");

            subCategory.Add(2, "Meat");

            Assert.That(() => subCategory.Delete(2, "Vegetables"), Is.False);
        }
    }
}
