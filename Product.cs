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
        private readonly int Id;
        private readonly string Name = string.Empty;
        private readonly double Price;
        private int RemainingStock;
        private readonly string category;


        // Constructor
        public Product (int Id, string Name, double Price, int Stock, string Category)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.RemainingStock = Stock;
            this.category = Category;
        }

        // Setters
        public void SetremainingStock(int stock) { this.RemainingStock = stock; }

        // Getters 
        public int GetId() { return this.Id; }
        public string GetName() { return this.Name; }

        public double GetPrice() { return this.Price; }
        public int GetRemainingStock() { return this.RemainingStock; }
        public string GetCategory() { return this.category; }

        // Display Product 
        public void DisplayProduct() =>
            Console.WriteLine($"ID: {Id} | {Name,-20} | Price: \u20B1{Price:N2} | Stock: {RemainingStock} | [{category}]");
        
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
        private string Name;
        private double Price;
        private int Quantity;
        private double Subtotal;

        // Setters

        public void SetName(string name) { this.Name = name; }
        public void SetQuantity (int quantity) { this.Quantity = quantity; }
        public void SetPrice(double price) { this.Price = price; }
        public void SetSubtotal(double subtotal) { this.Subtotal = subtotal; }

        // Getters

        public string GetName() { return this.Name; }
        public int GetQuantity() { return this.Quantity; }
        public double GetPrice() { return this.Price; }
        public double GetSubtotaL () { return this.Subtotal; }

    }
} 