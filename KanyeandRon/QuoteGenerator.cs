using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanyeandRon
{
    public class QuoteGenerator 
    { 
        private HttpClient _client;

        public QuoteGenerator(HttpClient client)
        {
            _client = client;
        }

    
        //HttpClient is a base clients
        //Base class Helps make a request to internet. Get response in JSon form and parse the response. 
        //You will use an API 

        public string Kanye()
        {
                                                      //new object that allow you make request to internet. 

            var kanyURL = "https://api.kanye.rest/";  //string that holds URL that is needed. 

            var kanyeResponse = _client.GetStringAsync(kanyURL).Result; //plug kanye URL into method. Sends git request and store response in kanyeResponse variable.
                                                                       //Once we get response from git request we will need to parse through that response and get the info. needed. 
                                                                       //client.GetStringAsync is instance of httpclient object. sends a request to api.kanye.rest/ and gets response in Json format. 
                                                                       //response is stored in kanyeResponse variable

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString(); //We have to use Nugget NewSoft.Json.Linq on Object class because it allows us to work with Json.
                                                                                        //.Parse is a static method. 
                                                                                        //Once response comes back .GetValue method will parse response passed into .GetValue method and store in kanyeQuote. 
            return kanyeQuote;
            Console.WriteLine($"{kanyeQuote}");                                         //console.writeline kanyeQuote to see Quote. 
            Console.WriteLine($"-------");
        }

        public string Ron()
        { 

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronsResponse = _client.GetStringAsync(ronURL).Result;

            var ronQuote = JArray.Parse(ronsResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();


            return ronQuote;
            Console.WriteLine($"-------");
            Console.WriteLine($"{ronQuote[0]}");
            Console.WriteLine($"-------");

        }
    }
}
