using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //En lista för produkter.
            var products = new List<Product>();
            //En lista för kunder.
            var customers = new List<Customer>();
            //String för att spara namn vid inloggning.
            string loggedInCustomer;
            //Kundobjekt för att ha koll på inloggad kund.
            Customer thisCustomer = null;
            
            //Definiera tre produkter. 
            var lösnäsa = new Product("Lösnäsa", 50);
            products.Add(lösnäsa);
            var peruk = new Product("Peruk", 200);
            products.Add(peruk);
            var ballong = new Product("Ballong", 5);
            products.Add(ballong);

            //Tre fördefinierade kunder.
            var Knatte = new GoldCustomer("Knatte", "123");
            customers.Add(Knatte);
            var Fnatte = new SilverCustomer("Fnatte", "321");
            customers.Add(Fnatte);
            var Tjatte = new BronzeCustomer("Tjatte", "213");
            customers.Add(Tjatte);

            bool loggingIn = true;
            bool findingName = true;
            bool programOn = true;
            while (programOn)
            {
                bool shoppingOn = true;
                //MENY ETT: 
                Meny1();
                //Kontrollera Menyvalet.
                int menychoice = ControlMeny(2);

                //Gå vidare i menyn.
                if (menychoice == 1)
                {
                    while (loggingIn)
                    {

                    Console.WriteLine("Ange ditt namn");
                    loggedInCustomer = Console.ReadLine();
                    foreach (var customer in customers)
                    {
                        if (loggedInCustomer == customer.Name)
                        {
                            bool correctPassword = false;
                            Console.WriteLine("Ange lösenord");
                            while (!correctPassword)
                            {
                                string password = Console.ReadLine();
                                if (password != customer.Password)
                                {
                                    Console.WriteLine("Lösenordet är fel. Försök igen.");
                                }
                                else if (password == customer.Password)
                                {
                                    correctPassword = true;
                                    loggingIn = false;
                                }
                            }
                            thisCustomer = customer;
                            break;
                        }
                        else
                        {
                            findingName = false;
                        }
                    }
                    if (!findingName)
                    {
                        Console.WriteLine("Namnet finns inte i vår databas. Välj mellan följande alternativ:");
                        Console.WriteLine("1. Försök att skriva in namnet på nytt.");
                        Console.WriteLine("2. Skapa ny kund.");

                        menychoice = ControlMeny(2);
                        
                        if (menychoice == 1)
                        {
                            findingName = true;
                            continue;
                        }
                    }
                    }
                }
                //SKAPA NY KUND 
                if (menychoice == 2)
                {
                    thisCustomer = Customer.NewCustomer();
                    customers.Add(thisCustomer);
                }


                //MENY TVÅ:
                Meny2();
                menychoice = ControlMeny(4);
            
                while (shoppingOn)
                {
                //HANDLA (avaibleproducts())
                if (menychoice == 1)
                {
                    Console.WriteLine("Tillgängliga produkter att handla är: ");
                    foreach (var product in products)
                    {
                            Console.WriteLine($"");
                    }
                    Console.WriteLine("Vad vill du köpa? Skriv in produktnamn.");
                    string productToBuy = Console.ReadLine();

                    //foreach-loop per produkt. jämför om det finns.
                    foreach (var product in products)
                    {
                        if (productToBuy == product.Objectname.ToLower())
                        {
                            Console.WriteLine("Hur många vill du köpa?");
                            bool amountOfProduct = int.TryParse(Console.ReadLine(), out int quantity);
                            if (amountOfProduct)
                            {
                                thisCustomer.AddToCart(product, quantity);
                                Meny3();
                                menychoice = ControlMeny(4);
                                if (menychoice == 1)
                                {
                                    continue;
                                }
                            }
                        }
             
                    }

                } 
                //SE KUNDVAGN (showCart())
                else if (menychoice == 2)
                {
                    if (thisCustomer.Shoppingcart.Count < 1)
                    {
                        Console.WriteLine("Du har inga produkter i din kundvagn.");
                        Console.ReadKey();
                        Meny4();
                    }
                    else
                    {
                        foreach (var product in products)
                        {
                            Console.WriteLine(product.ToString());
                        }
                        Console.WriteLine($"Totalsumma: {thisCustomer.MyPrice}");
                        Console.ReadKey();
                        Console.WriteLine("Vill du ta bort något från kundvagnen? Skriv in ja/nej.");
                        string removeOrNot = Console.ReadLine();
                        if (removeOrNot == "ja")
                        {
                            Console.WriteLine("Vad vill du ta bort? Skriv in produktnamn med små bokstäver");
                            string productToRemove = Console.ReadLine();

                            foreach (var product in products)
                            {
                                if (productToRemove == product.Objectname.ToLower())
                                {
                                    Console.WriteLine("Hur många vill du ta bort?");
                                    int quantity = int.Parse(Console.ReadLine());
                                    thisCustomer.RemoveFromCart(product, quantity);
                                }
                            }
                            Meny3();
                            menychoice = ControlMeny(4);
                        }
                        else
                        {
                            shoppingOn = false;
                            Meny4();
                            menychoice = ControlMeny(3);
                        }
                    }
                    if (menychoice == 1)
                    {
                        continue;
                    }
                    else if (!shoppingOn && menychoice == 2)
                    {
                        menychoice = 3;
                    }
                    else if (!shoppingOn && menychoice == 3)
                    {
                        menychoice = 4;
                    }
                } 
                //GÅ TILL KASSAN
                else if (menychoice == 3)
                {

                }
                else if (menychoice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Du är nu utloggad. Vill du logga in på nytt? Tryck 1. Om du vill stänga av, tryck 2.");
                    menychoice = ControlMeny(2);
                    if (menychoice == 1)
                    {
                        shoppingOn = false;
                        Console.Clear();

                    }
                    else
                    {
                        programOn = false;
                        shoppingOn = false;
                    }
                }
                }
                Console.WriteLine("Välkommen åter!");
            }
        }

        static void Meny1()
        {
            Console.Clear();
            Console.WriteLine("AMANDAS CLOWNBUTIK");
            Console.WriteLine("");
            Console.WriteLine("MENY");
            Console.WriteLine("Knappa in ditt val (skriv in med siffror)");
            Console.WriteLine("1. Logga in");
            Console.WriteLine("2. Skapa ny kund");
        }
        static void Meny2()
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra? (Skriv in ditt val med siffror.)");
            Console.WriteLine("");
            Console.WriteLine("1. Handla");
            Console.WriteLine("2. Se kundvagn");
            Console.WriteLine("3. Gå till kassan");
            Console.WriteLine("4. Logga ut");
        }
        static void Meny3()
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra nu?");
            Console.WriteLine("1. Fortätta att handla.");
            Console.WriteLine("2. Se kundvagn");
            Console.WriteLine("3. Gå till kassan.");
            Console.WriteLine("4. Logga ut.");
        }
        static void Meny4()
        {
            Console.Clear();
            Console.WriteLine("Vad vill du göra nu?");
            Console.WriteLine("1. Fortätta att handla.");
            Console.WriteLine("2. Gå till kassan");
            Console.WriteLine("3. Logga ut.");
        }
        static int ControlMeny(int menyVal)
        {
            bool correctMenyChoice = int.TryParse(Console.ReadLine(), out int menychoice);
            while (!correctMenyChoice || menychoice > menyVal)
            {
                Console.WriteLine("Felaktigt värde. Vänligen skriv in ditt val med den siffra som representerar ditt val.");
                correctMenyChoice = int.TryParse(Console.ReadLine(), out menychoice);
            }
            return menychoice;
        }
    }
}

