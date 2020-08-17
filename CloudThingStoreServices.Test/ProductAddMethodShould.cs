using CloudThingStore.Services.Service;
using NUnit.Framework;

namespace CloudThingStoreServices.Test
{
    [TestFixture]
    public class ProductAddMethodShould
    {
        [Test]
        public void ReturnProductObject()
        {
            // Arange 
            var categoryService = new ProductCategoryService();
            var productTest = new ProductService(categoryService);
            
            // Act
            var product = productTest.Add("", "", "Apple", 20);

            // Assert
            Assert.AreEqual(product.Id, 1);
            Assert.AreEqual(product.Name, "Apple");
            Assert.AreEqual(product.Price, 20);
            Assert.AreEqual(product.SubCategoryId, -1);
            Assert.AreEqual(product.CategoryId, -1);
        }
    }
}
