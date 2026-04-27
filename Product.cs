using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using System.Text;
using System.Transactions;


namespace Olivarez_Mary_Joy_ShoppingCartActivity
{
    // Product Class
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int RemainingStock { get; set; }

        // Display Product 
        public void DisplayProduct()
        {
            string stockDisplay = RemainingStock == 0 ? "*** OUT OF STOCK ***" :
                                 RemainingStock <= 10 ? $"Stock: {RemainingStock} <<< LOW STOCK" :
                                 $"Stock: {RemainingStock}";

            Console.WriteLine($"ID: {Id} | {Name,-20} | Price: \u20B1{Price:N2} | {stockDisplay}");
        }

        // Stock Validations
        public bool HasEnoughStock(int quantity) => quantity <= RemainingStock;

        // Deduct stock after purchase
        public void DeductStock(int quantity) => RemainingStock -= quantity;

        // Calculate total price for a given quantity
        public double GetItemTotal(int quantity) => Price * quantity;
    }

    // CartItem Class
    public class CartItem
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
    }
} 