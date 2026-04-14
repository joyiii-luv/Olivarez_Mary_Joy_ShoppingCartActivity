
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

            





