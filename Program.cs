using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsStream = await client.GetStreamAsync($"https://api.openbrewerydb.org/breweries?by_city=san_diego");
            var brews = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

            foreach (var brew in brews)
            {
                Console.WriteLine($"{brew.Name}");
            }

        }
    }
}

