using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2ProductSales
{
    internal class ShoppingBasket
    {


        public List<SalesItem> Contents { get; set; }

        public ShoppingBasket()
        {
            Contents = new List<SalesItem>();
        }

       

        public void AddToBasket (Product product, int quantity)
        {
            // check if the product is already in the basket
            
            SalesItem? existingItem = null;


            foreach (SalesItem item in Contents)
            {
                if (item.Product == product)
                {
                    existingItem = item;
                    break;
                }
            }

            if (existingItem != null)
            {
                // if the product is already in the basket, update the quantity
                existingItem.Quantity += quantity;
            }
            else
            {
                // if the product is not in the basket, add a new SalesItem to the list
               Contents.Add(new SalesItem(product, quantity));
            }
        }


        /// <summary>
        /// This just empties the basket by clearing the list of SalesItems. 
        public void Empty ()
        {
             Contents.Clear();
        }

        /// <summary>
        /// this method iterates through the list of SalesItems in the basket and calls the Restock method on
        /// each Product to return the items to stock. After restocking, 
        /// it clears the basket by calling the Clear method on the Contents list.
        /// </summary>
        public void Return()
        {
            foreach (SalesItem item in Contents)
            {
                item.Product.Restock(item.Quantity);
            }

            Contents.Clear();
        }

        public decimal TotalValue()
        {
            decimal total = 0;
            foreach (SalesItem item in Contents)
            {
                total += item.Quantity * item.Product.UnitPrice;
            }
            return total;
        }

        public override string ToString()
        {
           string message = "Your basket contains:\n";

            foreach (SalesItem item in Contents)
            {
                message += ($"{item.Quantity} x {item.Product.Name} @ {item.Product.UnitPrice:C} each \n");
            }
            return message;
        }


    }
}
