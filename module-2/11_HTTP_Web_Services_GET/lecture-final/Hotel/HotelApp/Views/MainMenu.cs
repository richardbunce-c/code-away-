using MenuFramework;
using RestSharp;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_GET_lecture.Views
{
    public class MainMenu : ConsoleMenu
    {
        // Client for http calls
        private RestClient client;

        public MainMenu(string apiUrl)
        {
            // TODO: Create the RestClient here...
            client = new RestClient(apiUrl);

            AddOption("List Hotels", ListHotels)
                .AddOption("List Reviews", ListReviews)
                .AddOption("Show Details for a Hotel", HotelDetails)
                .AddOption("Show Reviews for a Hotel", HotelReviews)
                .AddOption("List Hotels with Rating", GetHotelsForRating)
                .AddOption("Exit", Exit)
                .Configure(c =>
                {
                    c.Title = "Welcome to Online Hotels! Please make a selection:";
                    c.ItemForegroundColor = ConsoleColor.Green;
                });
        }

        private MenuOptionResult ListHotels()
        {
            // Call the api to get hotels (/hotels)

            // Create a request for this endpoint
            RestRequest request = new RestRequest("/hotels");

            // Send HTTP GET Request
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("There was an error getting hotels!");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            PrintHotels(response.Data);

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ListReviews()
        {
            // Call the api to get hotels (/reviews)

            RestRequest request = new RestRequest("reviews");

            // Send the http get 
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("There was an error getting reviews!");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            PrintReviews(response.Data);


            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult HotelDetails()
        {
            // Call the api to get hotels (/hotels/{id})

            // Ask the user for the hotel id
            int hotelId = GetInteger("Hotel Id: ");

            // Create the request for this resource
            RestRequest request = new RestRequest($"/HOTELS/{hotelId}");

            // Send the http request
            IRestResponse<Hotel> response = client.Get<Hotel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Could not get details for hotel {hotelId}");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            // Print the result
            PrintHotel(response.Data);

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult HotelReviews()
        {
            // Call the api to get hotels (/hotels/{id}/reviews)

            // Ask the user for the hotel id
            int hotelId = GetInteger("Hotel Id: ");

            // Create the request for this resource
            RestRequest request = new RestRequest($"/hotels/{hotelId}/reviews");

            // Send the http request
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Could not get reviews for hotel {hotelId}");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            // Print the result
            PrintReviews(response.Data);


            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetHotelsForRating()
        {
            // Call the api to get hotels (/hotels?stars={stars})
            // Ask the user for the star rating to search for
            int stars = GetInteger("How many stars? ");

            // Create the request for this resource
            RestRequest request = new RestRequest($"/hotels?stars={stars}");

            // Send the http request
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Could not get hotels with star rating {stars}");
                return MenuOptionResult.WaitAfterMenuSelection;
            }

            // Print the result
            PrintHotels(response.Data);

            return MenuOptionResult.WaitAfterMenuSelection;
        }


        #region Print Methods:
        private void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
        }

        private void PrintHotel(Hotel hotel)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotel Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + hotel.Id);
            Console.WriteLine(" Name: " + hotel.Name);
            Console.WriteLine(" Stars: " + hotel.Stars);
            Console.WriteLine(" Rooms Available: " + hotel.RoomsAvailable);
            Console.WriteLine(" Cover Image: " + hotel.CoverImage);
        }

        private void PrintReviews(List<Review> reviews)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Review Details");
            Console.WriteLine("--------------------------------------------");
            foreach (Review review in reviews)
            {
                Console.WriteLine(" Hotel ID: " + review.HotelID);
                Console.WriteLine(" Title: " + review.Title);
                Console.WriteLine(" Review: " + review.ReviewText);
                Console.WriteLine(" Author: " + review.Author);
                Console.WriteLine(" Stars: " + review.Stars);
                Console.WriteLine("---");
            }
        }
        #endregion

    }
}
