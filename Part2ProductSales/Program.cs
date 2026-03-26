namespace Part2ProductSales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menuChoices =
                 {"Process sale Transaction", "Restock Product", "Print report", "Quit"};

            Menu menu = new Menu(menuChoices);



            int choice = menu.GetMenuChoice();


            while (choice != 4)
            {

                Console.WriteLine($"Choice was {choice}");
                choice = menu.GetMenuChoice();
            }
            

        }
    }
}
