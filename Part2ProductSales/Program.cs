using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Part2ProductSales
{
    internal class Program
    {


        static List<int> myList = new List<int>();

        static List<Product> products = new List<Product>();






        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
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
                    RestockProduct();
                    break;
                case 3:
                    Console.WriteLine("Printing Report...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }


        /// <summary>
        /// For now this only allows one sale.
        /// The question asks for multiple sales to be allowed
        /// This requires more data to be kept,
        /// another class to hold data about a shopping cart
        /// might be useful
        /// </summary>
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

            Product chosenProduct = products[choice - 1];

            Console.WriteLine($"How much {chosenProduct.Name} do you want?");

            // This is not robust, but it is just a demo
            // In a real application, you would want to add error handling here

            int quantity = int.Parse(Console.ReadLine()!);

            bool enoughProduct = chosenProduct.Sell(quantity);

            if (!enoughProduct)
            {
                Console.WriteLine("Sorry not enough in stock");
            }
            else
            {
                Console.WriteLine($"You bought {quantity} {chosenProduct.Name} for {quantity * chosenProduct.UnitPrice:C}");
            }

        }


        static void RestockProduct()
        {
            Console.WriteLine("Restocking Product");
            string[] productMenuItems = new string[products.Count];
            for (int i = 0; i < products.Count; i++)
            {
                productMenuItems[i] = products[i].ToString();
            }

            Console.WriteLine("Which product do you want to restock?");

            Menu productMenu = new Menu(productMenuItems);


            /// this is not roubut, but it is just a demo
            int choice = productMenu.GetMenuChoice();

            Product chosenProduct = products[choice - 1];

            Console.WriteLine("How much do you want to restock?");

            int quantity = int.Parse(Console.ReadLine()!);

            chosenProduct.Restock(quantity);
        }
    }
}
