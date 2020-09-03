using CloudThingStore.Services.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace CloudThingStoreConsoleApp
{
    public class CloudThingConsole : ICloudThingConsole
    {
        private readonly IProductCategoryService _categoryService;
        private readonly IProductSubCategoryService _subCategoryService;
        private readonly IProductService _productService;
        private readonly ILogger<CloudThingConsole> _log;
        private readonly IConfiguration _config;
        public CloudThingConsole(ILogger<CloudThingConsole> log,
                        IConfiguration config,
                        IProductCategoryService _categoryService,
                        IProductSubCategoryService _subCategoryService,
                        IProductService _productService
                   )
        {
            this._categoryService = _categoryService;
            this._subCategoryService = _subCategoryService;
            this._productService = _productService;
            this._log = log;
            this._config = config;

        }
        public void Start()
        {
            var function = new CategoryServiceFunctions();
            var subFunction = new SubCategoryServiceFunctions();
            var productFunction = new ProductFunctions();

            while (true)
            {
                _log.LogInformation("Application Start");
                Console.WriteLine("\n1. Add a Category \n2. Print List of All Category \n3. Update Category by Id \n4. Search Category by Id or Name \n5. Delete Category by Id \n6. Add Sub Category \n7. Print All Categories and Sub Categories\n8. Update Sub Category\n9. Delete Sub Category\n10. Add Product \n11. Print All Products \n12. Update product \n13. Delete Product \n14. Write Product Details in File \n0. Exit ");

                Console.Write("Please Choose your Option - ");

                int input;
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Please give valid integer Input");
                    continue;
                }

                switch (input)
                {
                    case 1:
                        _log.LogInformation("ProductCategoryService  -> Add() is Started");
                        function.Add(_categoryService , _log);
                        _log.LogInformation("ProductCategoryService  -> Add() is Completed");
                        break;
                    case 2:
                        _log.LogInformation("ProductCategoryService  -> Print() is Started");
                        function.Print(_categoryService, _log);
                        _log.LogInformation("ProductCategoryService  -> Print() is Completed");
                        break;
                    case 3:
                        _log.LogInformation("ProductCategoryService  -> Update() is Started");
                        function.Update(_categoryService, _log);
                        _log.LogInformation("ProductCategoryService  -> Update() is Completed");
                        break;
                    case 4:
                        _log.LogInformation("ProductCategoryService  -> Search() is Started");
                        function.Search(_categoryService, _log);
                        _log.LogInformation("ProductCategoryService  -> Search() is Completed");
                        break;
                    case 5:
                        _log.LogInformation("ProductCategoryService  -> Delete() is Started");
                        function.Delete(_categoryService, _log);
                        _log.LogInformation("ProductCategoryService  -> Delete() is Completed");
                        break;
                    case 6:
                        _log.LogInformation("ProductSubCategoryService  -> Add() is Started");
                        subFunction.AddSubCategory(_subCategoryService, _log);
                        _log.LogInformation("ProductSubCategoryService  -> Add() is Completed");
                        break;
                    case 7:
                        _log.LogInformation("ProductSubCategoryService  -> Print() is Started");
                        subFunction.PrintAllCategories(_categoryService, _log);
                        _log.LogInformation("ProductSubCategoryService  -> Print() is Completed");
                        break;
                    case 8:
                        _log.LogInformation("ProductSubCategoryService  -> Update() is Started");
                        subFunction.UpdateSubCategory(_subCategoryService, _log);
                        _log.LogInformation("ProductSubCategoryService  -> Update() is Completed");
                        break;
                    case 9:
                        _log.LogInformation("ProductSubCategoryService  -> Delete() is Started");
                        subFunction.DeleteSubCategory(_subCategoryService, _log);
                        _log.LogInformation("ProductSubCategoryService  -> Delete() is Completed");
                        break;
                    case 10:
                        _log.LogInformation("ProductService  -> Add() is Started");
                        productFunction.AddProducts(_productService, _log);
                        _log.LogInformation("ProductService  -> Add() is Completed");
                        break;
                    case 11:
                        _log.LogInformation("ProductService  -> Print() is Started");
                        productFunction.DisplayAllProducts(_productService, _log);
                        _log.LogInformation("ProductService  -> Print() is Completed");

                        break;
                    case 12:
                        _log.LogInformation("ProductService  -> Update() is Started");
                        productFunction.ProductUpdate(_productService, _log);
                        _log.LogInformation("ProductService  -> Update() is Completed");

                        break;
                    case 13:
                        _log.LogInformation("ProductService  -> Delete() is Started");
                        productFunction.DeleteProduct(_productService, _log);
                        _log.LogInformation("ProductService  -> Delete() is Completed");
                        break;
                    case 14:
                        _log.LogInformation("ProductService  -> WriteToFile is Started");
                        productFunction.ProductInventoryInFile(_productService, _log);
                        _log.LogInformation("ProductService  -> WriteToFile is Completed");

                        break;
                    case 0:
                        _log.LogInformation("Exit Method is Called");
                        _log.LogInformation("Application End");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Input not match from given List Options");
                        break;
                }
            }
        }
    }
}
