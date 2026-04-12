using System;
using System.Collections.Generic;
using System.Text;

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
            };

            Product product3 = new Product();
            {
                product3.Id = 3;
                product3.Name = "Bag";
                product3.Price = 350;
                product3.Remaining_Stock = 20;
            };

            while (true)
            {
                Console.WriteLine("\n ===Menu System");
                Console.WriteLine($"ID: {product1.Id} | Name: {product1.Name} | Price: {product1.Price} | Remaining Stock: {product1.Remaining_Stock}");
                Console.WriteLine($"ID: {product2.Id} | Name: {product2.Name} | Price: {product2.Price} | Remaining Stock: {product2.Remaining_Stock}");
                Console.WriteLine($"ID: {product3.Id} | Name: {product3.Name} | Price: {product3.Price} | Remaining Stock: {product3.Remaining_Stock}");

                Console.WriteLine("Enter Product Number: ");
                Console.ReadLine();

                Console.WriteLine("Quantity: ");
                Console.ReadLine();





            }







        }
        


    }
}
