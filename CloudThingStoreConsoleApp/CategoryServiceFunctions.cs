using System;
using CloudThingStore.Entities;
using CloudThingStore.Exceptions;
using CloudThingStore.Services;
namespace CloudThingStoreConsoleApp {
    public class CategoryServiceFunctions {
        ProductCategory category;
        int id = 0;
        string name = "";
        internal void Add (ProductCategoryService categoryService) {
            Console.Write ($"\nPlease enter Category - ");
            try {
                category = categoryService.Add (Console.ReadLine ());
            } catch (DuplicateCategoryException e) {
                Console.WriteLine (e);
            }
            Console.WriteLine("Category Added Successfully");
        }
        internal void Print (ProductCategoryService categoryService) {
            Console.WriteLine ("\nList of Category");
            var categoryList = categoryService.Get ();
            if (categoryList.Count == 0) {
                Console.WriteLine ("List is Empty");
                return;
            }
            categoryList.ForEach (element =>
                Console.WriteLine ($"Id - {element.Id}  Name - {element.Name}")); 
        }
        internal void Update (ProductCategoryService categoryService) {
            Console.Write ("\nPlease enter Id - ");
            try {
                id = int.Parse (Console.ReadLine ());
                Console.Write ("Please enter new category Name - ");
                name = Console.ReadLine ();
            } catch (FormatException e) {
                Console.WriteLine (e.Message);
            }
            try {
                category = categoryService.Update (id, name);
            } catch (CategoryNotExistException e) {
                Console.WriteLine (e.Message);
            } catch (DuplicateCategoryException e) {
                Console.WriteLine (e.Message);
            }
            Console.WriteLine("Category Updated Successfully");
        }
        internal void Search (ProductCategoryService categoryService) {
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
        internal void Delete (ProductCategoryService categoryService) {
            Console.Write ("\nPlease enter Id - ");
            try {
                if (categoryService.Delete (int.Parse (Console.ReadLine ())))
                    Console.WriteLine ($"Deleted Successfully");
                else Console.WriteLine ($"Id not existed");
            } catch (FormatException ex) {
                Console.WriteLine (ex.Message);
            }
        }
    }
}
