
using Olivarez_Mary_Joy_ShoppingCartActivity;

internal class CartItem
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Quantity { get; set; }
    public double Subtotal { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Strawberry Banana", Price = 35, Remaining_Stock = 100 },
                new Product { Id = 2, Name = "Mango Smoothie", Price = 45, Remaining_Stock = 100 },
                new Product { Id = 3, Name = "Fruity Pandan", Price = 50, Remaining_Stock = 100 },
                new Product { Id = 4, Name = "Mango Pineapple", Price = 50, Remaining_Stock = 100 },
                new Product { Id = 5, Name = "Creamy Avocado Banana", Price = 45, Remaining_Stock = 100 },
                new Product { Id = 6, Name = "Four seasons", Price = 39, Remaining_Stock = 100 },
            };

        int cartLimit = 5;
        List<CartItem> cart = new List<CartItem>();

        while (true)
        {
            Console.WriteLine("\n ============= Jolly Fruit Shake ===============");
            foreach (var p in products)
            {
                string stockDisplay = "";
                if (p.Remaining_Stock == 0) stockDisplay = "*** OUT OF STOCK ***";
                else if (p.Remaining_Stock <= 10) stockDisplay = $"Stock: {p.Remaining_Stock} <<< LOW STOCK";
                else stockDisplay = $"Stock: {p.Remaining_Stock}";

                Console.WriteLine($"ID: {p.Id} | {p.Name,-10} | Price: {p.Price} | {stockDisplay}");
            }

            Console.WriteLine("==========================================");

            if (cart.Count > 0)
            {
                Console.WriteLine($"\n--- Cart: {cart.Count}/{cartLimit} slots used---");
            }
            Console.WriteLine("\nEnter ID to buy | Checkout (0) | Edit Cart (9)");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    if (cart.Count == 0) { Console.WriteLine("Cart is Empty, try again!"); continue; }

                    double total = cart.Sum(item => item.Subtotal);
                    double discount = total > 5000 ? total * 0.10 : 0;
                    double grandTotal = total - discount;

                    Console.WriteLine($"\nGrand Total: {grandTotal}");
                    Console.WriteLine("Enter Payment: ");
                    if (double.TryParse(Console.ReadLine(), out double pay) && pay >= grandTotal)
                    {
                        Console.WriteLine("\n============= RECEIPT =============");
                        Console.WriteLine($" {"ITEM",-15} x{"QUANTITY",5} {"PRICE",8} {"SUBTOTAL",10}");

                        foreach (var item in cart)
                            Console.WriteLine($" {item.Name,-15} {item.Quantity,5} {item.Price,8} {item.Subtotal,10}");

                        if (discount > 0) Console.WriteLine($"Discount: -{discount}");
                        Console.WriteLine($"Total Paid: {pay}");
                        Console.WriteLine($"Change: {pay - grandTotal}");
                        Console.WriteLine("=============Thank You for choosing Jolly Fruit Shake! Stay ruitful! <3 ============= \n");
                        cart.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient amount. Back to Menu.");
                        continue;
                    }
                }
                else if (choice == 9)
                {
                    if (cart.Count == 0) { Console.WriteLine("Cart is Empty :("); continue; }
                    for (int i = 0; i < cart.Count; i++)
                        Console.WriteLine($"[{i + 1}] {cart[i].Name} (Quantity: {cart[i].Quantity})");

                    Console.Write("Select item number to remove");
                    if (int.TryParse(Console.ReadLine(), out int removeIdx) && removeIdx > 0 && removeIdx <= cart.Count)
                    {
                        var itemToRemove = cart[removeIdx - 1];
                        var prod = products.Find(p => p.Name == itemToRemove.Name);
                        prod.Remaining_Stock += itemToRemove.Quantity;
                        cart.RemoveAt(removeIdx - 1);
                        Console.WriteLine("Item successfully removed");
                    }
                    continue;
                }
                Product selected = products.Find(p => p.Id == choice);
                if (selected != null)
                {
                    if (selected.Remaining_Stock == 0) { Console.WriteLine("Out of stock!"); continue; }

                    var existingItem = cart.Find(c => c.Name == selected.Name);
                    if (existingItem == null && cart.Count >= cartLimit)
                    {
                        Console.WriteLine("Cart Full!");
                        continue;
                    }

                    Console.WriteLine($"Enter quantity for {selected.Name}: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0 && quantity <= selected.Remaining_Stock)
                    {
                        if (existingItem != null)
                        {
                            existingItem.Quantity += quantity;
                            existingItem.Subtotal = existingItem.Quantity * existingItem.Price;
                        }
                        else
                        {
                            cart.Add(new CartItem { Name = selected.Name, Price = selected.Price, Quantity = quantity, Subtotal = quantity * selected.Price });
                        }
                        selected.Remaining_Stock -= quantity;
                        Console.WriteLine("Added to cart!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity or not enough stock!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input! Please enter a number.");
                return;
            }
        }
    }
}







