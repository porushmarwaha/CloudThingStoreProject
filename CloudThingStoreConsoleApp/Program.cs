using System;
using CloudThingStore.Services;
namespace CloudThingStoreConsoleApp {
    class Program {
        static void Main (string[] args) {
            var categoryService = new ProductCategoryService();
            var subCategoryService = new SubCategoryService(categoryService);
            int input = 0;
            var function = new CategoryServiceFunctions ();
            var subFunction = new SubCategoryServiceFunctions();
            while (true) {
                Console.WriteLine ("\n1. Add a Category \n2. Print List of All Category \n3. Update Category by Id \n4. Search Category by Id or Name \n5. Delete Category by Id \n6. Add Sub Category \n7. Print All Categories and Sub Categories\n8. Update Sub Category\n9. Delete Sub Category\n0. Exit ");
                Console.Write ("Please Choose your Option - ");
                try {
                    input = int.Parse (Console.ReadLine ());
                } catch (Exception) {
                    Console.WriteLine ("Please give valid integer Input");
                    continue;
                }
                switch (input) {
                    case 1:
                        function.Add (categoryService);
                        break;
                    case 2:
                        function.Print (categoryService);
                        break;
                    case 3:
                        function.Update (categoryService);
                        break;
                    case 4:
                        function.Search (categoryService);
                        break;
                    case 5:
                        function.Delete (categoryService);
                        break;
                    case 6:
                        subFunction.AddSubCategory (subCategoryService);
                        break;
                    case 7:
                        subFunction.PrintAllCategories (categoryService);
                        break;
                     case 8:
                        subFunction.UpdateSubCategory(subCategoryService);
                        break;
                    case 9: subFunction.DeleteSubCategory(subCategoryService);
                        break;
                    case 0:
                        Environment.Exit (0);
                        break;
                    default:
                        Console.WriteLine ("Input not match from given List Options");
                        break;
                }
            }
        }
    }
}