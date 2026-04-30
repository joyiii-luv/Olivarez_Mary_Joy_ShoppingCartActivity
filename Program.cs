
using Olivarez_Mary_Joy_ShoppingCartActivity;

using System;

class Program
{
    static void Main(string[] args)
    {
        //To add Peso Sign*
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        Product[] product = new Product[8];
        {
            product[0] = new Product { Id = 1, Name = "Strawberry Banana", Price = 135, RemainingStock = 100 };
            product[1] = new Product { Id = 2, Name = "Mango Smoothie", Price = 150, RemainingStock = 100 };
            product[2] = new Product { Id = 3, Name = "Fruity Pandan", Price = 143, RemainingStock = 100 };
            product[3] = new Product { Id = 4, Name = "Mango Pineapple", Price = 150, RemainingStock = 100 };
            product[4] = new Product { Id = 5, Name = "Creamy Avocado Banana", Price = 125, RemainingStock = 100 };
            product[5] = new Product { Id = 6, Name = "Four seasons", Price = 149, RemainingStock = 100 };
            product[6] = new Product { Id = 7, Name = "Strawberry Kiwi", Price = 130, RemainingStock = 100 };
            product[7] = new Product { Id = 8, Name = "Sweet Melon", Price = 130, RemainingStock = 100 };
        }

        int cartLimit = 5;
        CartItem[] cart = new CartItem[cartLimit];
        int cartCount = 0;

        while (true)
        {
            Console.WriteLine("\n ============= Jolly Fruit Shake ===============");
            Console.WriteLine("IDs 1-8. Buy | 9. Cart Management | 0. Checkout");
            Console.WriteLine("10. Search   | 11. Category Filter | 12. History");
            Console.WriteLine("==========================================");

            foreach (var p in product) if (p != null) p.DisplayProduct();

            Console.Write("\nEnter Choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0) // Checkout Validation
                {
                    if (cartCount == 0) { Console.WriteLine("Cart is Empty, try again!"); continue; }

                    double originalTotal = 0;
                    for (int i = 0; i < cartCount; i++) originalTotal += cart[i].Subtotal;
                    double discountAmount = originalTotal >= 5000 ? 0.10 * originalTotal : 0;
                    double finalTotal = originalTotal - discountAmount;

                    Console.WriteLine($"GRAND TOTAL: {finalTotal:N2}");

                    double pay = 0;
                    //Payment Validation Loop

                    while (true)
                    {
                        Console.Write("Enter Payment: ");
                        if (double.TryParse(Console.ReadLine(), out pay))
                        {
                            if (pay >= finalTotal) break;
                            else Console.WriteLine($"Insufficient amount! You need ₱{finalTotal - pay:N2} more.");
                        }
                        else Console.WriteLine("Invalid input, please enter a valid number for payment.");
                    }
                    // Receipt Generation
                    Console.WriteLine("\n============= RECEIPT =============");
                    Console.WriteLine($"Receipt No: ");
                    Console.WriteLine($"Date: ");
                    Console.WriteLine("-----------------------------------");
                    for (int i = 0; i < cartCount; i++)
                        Console.WriteLine($"{cart[i].Name,-20} {cart[i].Quantity,5} ₱{cart[i].Subtotal,10:N2}");

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"Original Total: {originalTotal,10:N2}");
                    Console.WriteLine($"Discount:       -{discountAmount,10:N2}");
                    Console.WriteLine($"Grand Total:    {finalTotal,10:N2}");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"Amount Paid:     {pay,10:N2}");
                    Console.WriteLine($"Change:          {pay - finalTotal,10:N2}");
                    Console.WriteLine("\n===Thank You for choosing JFS! Stay Fruitful! ===\n");

                   

                    // FEATURE 4: Stock Reorder Alert (Check RemainingStock <= 5)
                    Console.WriteLine("---LOW STOCK ALERT---");
                    foreach (var p in product)
                        if (p.RemainingStock <= 5) Console.WriteLine($"ALERT: {p.Name} has only {p.RemainingStock} left! Sorry :(");

                    string cont;
                    while (true)
                    {
                        Console.WriteLine("Continue to Order? : Y/N");
                        cont = Console.ReadLine()?.ToUpper() ?? "";
                        if (cont == "Y" || cont == "N") break;
                        else Console.WriteLine("Invalid input, please enter Y for Yes or N for No.");
                    }

                    if (cont == "N") break;

                    Array.Clear(cart, 0, cart.Length);
                    cartCount = 0;

                }
                else if (choice == 10) // Search by Name
                {
                    Console.WriteLine("Enter product name to search: ");
                    string key = Console.ReadLine()?.ToLower() ?? "";
                    foreach (var p in product) if (p.Name.ToLower().Contains(key)) p.DisplayProduct();
                }
                else if (choice == 11) // Product Category 
                {
                    Console.WriteLine("1. Smoothie | 2. Specialty | 3. Juice");
                    string catg = Console.ReadLine() == "1" ? "Smoothie" : (Console.ReadLine() == "2" ? "Specialty" : "Juice");
                    foreach (var p in product) if (p.Category == catg) p.DisplayProduct();
                }
                else // Buy  
                {
                    Product sel = Array.Find(product, p => p != null && p.Id == choice);
                    if (sel != null && sel.RemainingStock > 0 )
                    {
                        Console.Write($"Enter quantity for {sel.Name}: ");
                        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                        {
                            if (sel.HasEnoughStock(quantity))
                            {   
                                CartItem? exist = Array.Find(cart, c => c != null && c.Name == sel.Name);
                                if (exist != null)
                                {
                                    exist.Quantity += quantity;
                                    exist.Subtotal = sel.GetItemTotal(exist.Quantity);
                                }
                                else if (cartCount < cartLimit)
                                {
                                    cart[cartCount] = new CartItem
                                    {
                                        Name = sel.Name,
                                        Price = (int)sel.Price,
                                        Quantity = quantity,
                                        Subtotal = sel.GetItemTotal(quantity)
                                    };
                                    cartCount++;
                                    sel.DeductStock(quantity);
                                    Console.WriteLine("Added to cart.");
                                }
                                else Console.WriteLine("Cart Full!");
                                sel.DeductStock(quantity);
                            }
                            else Console.WriteLine("Not enough stock available.");
                        }
                        else Console.WriteLine("Invalid Input, please enter a number for quantity.");
                    }
                }

            }
        }
    }
}