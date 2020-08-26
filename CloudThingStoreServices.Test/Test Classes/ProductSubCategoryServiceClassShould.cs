using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;
using CloudThingStoreServices.Test.Categories;
using NUnit.Framework;

namespace CloudThingStoreServices.Test
{
    [ProductSubCategory]
    class ProductSubCategoryServiceClassShould
    {
        private ProductCategoryService _category;
        private ProductSubCategoryService _subCategory;

        [SetUp]
        public void SetUp()
        {
            _category = new ProductCategoryService();
            _subCategory = new ProductSubCategoryService(_category);

            _category.Add("Computers");
            _category.Add("Food");
        }


        // Add Method

        [Test]
        public void ReturnAddMethodObjectWithCorrectValues()
        {
            var actual = _subCategory.Add(2, "Meat");

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
        public void ReturnAddMethodOfIncorrectCategoryId() => 
            Assert.That(() => _subCategory.Add(5, "Meat")  , Throws.TypeOf<CategoryNotExistException>() );
        
        [Test]
        public void ReturnAddMethodOfDuplicateSubCategory()
        {
            _subCategory.Add(2, "Meat");

            Assert.That(() => _subCategory.Add(2, "Meat"), Throws.TypeOf<DuplicateSubCategoryException>());
        }
        

        // Update Method
        
        [Test]
        public  void ReturnUpdateMethodObjectWithCorrectValues()
        {
            _subCategory.Add(2, "Meat");
            var actual = _subCategory.Update(2, "Meat" , "Fishes");

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
            _subCategory.Add(2, "Meat");

            Assert.That(() => _subCategory.Update(5, "Meat" , "Fishes"), Throws.TypeOf<CategoryNotExistException>());
        }
        [Test]
        public void ReturnUpdateMethodOfNonExistingSubCategory()
        { 
            _subCategory.Add(2, "Meat");

            Assert.That(() => _subCategory.Update(2, "Vegetables", "Fishes"), Throws.TypeOf<SubCategoryNotExistException>());
        }
        [Test]
        public void ReturnUpdateMethodOfDuplicateSubCategory()
        {
            _subCategory.Add(2, "Meat");

            Assert.That(() => _subCategory.Update(2, "Meat" ,"Meat"), Throws.TypeOf<DuplicateSubCategoryException>());
        }

        
        //Delete Method

        [Test]
        public void ReturnDeleteMethodWithCorrectCategoryId()
        {
            _subCategory.Add(2, "Meat");

            Assert.That(() => _subCategory.Delete(2 , "Meat") , Is.True);
        }
        [Test]
        public void ReturnDeleteMethodWithIncorrectCategoryId()
        {
            _subCategory.Add(2, "Meat");

            Assert.That(() => _subCategory.Delete(3, "Meat"), Throws.TypeOf<CategoryNotExistException>());
        }
        [Test]
        public void ReturnDeleteMethodWithIncorrectSubCategoryName()
        {
            _subCategory.Add(2, "Meat");

            Assert.That(() => _subCategory.Delete(2, "Vegetables"), Is.False);
        }
    }
}
