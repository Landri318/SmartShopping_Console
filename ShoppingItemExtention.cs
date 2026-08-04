using System;

namespace SmartShoppingCart_Ice1
{
    internal static class ShoppingItemExtension
    {
        public static string GetShoppingCategory(this ShoppingItem item)
        {
            decimal totalCost = item.Price * item.Quantity;

            if (totalCost < 100)
            {
                return "Budget Purchase";
            }
            else if (totalCost <= 500)
            {
                return "Standard Purchase";
            }
            else
            {
                return "Premium Purchase";
            }
        }
    }
}