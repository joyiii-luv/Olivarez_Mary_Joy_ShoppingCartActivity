using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Transactions;

namespace Olivarez_Mary_Joy_ShoppingCartActivity
{
    internal class Product
    {
        //hii

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Remaining_Stock { get; set; }

        static void Main(string[] args)
        {
            Product product1 = new Product();
            product1.Id = 1;
            product1.Name = "Notebook";
            product1.Price = 75;
            product1.Remaining_Stock = 100;

            Product product2 = new Product();
            {
                product2.Id = 2;
                product2.Name = "Pencil";
                product2.Price = 12;
                product2.Remaining_Stock = 67;
            }
            ;

            Product product3 = new Product();
            {
                product3.Id = 3;
                product3.Name = "Bag";
                product3.Price = 350;
                product3.Remaining_Stock = 20;
            };

            while (true)
            {
                Console.WriteLine("\n ===Menu System===");
                Console.WriteLine($"ID: {product1.Id} | Name: {product1.Name} | Price: {product1.Price} | Remaining Stock: {product1.Remaining_Stock}");
                Console.WriteLine($"ID: {product2.Id} | Name: {product2.Name} | Price: {product2.Price} | Remaining Stock: {product2.Remaining_Stock}");
                Console.WriteLine($"ID: {product3.Id} | Name: {product3.Name} | Price: {product3.Price} | Remaining Stock: {product3.Remaining_Stock}");

                int number;
                Console.WriteLine("Enter product number: | Type 0 to finish");
                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                double total = 0;
                int quantity1 = 0;
                int quantity2 = 0;
                int quantity3 = 0; 
                double change = 0;

                if (number == 1)
                {
                    Console.WriteLine($"Adding to Cart Item: {product1.Name} Continue (1) | Type 0 to back");
                    int cart = Convert.ToInt32(Console.ReadLine());

                    if (cart == 1)
                    {
                        Console.WriteLine("\n ===Your cart ===");
                        Console.WriteLine($"ID: {product1.Id} | Name: {product1.Name} | Price: {product1.Price}");

                        Console.WriteLine("Enter quantity: ");
                        quantity1 = Convert.ToInt32(Console.ReadLine());
                        total = product1.Price * quantity1;

                        Console.WriteLine($"Total Price: {total}");
                        Console.WriteLine("Proceed to pay?: Continue (1) | Type 0 to back");
                        int pay = Convert.ToInt32(Console.ReadLine());

                        if (pay == 1)
                        {
                            Console.WriteLine("Enter amount to Pay: ");
                            double amount = Convert.ToDouble(Console.ReadLine());

                            if (amount >= product1.Price)
                            {
                                change = amount - total;
                                Console.WriteLine($"Payment Successful! Change: {change}");

                            }
                            else
                            {
                                Console.WriteLine("Insufficient amount, Try again: ");
                                continue;
                            }
                        }
                        else if (pay == 0)
                        {
                            continue;
                        }
                    }
                    else if (cart == 0)
                    {
                        continue;
                    }
                }
                else if (number == 2)
                {
                    Console.WriteLine($"Adding to Cart Item: {product2.Name} Continue (1) | Type 0 to back");
                    int cart = Convert.ToInt32(Console.ReadLine());

                    if (cart == 1)
                    {
                        Console.WriteLine("\n ===Your cart ===");
                        Console.WriteLine($"ID: {product2.Id}| Name: {product2.Name} | Price: {product2.Price}");

                        Console.WriteLine("Enter quantity: ");
                        quantity2 = Convert.ToInt32(Console.ReadLine());
                        total = product2.Price * quantity2;

                        Console.WriteLine($"Total Price: {total}");
                        Console.WriteLine("Proceed to pay?: Continue (1) | Type 0 to back");
                        int pay = Convert.ToInt32(Console.ReadLine());

                        if (pay == 1)
                        {
                            Console.WriteLine("Enter amount to Pay: ");
                            double amount = Convert.ToDouble(Console.ReadLine());

                            if (amount >= total)
                            {
                                change = amount - total;
                                Console.WriteLine($"Payment Successful! Change: {change}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient amount, Try again: ");
                                continue;
                            }
                        }
                        else if (pay == 0)
                        {
                            continue;
                        }
                    else if (cart == 0)
                        {
                            continue;
                        }
                    
                }
                else if (number == 3)
                {
                    Console.WriteLine($"Adding to Cart Item: {product3.Name} Continue (1) | Type 0 to back");
                    int cart = Convert.ToInt32(Console.ReadLine());

                    if (cart == 1)
                    {
                        Console.WriteLine("\n ===Your cart ===");
                        Console.WriteLine($"ID: {product3.Id}| Name: {product3.Name} | Price: {product3.Price}");

                        Console.WriteLine("Enter quantity: ");
                        quantity3 = Convert.ToInt32(Console.ReadLine());
                        total = product3.Price * quantity3;

                        Console.WriteLine($"Total Price: {total}");
                        Console.WriteLine("Proceed to pay?: Continue (1) | Type 0 to back");
                        int pay = Convert.ToInt32(Console.ReadLine());

                        if (pay == 1)
                        {
                            Console.WriteLine("Enter amount to Pay: ");
                             double amount = Convert.ToDouble(Console.ReadLine());

                                if (amount >= total) 
                                {
                                    change = amount - total;
                                    Console.WriteLine($"Payment Successful! Change: {change}");
                                }
                                else
                                {
                                Console.WriteLine("Insufficient amount, Try again: ");
                                    continue;
                                }
                        }
                        else if (pay == 0)
                        {
                                continue;
                        }
                    }
                    else if (cart == 0)
                    {
                            continue;
                    }
                        
                

                     









                    }
                }
            }
        }
    }
}
