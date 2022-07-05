using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace kanyewest
{
    internal class Program
    {
        private static int quote;

        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Console.WriteLine(kanyeQuote);

            var client2 = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client2.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine(ronQuote);

            for(int i = 0; i < ronQuote.Length; i++)
            {
                 kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                 kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine(kanyeQuote);

                ronResponse = client2.GetStringAsync(ronURL).Result;
                ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine(ronQuote);
            }
        }
    }
}
