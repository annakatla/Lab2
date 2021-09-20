using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();
            var customers = new List<Customer>();
            string loggedInCustomer;
            
            var lösnäsa = new Product("Lösnäsa", 50);
            products.Add(lösnäsa);
            var peruk = new Product("Peruk", 200);
            products.Add(peruk);
            var ballong = new Product("Ballong", 5);
            products.Add(ballong);

            var Knatte = new Customer("Knatte", "123");
            customers.Add(Knatte);
            var Fnatte = new Customer("Fnatte", "321");
            customers.Add(Fnatte);
            var Tjatte = new Customer("Tjatte", "213");
            customers.Add(Tjatte);

            //MENY ETT: 
            Console.WriteLine("AMANDAS CLOWNBUTIK");
            Console.WriteLine("");
            Console.WriteLine("MENY");
            Console.WriteLine("Knappa in ditt val (skriv in med siffror)");
            Console.WriteLine("1. Logga in");
            Console.WriteLine("2. Skapa ny kund");

            bool correctMenyChoice = int.TryParse(Console.ReadLine(), out int menyChoice);
            
            if (!correctMenyChoice)
            {
                Console.WriteLine("Du har inte skrivit in ett korrekt alternativ. Försök igen.");
            }
            else
            {
                correctMenyChoice = true;
                //LOGGA IN (anropa login())
                if (menyChoice == 1)
                {
                    Console.WriteLine("Ange ditt namn");
                    bool rightCustomer = false;
                    while (!rightCustomer)
                    {
                        loggedInCustomer = Console.ReadLine();
                        foreach (var customer in customers)
                        {
                            if (loggedInCustomer == customer.Name)
                            {
                                customer.logIn();
                                rightCustomer = true;
                                break;
                            } 
                        }
                        if (!rightCustomer)
                        {
                            Console.WriteLine("Namnet finns inte i vår databas. Vänligen försök igen:");
                        }
                    }
                }
                //SKAPA NY KUND 
                else if (menyChoice == 2)
                {
                    Console.WriteLine("Ange ett namn:");
                    loggedInCustomer = Console.ReadLine();
                    Console.WriteLine("Ange det lösenord du vill använda:");
                    string password = Console.ReadLine();
                    Console.WriteLine("Vänligen verifiera ditt lösenord:");
                    string verifyPassword = Console.ReadLine();
                    if (password == verifyPassword)
                    {
                        var cust = new Customer(loggedInCustomer, password);
                        customers.Add(cust);
                        Console.WriteLine("Ditt konto är nu skapat hos oss. Välkommen!");

                    }
                    else
                    {
                        Console.WriteLine("Lösenorden matchade inte.");
                    }
                }

            }

            //MENY TVÅ:
            Console.Clear();
            Console.WriteLine("Välkommen! Du är nu inloggad. Vad vill du göra nu? (Skriv in ditt val med siffror.)");
            Console.WriteLine("");
            Console.WriteLine("1. Handla.");
            Console.WriteLine("2. Se kundvagn.");
            Console.WriteLine("3. Gå till kassan");
            bool correctMeny2Choice = int.TryParse(Console.ReadLine(), out int meny2Choice);

            if (!correctMeny2Choice)
            {
                Console.WriteLine("Du har inte skrivit in ett korrekt alternativ. Försök igen.");
            }
            //HANDLA (avaibleproducts())
            else if (meny2Choice == 1)
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product.ToString());
                }
            } 
            //SE KUNDVAGN (showCart())
            else if (meny2Choice == 2)
            {

            } 
            //GÅ TILL KASSAN
            else if (meny2Choice == 3)
            {

            }



        }
        
        }
    }

