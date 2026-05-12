using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using System.Text;
using System.Transactions;


namespace Olivarez_Mary_Joy_ShoppingCartActivity
{
    // Parent Class
    public class BaseItem
    {
        protected string Name;
        protected double Price;

        public string GetName() => Name;
        public double GetPrice() => Price;
    }

    // Child Class
    public class Product : BaseItem
    {
        private readonly int Id;
        private int RemainingStock;
        private readonly string category;


        // Constructor
        public Product (int Id, string Name, double Price, int Stock, string Category)
        {
            this.Id = Id;
            this.Name = Name; // inherited
            this.Price = Price; // inherited
            this.RemainingStock = Stock;
            this.category = Category;
        }

        // Setters
        public void SetremainingStock(int newStock) => RemainingStock = newStock;

        // Getters 
        public int GetId() => Id;
        public int GetRemainingStock() => RemainingStock;
        public string GetCategory() => category;

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
    public class CartItem : BaseItem
    {
        private int Quantity;
        private double Subtotal;

        // Setters

        public void SetName(string name) { this.Name = name; }
        public void SetQuantity (int quantity) { this.Quantity = quantity; }
        public void SetPrice(double price) { this.Price = price; }
        public void SetSubtotal(double subtotal) { this.Subtotal = subtotal; }

        // Getters
        public int GetQuantity() => Quantity;
        public double GetSubtotaL () => Subtotal;

    }
} 