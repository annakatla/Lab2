using System;
using System.Collections.Generic;

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

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _invoiceAddress;
        public string InvoiceAddress
        {
            get { return _invoiceAddress; }
            set { _invoiceAddress = value; }
        }

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
            string message = $"Välkommen, {Name}! Ditt lösenord är {Password}. I din kundvagn ligger ";
            foreach (var product in Shoppingcart)
            {
                message += product.ToString() + " ";
            }
            return message;
        }
        public bool VerifyPassword(string password)
        {
            bool correctPassword = false;
            if (password == _password)
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
            if (quantity > product.Quantity)
            {
                quantity = product.Quantity;
            }
            double productCost = product.Price * quantity;
            product.Quantity -= quantity;
            product.TotalSumPerProduct = product.TotalSumPerProduct - productCost;
            if (product.Quantity <= 0)
            {
                Shoppingcart.Remove(product);
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
