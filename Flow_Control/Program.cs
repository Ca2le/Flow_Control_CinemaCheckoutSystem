using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Flow_Control
{
    class Program
    {
        private static ShoppingCart _currentShoppingCart;
        public static ShoppingCart CurrentShoppingCart
        {
            get
            {
                return _currentShoppingCart;
            }
            set
            {
                _currentShoppingCart = value;
            }
        }
        static void Main()
        {
            bool isRunning = true;
            CurrentShoppingCart = new ShoppingCart();
 
            while (isRunning)
            {
                string GreetMessage = new string("\n---------------------------------------------------" +
                                   "\n|        Välkommen till KIDS CINEMA STHLM         |" +
                                   "\n|         Välj bland följande alternativ.         |" +
                                   "\n| 0: Avsluta.                                     |" +
                                   "\n| 1: Lägg till 1 biljett.                         |" +
                                   "\n| 2: Lägg till flera biljetter.                   |" +
                                   "\n| 3: Skriv ut dina biljetter.                     |" +
                                   "\n| 4: Skriv i vår gästbok.                         |" +
                                   "\n---------------------------------------------------" +
                                  $"\n| Biljetter i varukorgen: {CurrentShoppingCart.GetTickets.Count} st." +
                                   "\n---------------------------------------------------");
                Console.WriteLine(GreetMessage);
                string input = Console.ReadLine();
               

                switch (input)
                {
                    case "0":
                        isRunning = false;
                        break;
                    case "1":
                        Console.WriteLine("Vilken ålder är biljettinnehavaren?");
                        string ageInput = Console.ReadLine();
                        bool validInput = int.TryParse(ageInput, out int age);
                        if (validInput)
                        {
                            _currentShoppingCart.AddTicket(new Ticket(age)); 
                            break;
                        }
                        break;
                    case "2" :
                        Console.WriteLine("Hur många biljettinnehavare?");
                        string amountInput = Console.ReadLine();
                        bool validAmountInput = int.TryParse(amountInput, out int amount);
                        if (validAmountInput)
                        {
                            for (int i = 0; i < amount; i++)
                            {
                                Console.WriteLine($"Vilken ålder är biljettinnehavare nr: {i+1}?");
                                string ageInput2 = Console.ReadLine();
                                bool validInput2 = int.TryParse(ageInput2, out int age2);
                                if (validInput2)
                                {
                                    _currentShoppingCart.AddTicket(new Ticket(age2));
                                }
                            }   
                        }

                        break;
                    case "3":
                        CheckOutSystem.PrintTickets(_currentShoppingCart.GetTickets);
                        CheckOutSystem.PrintRecipet(_currentShoppingCart.GetTickets);
                        break;

                        case "4":
                            Console.WriteLine("OBS! Vår gästbok genomgår idag en ombyggnad,\n " +
                                                "den skriver endast ut var tredje ord i ditt \n " +
                                                "inlägg, vi ber så klart om ursäkt för denna bug!");
                            Console.WriteLine(  "Skriv ditt meddelande här: ");
                            string message = Console.ReadLine();
                            if (message.Length < 1)
                            {
                                Console.WriteLine("Du måste skriva något i gästboken för att kunna posta det.");
                                break;
                            }
                            GuestBookMessage guestBookMessage = new GuestBookMessage(message);
                            GuestBook.AddMessage(guestBookMessage) ;
                            GuestBook.ReadMessages();
                        break;
                    default:
                        Console.WriteLine("Obs! Något gick fel med inmatning prova igen...");
                        break;
                }
            }
        }
    }
}