using System.Collections;
using System.Collections.Generic;

namespace Part2ProductSales
{
    internal class Program
    {

       static List<int> myList = new List<int>();

        static List<Product > products = new List<Product>();






        static void Main(string[] args)
        {
            products.Add(new Product("Eggs", 3.5m, 20));
            products.Add(new Product("Bread", 2.0m, 20));
            products.Add(new Product("Jam", 3.7m, 25));
            products.Add(new Product("Milk", 1.5m, 40));


            string[] menuChoices =
                 {"Process sale Transaction", "Restock Product", "Print report", "Quit"};

            Menu menu = new Menu(menuChoices);



            int choice = menu.GetMenuChoice();


            while (choice != 4)
            {
                ProcessChoice(choice);

                choice = menu.GetMenuChoice();
            }


        }


        static void ProcessChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                   ProcessingSalesTransaction();
                    break;
                case 2:
                    Console.WriteLine("Restocking Product...");
                    break;
                case 3:
                    Console.WriteLine("Printing Report...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }

        static void ProcessingSalesTransaction()
        {
            Console.WriteLine("Processing Sales Transaction");
            string[] productMenuItems = new string[products.Count];

            for (int i = 0; i < products.Count; i++)
            {
                productMenuItems[i] = products[i].ToString();
            }


            Menu productMenu = new Menu(productMenuItems);

            int choice = productMenu.GetMenuChoice();

            Console.WriteLine(choice);

        }

    }
}
