using System;
using System.Collections.Generic;
using RestSharp;

namespace LocationApp
{
    class Program
    {
        const string API_URL = "http://localhost:3000/locations";
        static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            int id;
            int menuSelection;
            PrintGreeting();
            if(!int.TryParse(Console.ReadLine(), out menuSelection))
            {
                Console.WriteLine("Invalid input. Only input a number.");
            }
       if (menuSelection==1)
            {
                //List locations
            }
            else
            {
                Environment.Exit(0);
            }
            if (menuSelection == 1)
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(API_URL);
                IRestResponse<List<Location>> response = client.Get<List<Location>>(request);
                PrintLocations(response.Data);
            }
                
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Only input a number.");
                }
            if (id>0 && id <= response.Data.Count)
            {
                RestRequest requestOne = new RestRequest(API_URL + "/" + id);
                IRestResponse<Location> location = RestClient.Get<Location>(requestOne);
                PrintLocation(location.Data);
            }
        }

        private static void PrintGreeting()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to Tech Elevator Locations. Please make a selection: ");
            Console.WriteLine("1: List Tech Elevator Locations");
            Console.WriteLine("2: Exit");
            Console.WriteLine("");
            Console.Write("Please choose an option: ");
        }

        private static void PrintLocations(List<Location> locations)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Locations");
            Console.WriteLine("--------------------------------------------");
            foreach (Location location in locations)
            {
                Console.WriteLine(location.Id + ": " + location.Name);
            }
            Console.WriteLine("");
            Console.Write("Please enter a location id to get the details: ");
        }

        private static void PrintLocation(Location location)
        {
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Location Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Id: " + location.Id);
            Console.WriteLine("Name: " + location.Name);
            Console.WriteLine("Address: " + location.Address);
            Console.WriteLine("City: " + location.City);
            Console.WriteLine("State: " + location.State);
            Console.WriteLine("Zip: " + location.Zip);
        }
    }
}
