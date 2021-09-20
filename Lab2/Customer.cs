using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Customer
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart MyShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }


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




        public Customer(string name, string password)
        {
            this._name = name;
            this._password = password;
        }

        public override string ToString()
        {
            return $"Välkommen, {_name}!";
        }

        public void logIn()
        {
            bool correctPassword = false;
            while (!correctPassword)
            {
                Console.WriteLine("Ange lösenord");
                string password = Console.ReadLine();
                if (password != _password)
                {
                    Console.WriteLine("Lösenordet är fel. Försök igen.");
                    //Metoden skall sedan kalla på sig själv igen.
                }
                else if (password == _password)
                {
                    correctPassword = true;
                } //Annars - logga in.

            }
            
        }

    }
}
