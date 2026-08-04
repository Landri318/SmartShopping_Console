using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SmartShoppingCart_Ice1
{
    internal class ShoppingItem
    {

        //name
        public string ProductName { get; set; }
        //category
        public string Category { get; set; }
        //price
        public decimal Price { get; set; }
        //quantity
        public int Quantity { get; set; }

        //default constructor
        public ShoppingItem()
        {
        }

        //overloaded constructor
        public ShoppingItem(string productName, string category, decimal price, int quantity)
        {
            ProductName = productName;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        //overloaded operator +
        public static ShoppingItem operator +(ShoppingItem item1, ShoppingItem item2)
        {
            if (item1.Category != item2.Category)
                throw new InvalidOperationException("Items must be in the same category.");

            return new ShoppingItem(
                item1.ProductName + " & " + item2.ProductName,
                item1.Category,
                item1.Price + item2.Price,
                item1.Quantity + item2.Quantity
            );
        }

        //overloaded operator -
        public static ShoppingItem operator -(ShoppingItem item1, ShoppingItem item2)
        {
            return new ShoppingItem(
                item1.ProductName + " & " + item2.ProductName,
                item1.Category + " & " + item2.Category,
                item1.Price - item2.Price,
                item1.Quantity - item2.Quantity
            );
        }


    }
}
