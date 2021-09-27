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

        public double MyPrice { get; set; }

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
            return $"Välkommen, {Name}!";
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
                    NewCustomer();
                    return null;
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
            Shoppingcart.Add(product);
            product.Quantity += quantity;    
            MyPrice += product.Price * quantity;
        }

        //public void ShowCart()
        //{
        //    if (Shoppingcart.Count < 1)
        //    {
        //        Console.WriteLine("Du har inga produkter i din kundvagn.");
        //        Console.ReadKey();
        //    }
        //    else
        //    {

        //        Console.WriteLine(Product.ToString());
        //        Console.WriteLine($"Totalsumma: {MyPrice}");
        //        Console.ReadKey();
        //        Console.WriteLine("Vill du ta bort något från kundvagnen? Skriv in ja/nej.");
        //        string removeOrNot = Console.ReadLine();
        //        if (removeOrNot == "ja")
        //        {
        //            Console.WriteLine("Vad vill du ta bort? Skriv in produktnamn med små bokstäver");
        //            string product = Console.ReadLine();
        //            Console.WriteLine("Hur många vill du ta bort?");
        //            int quantity = int.Parse(Console.ReadLine());
        //        }
        //    }
        //}

        public virtual void RemoveFromCart(Product product, int quantity)
        {
            Shoppingcart.Remove(product);
            product.Quantity -= quantity;
            MyPrice -= product.Price * quantity;
        }
    }
}
