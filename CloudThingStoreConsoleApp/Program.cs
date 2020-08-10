using System;
namespace CloudThingStoreConsoleApp {
    class Program {
        static void Main (string[] args) {
            int input = 0;
            ProductCategoryServiceFunctions function = new ProductCategoryServiceFunctions ();
            while (true) {
                Console.WriteLine ("\n1. Add a Category \n2. Print List of All Category \n3. Update Category by Id \n4. Search Category by Id or Name \n5. Delete Category by Id \n6. Add Sub Category \n7. Print All Categories and Sub Categories ");
                Console.Write ("Please Choose your Option - ");
                try {
                    input = int.Parse (Console.ReadLine ());
                } catch (Exception) {
                    Console.WriteLine ("Please give valid integer Input");
                    continue;
                }
                switch (input) {
                    case 1:
                        function.Add ();
                        break;
                    case 2:
                        function.Print ();
                        break;
                    case 3:
                        function.Update ();
                        break;
                    case 4:
                        function.Search ();
                        break;
                    case 5:
                        function.Delete ();
                        break;
                    case 6:
                        function.AddSubCategory ();
                        break;
                    case 7:
                        function.PrintAllCategories ();
                        break;
                    case 8:
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