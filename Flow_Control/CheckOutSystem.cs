using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    internal class CheckOutSystem
    {
        static public void PrintRecipet(List<Ticket> tickets)
        {
            int totalPrice = 0;
            foreach (Ticket ticket in tickets)
            {
                totalPrice += ticket.Price;
            }

            string recipe = "--------------------KVITTO----------------------\n" +
                           $"{tickets.Count} st " + "Kung Fu Panda" + " biljetter" + "\n" +
                            "Totalt: " + totalPrice + " SEK\n" +
                            "-------------------------------------------------\n";
            Console.WriteLine(recipe);
        }

        static public void PrintTickets(List<Ticket> tickets)
        {
            DateTime date = DateTime.Now;
            Random random = new Random();

            for(int i = 0; i < tickets.Count; i++)
            {
                int chair = random.Next(1, 99);
                int row = random.Next(1, 12);
                string stringTicket =   $"====BILJETT=#{i+1}================================\n" +
                                        " KIDS CINEMA STHLM" + "           " + date.ToString("yyyy-MM-dd") + "\n" +
                                        " Film: " + "Kung Fu Panda" + "            \n" +
                                        " Salong," + " " + "Rad,"  + " " +  $"Stolnr \n" +
                                        $"   {random.Next(1, 5)}   " + $"   {row}    " + $"{chair}" + " \n" +
                                        $" Kategori: {tickets[i].AgeCategory}," + " " + $"Pris: {tickets[i].Price} SEK        \n" +
                                        $"================================BILJETT=#{i + 1}====\n";
                Console.WriteLine(stringTicket);
            }
        }
    }

    internal class ShoppingCart
    {
        private List<Ticket> _tickets;
        public ShoppingCart()
        {
            _tickets = new List<Ticket>();
        }
        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }
        public List<Ticket> GetTickets
        {
            get
            {
                return _tickets;
            }
        }
    }
}
