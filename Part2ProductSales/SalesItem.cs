using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2ProductSales
{
    internal class SalesItem
    {

        private int _quantity;

        private  Product _product;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set { _quantity = value; }
            
        }

        public  Product Product
        {
            get
            {
                return _product;
            }
           private set
            {
                _product = value;
            }
        }

        public SalesItem(Product p, int q) 
        { 
            Product = p;
            Quantity = q;

        }
    }
}
