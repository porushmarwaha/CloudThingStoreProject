using System;
using CloudThingStore.Services.Exceptions;
using CloudThingStore.Services.Service;

namespace CloudThingStoreConsoleApp {
    public class SubCategoryServiceFunctions {
        int id = 0;
        string name = "";
        internal void AddSubCategory (ProductSubCategoryService subCategoryService) {
            Console.Write ("\nPlease enter Category Id -");

            try {
                id = int.Parse (Console.ReadLine ());
                Console.Write ("\nPlease type Sub category Name - ");
                name = Console.ReadLine ();
            } catch (FormatException e) {
                Console.WriteLine (e.Message);
            }

            try {
                subCategoryService.Add (id, name);
            } catch (DuplicateCategoryException e) {
                Console.WriteLine (e.Message);
            } catch (CategoryNotExistException e) {
                Console.WriteLine (e.Message);
            }

            Console.WriteLine ("Sub Category Added Successfully");
        }
        internal void PrintAllCategories (ProductCategoryService categoryService) {
            Console.WriteLine ("\nList of Category");
            
            try {
                foreach (var productCategory in categoryService.Get ()) {
                    
                    Console.WriteLine ($"ID - {productCategory.Id} NAME - {productCategory.Name}");
                    productCategory.SubCategories.ForEach (element =>
                        Console.WriteLine ($"   SUB    ID - {element.Id} NAME - {element.Name}"));
                }

            } catch (NullReferenceException e) {
                Console.WriteLine (e.Message);
            }
        }
        internal void UpdateSubCategory (ProductSubCategoryService subCategoryService) {
            string newName = "";
            
            Console.Write ("\n Category ID - ");
            
            try {
                id = int.Parse (Console.ReadLine ());
                Console.Write ("\n Old Sub Category Name - ");
                name = Console.ReadLine ();
                Console.Write ("\n New Sub Category Name - ");
                newName = Console.ReadLine ();
            } catch (FormatException e) {
                System.Console.WriteLine (e.Message);
            }

            try {
                subCategoryService.Update (id, name, newName);
            } catch (CategoryNotExistException e) {
                System.Console.WriteLine (e.Message);
            } catch (DuplicateCategoryException e) {
                Console.WriteLine (e.Message);
            }
        }
        internal void DeleteSubCategory (ProductSubCategoryService subCategoryService) {
            bool check = false;
            Console.Write ("\n   Category ID - ");
            
            try {
                id = int.Parse (Console.ReadLine ());
                Console.Write ("\n   Sub Category Name - ");
                name = Console.ReadLine ();
            } catch (FormatException e) {
                System.Console.WriteLine (e.Message);
            }

            try
            {
                check = subCategoryService.Delete(id, name);
            }catch(CategoryNotExistException e)
            {
                Console.WriteLine(e.Message);
            } 
            if (check) 
                System.Console.WriteLine ("Sub Category Deleted Successfully");

        }
    }
}