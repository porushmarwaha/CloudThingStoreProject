using System;
using CloudThingStore.Entities;
using CloudThingStore.Exceptions;
using CloudThingStore.Services;
namespace CloudThingStoreConsoleApp {
    public class ProductCategoryServiceFunctions {
        ProductCategoryService categoryService = new ProductCategoryService ();
        SubCategoryService subCategoryService = new SubCategoryService(categoryService);
        ProductCategory category;
        int id = 0;
        string name = "";
        internal void Add () {
            Console.Write ($"\nPlease enter Category - ");
            try {
                categoryService.Add (Console.ReadLine ());
            } catch (DuplicateCategoryException e) {
                Console.WriteLine (e.Message);
            }
        }
        internal void Print () {
            Console.WriteLine ("\nList of Category");
            var categoryList = categoryService.Get ();
            if (categoryList.Count == 0) {
                Console.WriteLine ("List is Empty");
                return;
            }
            categoryList.ForEach (element =>
                Console.WriteLine ($"Id - {element.Id}  Name - {element.Name}")); 
        }
        internal void Update () {
            Console.Write ("\nPlease enter Id - ");
            try {
                id = int.Parse (Console.ReadLine ());
                Console.Write ("Please enter new category Name - ");
                name = Console.ReadLine ();
            } catch (FormatException e) {
                Console.WriteLine (e.Message);
            }
            try {
                categoryService.Update (id, name);
            } catch (CategoryNotExistException e) {
                Console.WriteLine (e.Message);
            } catch (DuplicateCategoryException e) {
                Console.WriteLine (e.Message);
            }
        }
        internal void Search () {
            Console.Write ("\nPlease enter Id or Name- ");
            name = Console.ReadLine ();
            try {
                category = categoryService.Get (int.Parse (name));
            } catch {
                category = categoryService.Get (name);
            }
            categoryService.Get (Console.ReadLine ());
            Console.WriteLine ($"Id- {category.Id} Name - {category.Name}");
        }
        internal void Delete () {
            Console.Write ("\nPlease enter Id - ");
            try {
                if (categoryService.Delete (int.Parse (Console.ReadLine ())))
                    Console.WriteLine ($"Deleted Successfully");
                else Console.WriteLine ($"Id not existed");
            } catch (FormatException ex) {
                Console.WriteLine (ex.Message);
            }
        }
        internal void AddSubCategory () {
            Console.Write ("\nPlease enter Category Id -");
            try {
                id = int.Parse (Console.ReadLine ());
                Console.Write ("\nPlease type Sub category Name - ");
                name = Console.ReadLine ();
            } catch (FormatException e) {
                Console.WriteLine (e.Message);
            }
            // var subCategoryService = new SubCategoryService();  
            subCategoryService.Add (id, name);
        }
        internal void PrintAllCategories(){
            Console.WriteLine ("\nList of Category");
            var productCategories = categoryService.Get ();
            foreach (var category in productCategories) {
                Console.WriteLine ($"ID - {category.Id} NAME - {category.Name}");
                category.SubCategories.ForEach (element =>
                    Console.WriteLine ($"     ID - {element.Id} NAME - {element.Name}"));
            }
        }
    }
}
