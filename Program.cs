using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace ApiClient
{
    class Program
    {
        static async void GetListOfAllBreweriesByCity()
        {
            var client = new HttpClient();
            var url = "https://api.openbrewerydb.org/breweries?by_city=san_diego";
            var responseAsStream = await client.GetStreamAsync(url);
            var brews = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

            // *****Need to get to bottom of this!*********
            var table = new ConsoleTable("Name", "City", "State", "Website");

            Console.WriteLine("Breweries in San Diego: ");
            foreach (var brew in brews)
            {
                table.AddRow(brew.Name, brew.City, brew.State, brew.Website);
                // Console.WriteLine($"{brew.Name}\nAddress:{brew.Street}\n");
            }
            table.Write();
        }

        static async void GetAllBreweriesByState()
        {
            var client = new HttpClient();
            var url = "https://api.openbrewerydb.org/breweries?by_state=florida";
            var responseAsStream = await client.GetStreamAsync(url);
            var brews = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

            Console.WriteLine("Breweries in Florida: ");
            foreach (var brew in brews)
            {
                Console.WriteLine($"{brew.Name}");
            }

            var url2 = "https://api.openbrewerydb.org/breweries?by_state=texas";
            var responseAsStream2 = await client.GetStreamAsync(url2);
            var brews2 = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream2);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Breweries in Texas: ");
            foreach (var brew2 in brews2)
            {
                Console.WriteLine($"{brew2.Name}");
            }
        }
        static string Menu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Get list of all breweries in a city");
            Console.WriteLine("(2) Get list of all breweries in a state");
            Console.WriteLine("(3) Quit");
            Console.WriteLine("Select an option, then hit ENTER");
            var choice = Console.ReadLine();
            Console.Clear();
            return choice;
        }

        static void Main(string[] args)
        {
            var keepBrewing = true;
            while (keepBrewing)
            {
                Console.Clear();
                var menuSelection = Menu();
                switch (menuSelection)
                {
                    case "1":
                        GetListOfAllBreweriesByCity();
                        Console.WriteLine("\nPress ENTER after viewing to quit to menu\n");
                        var userInput = Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        GetAllBreweriesByState();
                        Console.WriteLine("\nPress ENTER after viewing to quit to menu\n");
                        var userInput2 = Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("\nClosing App\n");
                        keepBrewing = false;
                        break;
                }
            }

        }

    }
}

