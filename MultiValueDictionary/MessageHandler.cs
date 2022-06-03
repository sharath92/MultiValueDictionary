using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MultiValueDictionary.Constants;

namespace MultiValueDictionary
{
    public static class MessageHandler
    {
        public static void ShowMessage(string message)
        {
            if (!message.Contains(Symbol.Output))
                Console.Write($"{Symbol.Output} ");

            Console.WriteLine($"{message}");
        }

    }
}
