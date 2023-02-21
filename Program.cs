using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;
namespace APIClientDogs
{
    class TestJson
    {

    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Welcome to API Client For Dogs!");
                var dogbreed = PromptForInput("What breed of dog would you like to see?");

                await GetBreeds(dogbreed);

                var keepGoingInput = PromptForInput("Would you like to keep going? (y/n)").ToUpper();
                if (keepGoingInput == "N")
                {
                    keepGoing = false;
                }
            }

            static string PromptForInput(string prompt)
            {
                Console.WriteLine(prompt);
                return Console.ReadLine();
            }

            static async Task GetBreeds(string dogbreed)
            {
                var client = new HttpClient();
                var url = $"https://dog.ceo/api/breed/{dogbreed}/images";
                var responseBodyAsStream = await client.GetStreamAsync(url);
                Response messageObj = await JsonSerializer.DeserializeAsync<Response>(responseBodyAsStream);
                var responseObj = messageObj.Message;
                var status = messageObj.Status;
                Console.WriteLine($"Status: {status}");
                Console.WriteLine($"Message: {responseObj[0]}");
                // //Table Formatting
                // var table = new ConsoleTable("Message", "Status");
                // table.AddRow(messageObj);
                // table.Write();

            }
        }
    }
}