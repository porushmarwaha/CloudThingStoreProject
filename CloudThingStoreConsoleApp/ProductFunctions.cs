using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;
using CloudThingStoreConsoleApp.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace CloudThingStoreConsoleApp {
    public class ProductFunctions {

        internal void AddProducts (IProductService productService , ILogger log) {
            decimal price = 0;

            System.Console.Write ("\nEnter category Name - ");
            string categoryName = Console.ReadLine ();

            System.Console.Write ("\nEnter Sub Category Name - ");
            string subCategoryName = Console.ReadLine ();

            System.Console.Write ("\nEnter Product Name - ");
            string productName = Console.ReadLine ();

            System.Console.Write ("Enter Price of the Item - ");

            try {
                price = decimal.Parse (Console.ReadLine ());
            } catch (FormatException e) {
                System.Console.WriteLine (e.Message);
            }

            productService.Add (categoryName, subCategoryName, productName, price);
            System.Console.WriteLine ("Product is Added Successfully");
        }
        internal void DisplayAllProducts (IProductService productService, ILogger log) {
            var products = productService.Get ();

            if (0 == products.Count) {
                System.Console.WriteLine ("Product List is Empty");
                return;
            }

            System.Console.WriteLine ("Product List - \n");

            foreach (var product in products) {
                System.Console.WriteLine ($"  Product Id      - {product.Id}");
                System.Console.WriteLine ($"  Product         - {product.Name}");
                System.Console.WriteLine ($"  Price           - {product.Price}");

                if (0 < product.CategoryId)
                    System.Console.WriteLine ($"  Category ID     - {product.CategoryId}");

                if (0 < product.SubCategoryId)
                    System.Console.WriteLine ($"  Sub Category ID - {product.SubCategoryId}");
                System.Console.WriteLine ("");
            }
        }
        internal void ProductUpdate (IProductService productService, ILogger log) {
            int id = 0;
            string productName = "";
            decimal price = 0;
            try {
                System.Console.Write ("Please Enter Product ID - ");
                id = int.Parse (Console.ReadLine ());

                System.Console.Write ("Please Enter New Name - ");
                productName = Console.ReadLine ();

                System.Console.WriteLine ("Please enter new Price - ");
                price = decimal.Parse (Console.ReadLine ());

            } catch (FormatException e) {
                System.Console.WriteLine (e.Message);
            }
            try {
                productService.Update (id, productName, price);
            } catch (ProductNotExistException e) {
                System.Console.WriteLine (e);
            }
            System.Console.WriteLine ("Product is Updated Successfully");
        }
        internal void DeleteProduct (IProductService productService, ILogger log) {
            System.Console.WriteLine ("Please enter Product ID - ");
            int id = 0;
            try {
                id = int.Parse (Console.ReadLine ());
            } catch (FormatException e) {
                System.Console.WriteLine (e.Message);
            }
            if (productService.Delete (id))
                System.Console.WriteLine ("Deleted Successfully");
            else System.Console.WriteLine ("Prodcut Id does not Exist.");
        }
        internal void ProductInventoryInFile(IProductService productService, ILogger log)
        { 
            productService.WriteToFile(ProjectConfig.GetFilePath().write);
            
            Console.WriteLine(@"File is Prepared please go following path - C:\Users\RahulMarwaha\Desktop\CloudThingProducts\products.txt");
        }
    }
}