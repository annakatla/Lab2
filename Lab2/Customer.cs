using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 
{
    class Customer
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private double _myPrice;
        public double MyPrice
        {
            get { return _myPrice; }
            set { _myPrice = value; }
        }

        public string Address { get; set; }
        public string invoiceAddress { get; set; }

        private List<Product> _shoppingcart;
        public List<Product> Shoppingcart
        {
            get { return _shoppingcart; }
            set { _shoppingcart = value; }
        }

        public Customer()
        {
            MyPrice = 0;
            Shoppingcart = new List<Product>();
        }

        public Customer(string name, string password)
        {
            this._name = name;
            this._password = password;
            MyPrice = 0;
            Shoppingcart = new List<Product>();
        }

        public override string ToString()
        {
            return $"Välkommen, {Name}! Ditt lösenord är {Password}. I din kundvagn ligger nu ";
        }

        public static Customer NewCustomer()
        {
            Console.Clear();
            Console.WriteLine("Ange ett namn:");
            string name = Console.ReadLine();
            Console.WriteLine("Ange det lösenord du vill använda:");
            string password = Console.ReadLine();
            bool correctPassword = VerifyPassword(password);
                if (correctPassword)
                {
                    var newCustomer = new Customer(name, password);
                    return newCustomer;
                }
                else
                {
                    Console.WriteLine("Felaktigt lösenord. Vänligen försök på nytt.");
                    Console.ReadKey();
                    return NewCustomer();
                    
                }
        }
        public static bool VerifyPassword(string password)
        {
            Console.WriteLine("Skriv in lösenord på nytt:");
            string passwordAgain = Console.ReadLine();
            bool correctPassword = false;
            if (password == passwordAgain)
            {
                correctPassword = true;
            }
            return correctPassword;
        }
        public virtual void AddToCart(Product product, int quantity)
        {
            double productCost = product.Price * quantity;
            Shoppingcart.Add(product);
            product.Quantity += quantity;
            product.TotalSumPerProduct = product.TotalSumPerProduct + productCost;
            MyPrice += productCost;
        }
        public virtual void RemoveFromCart(Product product, int quantity)
        {
            double productCost = product.Price * quantity;
            product.Quantity -= quantity;
            if (product.Quantity <= 0)
            {
                product.Quantity = 0;
                product.TotalSumPerProduct = 0;
                Shoppingcart.Remove(product);
            }
            else
            {
                product.TotalSumPerProduct = product.TotalSumPerProduct - productCost;
            }
            MyPrice -= productCost;
        }
        public void ClearCart()
        {
            foreach (Product product in Shoppingcart)
            {
                product.Quantity = 0;
                product.TotalSumPerProduct = 0;
            }
            Shoppingcart.Clear();
            MyPrice = 0;
        }
    }
}
