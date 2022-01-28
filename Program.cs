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
        static async Task GetListOfAllBreweriesByCity()
        {
            var client = new HttpClient();
            Console.Write("Enter the name of the city you'd like to search for: ");
            var cityResponse = Console.ReadLine();
            var url = $"https://api.openbrewerydb.org/breweries?by_city={cityResponse}";
            var responseAsStream = await client.GetStreamAsync(url);
            var brews = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

            var table = new ConsoleTable("Name", "City", "State", "Website");

            Console.WriteLine($"Breweries in {cityResponse}: ");
            foreach (var brew in brews)
            {
                table.AddRow(brew.Name, brew.City, brew.State, brew.Website);
                // Console.WriteLine($"{brew.Name}\nAddress:{brew.Street}\n");
            }
            table.Write();
        }

        static async Task GetAllBreweriesByState()
        {
            var client = new HttpClient();
            Console.Write("Enter the name of the state you'd like to search for: \n");
            var stateResponse = Console.ReadLine();
            var url = $"https://api.openbrewerydb.org/breweries?by_state={stateResponse}";
            var responseAsStream = await client.GetStreamAsync(url);
            var brews = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);
            var table = new ConsoleTable("Name", "City", "State", "Website");


            Console.WriteLine($"Breweries in {stateResponse}: \n");
            foreach (var brew in brews)
            {
                table.AddRow(brew.Name, brew.City, brew.State, brew.Website);
                // Console.WriteLine($"{brew.Name}");
            }
            table.Write();

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

        static async Task Main(string[] args)
        {
            var keepBrewing = true;
            while (keepBrewing)
            {
                Console.Clear();
                var menuSelection = Menu();
                switch (menuSelection)
                {
                    case "1":
                        await GetListOfAllBreweriesByCity();
                        Console.WriteLine("\nPress ENTER after viewing to quit to menu\n");
                        var userInput = Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        await GetAllBreweriesByState();
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

