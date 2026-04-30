
using Olivarez_Mary_Joy_ShoppingCartActivity;

using System;
using System.ComponentModel.Design;

class Program
{
    static string[] orderHistory = new string[100];
    static int historyCount = 0;
    static int receiptCounter = 1;
    static void Main(string[] args )
    {
        //To add Peso Sign*
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        Product[] product = new Product[8];
        {
            product[0] = new Product { Id = 1, Name = "Creamy Avocado", Price = 265, RemainingStock = 100, Category = "Specialty" };
            product[1] = new Product { Id = 2, Name = "Fruity Pandan", Price = 289, RemainingStock = 100, Category = "Specialty" };
            product[2] = new Product { Id = 3, Name = "Strawberry Banana", Price = 240, RemainingStock = 100, Category = "Specialty" };
            product[3] = new Product { Id = 4, Name = "Mango Smoothie", Price = 175, RemainingStock = 100, Category = "Smoothie" };
            product[4] = new Product { Id = 5, Name = "Mango Pineapple", Price = 160, RemainingStock = 100, Category = "Smoothie" };
            product[5] = new Product { Id = 6, Name = "Four seasons", Price = 100, RemainingStock = 100, Category = "Juice" };
            product[6] = new Product { Id = 7, Name = "Strawberry Kiwi", Price = 120, RemainingStock = 100, Category = "Juice" };
            product[7] = new Product { Id = 8, Name = "Sweet Melon", Price = 130, RemainingStock = 100, Category = "Juice" };
        }

        int cartLimit = 5;
        CartItem[] cart = new CartItem[cartLimit];
        int cartCount = 0;

        while (true)
        {
            Console.WriteLine("\n ======================= Jolly Fruit Shake ============================");
            Console.WriteLine("IDs 1-8. Buy | 9. Cart Management | 0. Checkout");
            Console.WriteLine("10. Search   | 11. Category Filter | 12. History");
            Console.WriteLine("_______________________________________________________________________");

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

                    while (true) //Payment Validation Loop
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
                    string receiptNo = receiptCounter.ToString("D4");
                    string timestamp = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");


                    Console.WriteLine("\n============== RECEIPT ================");
                    Console.WriteLine($"Receipt No: {receiptNo}");
                    Console.WriteLine($"Date: {timestamp}");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"{"ITEM",-20} {"QTY",5} {"SUBTOTAL",10}");
                    for (int i = 0; i < cartCount; i++)
                        Console.WriteLine($"{cart[i].Name,-20} {cart[i].Quantity,5} ₱{cart[i].Subtotal,10:N2}");

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Grand Total:   ₱ {originalTotal,10:N2}");
                    Console.WriteLine($"Discount:       - ₱{discountAmount,10:N2}");
                    Console.WriteLine($"Final Total:    ₱ {finalTotal,10:N2}");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"Amount Paid:     ₱ {pay,10:N2}");
                    Console.WriteLine($"Change:          ₱ {pay - finalTotal,10:N2}");
                    Console.WriteLine("\n=== Thank You! Come Again! ===");

                    // Order History - Array

                    if (historyCount < orderHistory.Length)
                    {
                        orderHistory[historyCount++] = $"Receipt #{receiptNo} - Final Total: ₱{finalTotal:N2} - {timestamp}";
                    }
                    receiptCounter++;

                    // Stock Reorder Alert 
                    bool hasLowStock = false;

                    foreach (var p in product)
                    {
                        if (p != null && p.RemainingStock <= 5)
                        {
                            if (!hasLowStock)
                            {
                                Console.WriteLine("\n--- LOW STOCK ALERT ---");
                                hasLowStock = true;
                            }
                            Console.WriteLine($"ALERT: {p.Name} has only {p.RemainingStock} left! Sorry :(");
                        }
                    }

                    // Y/N Validation Loop
                    string cont;
                    while (true)
                    {
                        Console.WriteLine("Continue to Order? : Y/N");
                        cont = Console.ReadLine()?.ToUpper() ?? "";
                        if (cont == "Y" || cont == "N") break;
                        else Console.WriteLine("Invalid input. Please enter Y or N only.");
                    }

                    if (cont == "N") break;

                    Array.Clear(cart, 0, cart.Length);
                    cartCount = 0;
                }
                else if (choice == 9) // Cart Management
                {
                    ManageCart(ref cart, ref cartCount, product);
                }
                else if (choice == 10) // Search by Name
                {
                    Console.WriteLine("Enter product name to search: ");
                    string key = Console.ReadLine()?.ToLower() ?? "";

                    bool found = false;

                    foreach (var p in product)
                    {
                        if (p != null && p.Name.ToLower().Contains(key))
                        {
                            p.DisplayProduct();
                            found = true; // 2. Mark as true if a match exists
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($" '{key}' is not found.");
                    }
                }
                else if (choice == 11) // Product Category 
                {
                    Console.WriteLine("1. Smoothie | 2. Specialty | 3. Juice");
                    Console.Write("Choice: "); 
                    string input = Console.ReadLine();

                   
                    string catg = input == "1" ? "Smoothie" : (input == "2" ? "Specialty" : (input == "3" ? "Juice" : ""));

                    if (catg != "")
                    {
                        Console.WriteLine($"\n--- {catg} Menu ---");

                        foreach (var p in product)
                        {
                            if (p != null && p.Category == catg)
                            {
                                p.DisplayProduct();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid category selection.");
                    }
                }
                else if (choice == 12) // Order History
                {
                    Console.WriteLine("\n--- Order History ---");
                    if (historyCount == 0) Console.WriteLine("No orders yet.");
                    else
                    {
                        for (int i = 0; i < historyCount; i++) Console.WriteLine(orderHistory[i]);
                    }
                }
                else if (choice >= 1 && choice <= 8) // Buy Logic
                {
                    Product sel = Array.Find(product, p => p != null && p.Id == choice);
                    if (sel != null)
                    {
                        Console.Write($"Enter quantity for {sel.Name}: ");
                        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                        {
                            if (sel.HasEnoughStock(quantity))
                            {
                                CartItem exist = Array.Find(cart, c => c != null && c.Name == sel.Name);
                                if (exist != null)
                                {
                                    exist.Quantity += quantity;
                                    exist.Subtotal = sel.GetItemTotal(exist.Quantity);
                                    sel.DeductStock(quantity);
                                    Console.WriteLine("Added more to existing item.");
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
                                else
                                {
                                    Console.WriteLine("Cart is full (Limit: 5 types of items).");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Insufficient stock! Only {sel.RemainingStock} left.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please enter a number corresponding to the options.");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice, please select a valid option.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number corresponding to the options.");
            }
        }
    }

    static void ManageCart (ref CartItem[] cart, ref int count, Product[] products) // separate method for organization and readability
    {
        if (count == 0) { Console.WriteLine("Cart is Empty, try again!"); return; }
        while (true)
        {
            Console.WriteLine("\n--- Manage Cart ---");
            for (int i = 0; i < count; i++) Console.WriteLine($"[{i + 1}] {cart[i].Name} x {cart[i].Quantity}");
            Console.WriteLine("1. View Cart | 2. Remove | 3. Update Quantity | 4. Clear Cart | 5. Back");
            Console.Write("Choice: ");
            string op = Console.ReadLine();

            if (op == "1") // View Cart
            {
                Console.WriteLine("\n---Your Cart---");
                for (int i = 0; i < count; i++)
                    Console.WriteLine($"{cart[i].Name} x {cart[i].Quantity} = ₱{cart[i].Subtotal:N2}");
            }
            else if (op == "2") // Remove Item
            {
                Console.Write("Enter item number to remove: ");
                if (int.TryParse(Console.ReadLine(), out int rem) && rem > 0 && rem <= count)
                {
                    string itemToRemoveName = cart[rem - 1].Name;
                    int qtyToReturn = cart[rem - 1].Quantity;

                    Product p = Array.Find(products, prod => prod.Name == itemToRemoveName);

                    if (p != null)
                    {
                        p.RemainingStock += qtyToReturn;
                    }

                    for (int i = rem - 1; i < count - 1; i++)
                    {
                        cart[i] = cart[i + 1];
                    }

                    cart[--count] = null;
                    Console.WriteLine("Item removed.");
                }
                else Console.WriteLine("Invalid input.");
            }
            else if (op == "3") // Update Quantity
            {
                Console.Write("Enter item number to update: ");
                if (int.TryParse(Console.ReadLine(), out int upd) && upd > 0 && upd <= count)
                {
                    CartItem item = cart[upd - 1];
                    Product prod = Array.Find(products, p => p.Name == item.Name);
                    if (prod != null)
                    {
                        Console.Write($"Enter new quantity for {item.Name}: ");
                        if (int.TryParse(Console.ReadLine(), out int newQty) && newQty >= 0)
                        {
                            int diff = newQty - item.Quantity;
                            if (diff == 0) continue;
                            else if (diff > 0 && prod.HasEnoughStock(diff))
                            {
                                item.Quantity = newQty;
                                item.Subtotal = prod.GetItemTotal(newQty);
                                prod.DeductStock(diff);
                                Console.WriteLine("Quantity updated.");
                            }
                            else if (diff < 0)
                            {
                                item.Quantity = newQty;
                                item.Subtotal = prod.GetItemTotal(newQty);
                                prod.RemainingStock += (-diff);
                                Console.WriteLine("Quantity updated.");
                            }
                            else Console.WriteLine("Not enough stock available.");
                        }
                        else Console.WriteLine("Invalid input for quantity.");
                    }
                }
                else Console.WriteLine("Invalid input, try again");
            }
            else if (op == "4")
            {
                for (int i = 0; i < count; i++)
                {
                    string currentItemName = cart[i].Name;
                    int currentItemQty = cart[i].Quantity;

                    var p = Array.Find(products, prod => prod.Name == currentItemName);
                    if (p != null)
                    {
                        p.RemainingStock += currentItemQty;
                    }
                }
                Array.Clear(cart, 0, cart.Length);
                count = 0;
                Console.WriteLine("Cart cleared.");
                break;
            }
            else if (op == "5") //Back to Main Menu
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please select a valid option.");
            }
        }
    }
}