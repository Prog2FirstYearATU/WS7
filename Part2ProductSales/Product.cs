using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2ProductSales
{
    internal class Product
    {

        // private attributes

        private int _stockLevel;


        // properties - note that the StockLevel property has a private setter, so it can only
        // be modified within the Product class
        public int StockLevel
        {
            get
            {
                return _stockLevel;
            }
            private set
            {
                _stockLevel = value;
            }
        }
        public decimal UnitPrice { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// The Constructor initializes the Name and UnitPrice properties, and sets the initial StockLevel to 0 when a new Product is created.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Product(string name, decimal price)
        {
            Name = name;
            UnitPrice = price;
            StockLevel = 0; // initialize stock level to 0 when a new product is created
        }

        public Product(string name, decimal price, int initalQuantity)
        {
            Name = name;
            UnitPrice = price;
            StockLevel = initalQuantity;
        }

        /// <summary>
        /// Restock method takes an integer quantity as a parameter and increases the StockLevel by that quantity. It returns true if the restock operation is successful, and false if the quantity is negative (indicating an invalid restock operation).
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool Restock(int quantity)
        {
            if (quantity < 0)
            {
                return false;
            }
            StockLevel += quantity; // increase stock level by the specified quantity
            return true;
        }


        /// <summary>
        /// Sell method takes an integer quantity as a parameter and decreases the StockLevel by that quantity. It returns true if the sell operation is successful, and false if the quantity is negative (indicating an invalid sell operation).
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool Sell(int quantity)
        {
            if (quantity < 0 || quantity > StockLevel)
            {
                return false;
            }
            StockLevel -= quantity; // decrease stock level by the specified quantity
            return true;
        }


        public override string ToString()
        {
            return $"{Name} - Price: {UnitPrice:C}";
        }
    }

   
}
