﻿using MenuFramework;
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

            AddOption("List Hotels", ListHotels)
                .AddOption("List Reviews", ListReviews)
                .AddOption("Show Details for a Hotel", HotelDetails)
                .AddOption("Show Reviews for a Hotel", HotelReviews)
                .AddOption("List Hotels with Rating", GetHotelsForRating)
                .AddOption("Exit", Exit)
                .Configure(c =>
                {
                    c.Title = "Welcome to Online Hotels! Please make a selection:";
                    c.ItemForegroundColor = ConsoleColor.Blue;
                });
        }

        private MenuOptionResult ListHotels()
        {
            // Call the api to get hotels (/hotels)
            Console.WriteLine("Not Implemented");

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ListReviews()
        {
            // Call the api to get hotels (/reviews)
            Console.WriteLine("Not Implemented");

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult HotelDetails()
        {
            // Call the api to get hotels (/hotels/{id})
            Console.WriteLine("Not Implemented");

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult HotelReviews()
        {
            // Call the api to get hotels (/hotels/{id}/reviews)
            Console.WriteLine("Not Implemented");

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult GetHotelsForRating()
        {
            // Call the api to get hotels (/hotels?stars={stars})
            Console.WriteLine("Not Implemented");

            return MenuOptionResult.WaitAfterMenuSelection;
        }


        #region Print Methods:
        private static void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
        }

        private static void PrintHotel(Hotel hotel)
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

        private static void PrintReviews(List<Review> reviews)
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
