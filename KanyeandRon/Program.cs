using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.Json.Nodes;

namespace KanyeandRon
{
    class Program
    {

        static void Main(string[] args)
        {
               
            var client = new HttpClient();
            var quote = new QuoteGenerator(client);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("--------");
                Console.WriteLine($"Ye: {quote.Kanye()}");

                Console.WriteLine($"Ron: {quote.Ron()}");
            }

        }

    }



}

