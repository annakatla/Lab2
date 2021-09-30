using System;
using System.Collections.Generic;

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
            //Kundobjekt för att ha koll på inloggad kund.
            Customer thisCustomer = null;
            
            //Tre fördefinierade produkter. 
            var lösnäsa = new Product("Lösnäsa", 50);
            products.Add(lösnäsa);
            var peruk = new Product("Peruk", 200);
            products.Add(peruk);
            var ballong = new Product("Ballong", 5);
            products.Add(ballong);

            //Tre fördefinierade kunder.
            var Knatte = new Customer("Knatte", "123");
            customers.Add(Knatte);
            var Fnatte = new Customer("Fnatte", "321");
            customers.Add(Fnatte);
            var Tjatte = new Customer("Tjatte", "213");
            customers.Add(Tjatte);

            //Bool och while-loop för att kunna börja om från början efter utloggning.
            bool letsStart = true;
            while (letsStart)
            {
                //Bool för att komma till inloggning utan att behöva se första menyn.
                bool programOn = true;

                //Första menyn visas: 
                Meny1();
                //Kontrollera Menyvalet.
                int menychoice = ControlMeny(2);

                while (programOn)
                {

                    //LOGGA IN
                    if (menychoice == 1)
                    {
                        //Bool för att kunna kontrollera om kunden redan finns i registret.
                        bool knownCustomer = false;
                        //Be om namn.
                        Console.Clear();
                        Console.WriteLine("Ange ditt namn");
                        //Spara namn i variabel
                        string loggedInCustomer = Console.ReadLine();
                        //Kontrollera om namnet stämmer med befintliga kunder.
                        foreach (var customer in customers)
                        {
                            if (loggedInCustomer.ToLower() == customer.Name.ToLower())
                            {
                                //Sätt bool till true, för att inte gå in i if-satsen längre ner.
                                knownCustomer = true;
                                bool getPassword = true;
                                while (getPassword)
                                {   
                                    //Be användaren att skriva in lösenord.
                                    Console.WriteLine("Ange lösenord");
                                    //Spara lösenord i variabel.
                                    string password = Console.ReadLine();
                                    //Bool för att underlätta kontrollerandet av lösenord.
                                    bool correctPassword = customer.VerifyPassword(password);
                                    if (!correctPassword)
                                    {       
                                        //Om lösenordet inte stämmer: be användaren skriva in igen. While-loopen börjar om från början.
                                        Console.WriteLine("Lösenordet är fel. Försök igen.");
                                    }
                                    else
                                    {   //Om lösenord stämmer: spara den inloggade kunden i thisCustomer och break från loopen.
                                        thisCustomer = customer;
                                        break;
                                    }
                                }
                            }
                        }    
                        //Om det inskrivna namnet inte finns i kundregistret: låt användaren få möjlighet att antingen försöka logga in igen eller att skapa ny kund.
                        if(!knownCustomer)
                        {
                            Console.WriteLine("Namnet finns inte i vår databas. Välj mellan följande alternativ:");
                            Console.WriteLine("1. Försök att skriva in namnet på nytt.");
                            Console.WriteLine("2. Skapa ny kund.");
                            menychoice = ControlMeny(2);
                        
                            if (menychoice == 1)
                            {
                                continue;
                            }
                        }
                        knownCustomer = false;
                    }
                    //SKAPA NY KUND 
                    if (menychoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Ange ett namn:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Ange det lösenord du vill använda:");
                        string password = Console.ReadLine();
                        var newCustomer = new Customer(name, password);
                        Console.WriteLine("Skriv in ditt lösenord på nytt.");
                        string password2 = Console.ReadLine();
                        if (newCustomer.VerifyPassword(password2))
                        {
                            thisCustomer = newCustomer;
                            customers.Add(thisCustomer);
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt lösenord. Klicka på valfri knapp för att försöka på nytt.");
                            Console.ReadKey();
                            break;
                        }
                    }


                    //MENY TVÅ:
                    Meny2();
                    menychoice = ControlMeny(4);
            
                    //Bool och while-loop för att kunna återkomma till att handla mer.
                    bool shoppingOn = true;
                    while (shoppingOn)
                    {
                        //HANDLA
                        if (menychoice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Tillgängliga produkter att handla är: ");
                            Console.WriteLine();
                            foreach (var product in products)
                            {
                                    Console.WriteLine($"{product.Objectname}, {product.Price} SEK/st.");
                            }
                            Console.WriteLine();
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
                        //SE KUNDVAGN
                        else if (menychoice == 2)
                        {
                            if (thisCustomer.Shoppingcart.Count < 1)
                            {
                                Console.WriteLine("Du har inga produkter i din kundvagn.");
                                Console.ReadKey();
                            }
                            else
                            {
                                foreach (var product in thisCustomer.Shoppingcart)
                                {
                                    Console.WriteLine(product.ToString());
                                }
                                Console.WriteLine($"Totalsumma: {thisCustomer.MyPrice} SEK.");
                                Console.WriteLine();
                                Console.WriteLine("Vill du ta bort något från kundvagnen? Skriv in ja/nej.");
                                string removeOrNot = Console.ReadLine();
                                if (removeOrNot == "ja")
                                {
                                    Console.WriteLine("Vad vill du ta bort? Om du vill tömma kundvagnen helt, skriv in ordet clear.");
                                    string productToRemove = Console.ReadLine();
                                    if (productToRemove.ToLower() == "clear")
                                    {
                                        thisCustomer.ClearCart();
                                    }
                                    else
                                    {
                                        foreach (var product in products)
                                        {
                                            if (productToRemove.ToLower() == product.Objectname.ToLower())
                                            {
                                                Console.WriteLine("Hur många vill du ta bort?");
                                                bool correctQuantity = int.TryParse(Console.ReadLine(), out int quantity);
                                                if (correctQuantity)
                                                {
                                                    thisCustomer.RemoveFromCart(product, quantity);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Du angav inte ett riktigt antal, i siffror. Försök igen.");
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            Meny3();
                            menychoice = ControlMeny(4);
                            if (menychoice == 1 || menychoice == 2)
                            {
                                continue;
                            }
                        } 
                        //GÅ TILL KASSAN
                        else if (menychoice == 3)
                        {
                            Console.WriteLine("Din kundkorg:");
                            Console.WriteLine();
                            foreach (var product in products)
                            {
                                Console.WriteLine(product.ToString());
                            }
                            Console.WriteLine($"Totalsumma: {thisCustomer.MyPrice} SEK.");
                            Console.WriteLine();
                            Console.Write("Vänligen skriv in din postadress: ");
                            thisCustomer.Address = Console.ReadLine();
                            Console.Write("Vilken adress vill du skicka fakturan till? ");
                            thisCustomer.InvoiceAddress = Console.ReadLine();
                            Console.WriteLine($"Tack för ditt köp! Din order kommer att hanteras och skickas till {thisCustomer.Address} inom 2-10 arbetsdagar.");
                            Console.WriteLine($"En faktura på {thisCustomer.MyPrice} SEK skickas till {thisCustomer.InvoiceAddress}.");
                            Console.ReadKey();
                            thisCustomer.ClearCart();
                            letsStart = false;
                            programOn = false;
                            shoppingOn = false;
                        }
                        //LOGGA UT
                        else if (menychoice == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Du är nu utloggad. Vill du logga in på nytt? Tryck 1. Om du vill stänga av, tryck 2.");
                            menychoice = ControlMeny(2);
                            if (menychoice == 1)
                            {
                                programOn = false;
                                shoppingOn = false;
                                Console.Clear();
                            }
                            else
                            {
                                letsStart = false;
                                programOn = false;
                                shoppingOn = false;
                            }
                        }
                    }
                    Console.WriteLine("Välkommen åter!");
                }
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

