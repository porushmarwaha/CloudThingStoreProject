using System;
using CloudThingStore.Exceptions;
using CloudThingStore.Services;
namespace CloudThingStoreConsoleApp {
    public class ProductFunctions {

        string categoryName = "";
        string subCategoryName = "";
        string productName = "";
        float price = 0;
        int id = 0;

        internal void AddProducts(ProductService productService){
            System.Console.Write("\nEnter category Name - ");
            categoryName = Console.ReadLine();
            System.Console.Write("\nEnter Sub Category Name - ");
            subCategoryName = Console.ReadLine();
            System.Console.Write("\nEnter Product Name - ");
            productName = Console.ReadLine();
            System.Console.Write("Enter Price of the Item - ");
            try {
                price = float.Parse(Console.ReadLine());
            }catch(FormatException e){
                System.Console.WriteLine(e.Message);
            }
            try {
                productService.Add(categoryName,subCategoryName,productName,price);
            }catch(CategoryNotExistException e){
                System.Console.WriteLine(e.Message);
            }catch(SubCategoryNotExistException e){
                System.Console.WriteLine(e.Message);
            }catch(DuplicateProductException e){
                System.Console.WriteLine(e.Message);
            }
        }
        internal void DisplayAllProducts(ProductService productService){
            
            System.Console.WriteLine("Product List - \n");
            try{
                foreach(var product in productService.Get())
                    System.Console.WriteLine($"Product Id - {product.Id} Product - {product.Name}  Price - {product.Price}");
            }catch(ProductNotExistException e){
                System.Console.WriteLine(e.Message);
            }
        }
        internal void ProductUpdate(ProductService productService){
            System.Console.Write("Please Enter Product ID - ");
            id = int.Parse(Console.ReadLine());
            System.Console.Write("Please Enter New Name - ");
            productName = Console.ReadLine();
            System.Console.WriteLine("Please enter new Price - ");
            price = float.Parse(Console.ReadLine());

            productService.Update(id,productName,price);
            
        }
        internal void DeleteProduct(ProductService productService){
            System.Console.WriteLine("Please enter Product ID - ");
            id = int.Parse( Console.ReadLine() );
            if(productService.Delete(id))
                System.Console.WriteLine("Deleted Successfully");
        }
    }
}