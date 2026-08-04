using System;

namespace SmartShoppingCart_Ice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store shopping items
            List<ShoppingItem> shoppingCart = new List<ShoppingItem>();

            //category choice
            List<string> categories = new List<string>
                {
                    "Food",
                    "Clothing",
                    "Electronics",
                    "Furniture",
                    "Books"
                };
            while (true)
            {
                //name
                Console.Write("\nEnter product name (or Q to quit): ");
                string productName = Console.ReadLine();

                if (productName.ToUpper() == "Q")
                    break;



                //category
                
                Console.Write("Categories: \n Food \n Clothing \n Electronics \n Furniture \n Books");
                Console.Write("Enter category: ");
                string category = Console.ReadLine();

                while (!categories.Contains(category))
                {
                    Console.WriteLine("Invalid category.");
                    Console.Write("Enter Food, Clothing, Electronics, Furniture, or Books: ");
                    category = Console.ReadLine();
                }


                //price
                Console.Write("Enter price (or Q to quit): ");
                string priceInput = Console.ReadLine();

                if (priceInput.ToUpper() == "Q")
                    break;

                if (!double.TryParse(priceInput, out double price))
                {
                    Console.WriteLine("Invalid price. Please enter a valid number.");
                    continue;
                }


                //quantity
                Console.Write("Enter quantity (or Q to quit): ");
                string quantityInput = Console.ReadLine();

                if (quantityInput.ToUpper() == "Q")
                    break;

                if (!int.TryParse(quantityInput, out int quantity))
                {
                    Console.WriteLine("Invalid quantity. Please enter a whole number.");
                    continue;
                }

                // Create object
                ShoppingItem item = new ShoppingItem(
                    productName,
                    category,
                    (decimal)price,
                    quantity
                );
                // Add object to the list
                shoppingCart.Add(item);
            }

            // Garbage Collection
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("\nGarbage Collection has been requested.");


            Console.WriteLine("\nShopping Cart:");

            foreach (ShoppingItem item in shoppingCart)
            {
                Console.WriteLine($"{item.ProductName} | " +
                    $"{item.Category} | " +
                    $"R{item.Price} | " +
                    $"Qty: {item.Quantity} | " +
                    $" {item.GetShoppingCategory()}");
            }

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Display products costing more than R100");
                Console.WriteLine("2. Display products in alphabetical order");
                Console.WriteLine("3. Display Electronics products");
                Console.WriteLine("4. Calculate total amount spent");
                Console.WriteLine("5. Display the most expensive product");
                Console.WriteLine("6. Group products by category");
                Console.WriteLine("7. Exit");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var expensiveProducts = shoppingCart.Where(item => item.Price > 100);

                        foreach (var item in expensiveProducts)
                        {
                            Console.WriteLine($"{item.ProductName} - R{item.Price}");
                        }
                        break;

                    case 2:
                        var alphabetical = shoppingCart.OrderBy(item => item.ProductName);

                        foreach (var item in alphabetical)
                        {
                            Console.WriteLine($"{item.ProductName} - R{item.Price}");
                        }
                        break;

                    case 3:
                        var electronics = shoppingCart.Where(item => item.Category == "Electronics");

                        foreach (var item in electronics)
                        {
                            Console.WriteLine($"{item.ProductName} - R{item.Price}");
                        }
                        break;

                    case 4:
                        decimal totalSpent = shoppingCart.Sum(item => item.Price * item.Quantity);

                        Console.WriteLine($"Total spent: R{totalSpent}");
                        break;

                    case 5:
                        var mostExpensive = shoppingCart.OrderByDescending(item => item.Price).FirstOrDefault();

                        if (mostExpensive != null)
                        {
                            Console.WriteLine($"{mostExpensive.ProductName} - R{mostExpensive.Price}");
                        }
                        break;

                    case 6:
                        var groupedProducts = shoppingCart.GroupBy(item => item.Category);

                        foreach (var group in groupedProducts)
                        {
                            Console.WriteLine($"\nCategory: {group.Key}");

                            foreach (var item in group)
                            {
                                Console.WriteLine($"{item.ProductName} - R{item.Price}");
                            }
                        }
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            
        }
    }
}