using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    static internal class GuestBook
    {
        static List<string> _guestBook = new List<string>();

        static public void AddMessage(GuestBookMessage GBM)
        {
            _guestBook.Add(GBM.Message);
        }
        static public void ReadMessages()
        {
            Console.WriteLine("\n=================Gästbok===================\n");
            foreach (string message in _guestBook)
            {
                Console.WriteLine($" {message}\n");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("      Tack för ditt besök och inlägg.        ");
            Console.WriteLine("                                            ");
            Console.WriteLine("=================Gästbok====================");
        }

    }

    internal class GuestBookMessage
    {
        public string Message {            
            get
            {
                return string.Join(" ", collectionOfThirdWords);
            }
        }
        public GuestBookMessage(string message)
        {
            collectionOfThirdWords = new List<string>();
            _message = message.Split(' ');
            for (int i = 2; i < _message.Length; i += 3)
            {
                collectionOfThirdWords.Add(_message[i]);
            }
        }
        
        private List<string> collectionOfThirdWords;

        private string[] _message;
       
    }
}
