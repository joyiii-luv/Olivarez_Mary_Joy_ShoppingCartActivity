
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
                new Product { Id = 1, Name = "Notebook", Price = 75, Remaining_Stock = 100 },
                new Product { Id = 2, Name = "Pencil", Price = 12, Remaining_Stock = 100 },
                new Product { Id = 3, Name = "Bag", Price = 350, Remaining_Stock = 100 },
                new Product { Id = 4, Name = "Eraser", Price = 10, Remaining_Stock = 100 },
                new Product { Id = 5, Name = "Ballpen", Price = 18, Remaining_Stock = 100 },
                new Product { Id = 6, Name = "Stickers", Price = 20, Remaining_Stock = 100 },
            };

        int cartLimit = 5;
        List<CartItem> cart = new List<CartItem>();

        while (true)
        {
            Console.WriteLine("\n ===Menu System===");
            foreach (var p in products)
            {
                string stockDisplay = "";
                if (p.Remaining_Stock == 0) stockDisplay = "*** OUT OF STOCK ***";
                else if (p.Remaining_Stock <= 10) stockDisplay = $"Stock: {p.Remaining_Stock} <<< LOW STOCK";
                else stockDisplay = $"Stock: {p.Remaining_Stock}";

                Console.WriteLine($"ID: {p.Id} | {p.Name,-10} | Price: {p.Price} | {stockDisplay}");
            }

            Console.WriteLine("============================");

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
                        Console.WriteLine("\n======= RECEIPT =======");
                        Console.WriteLine($" {"ITEM",-15} x{"QUANTITY",5} {"PRICE",8} {"SUBTOTAL",10}");

                        foreach (var item in cart)
                            Console.WriteLine($" {item.Name,-15} {item.Quantity,5} {item.Price,8} {item.Subtotal,10}");

                        if (discount > 0) Console.WriteLine($"Discount: -{discount}");
                        Console.WriteLine($"Total Paid: {pay}");
                        Console.WriteLine($"Change: {pay - grandTotal}");
                        Console.WriteLine("===== Thank You! Come Again! <3=====\n");
                        cart.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient amount. Back to Menu.");
                        continue;
                    }
                }
            }
        }
    }
}







