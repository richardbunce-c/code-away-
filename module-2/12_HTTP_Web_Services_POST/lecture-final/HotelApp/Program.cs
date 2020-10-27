using HTTP_Web_Services_POST_PUT_DELETE_lecture.DAL;
using HTTP_Web_Services_POST_PUT_DELETE_lecture.Views;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_POST_PUT_DELETE_lecture
{
    class Program
    {
        private static readonly string apiUrl = "http://localhost:3000/";

        static void Main(string[] args)
        {
            //int n = GetIntegerValue();
            //return;

            IHotelDao hotelDao = new HotelApiDao(apiUrl);
            IReviewDao reviewDao = new ReviewApiDao(apiUrl);
            IReservationDao reservationDao = new ReservationApiDao(apiUrl);

            new MainMenu(hotelDao, reviewDao, reservationDao).Show();
        }

        private static int GetIntegerValue()
        {
            Console.Write("Please enter an integer: ");
            string s = Console.ReadLine();

            int outValue = 0;
            bool itWorked = MikesTryParse(s, out outValue);

            if (itWorked)
            {
                Console.WriteLine($"The value is {outValue}");
            }
            else
            {
                Console.WriteLine("No, that did not work.");
            }

            return outValue;
        }

        public static bool MikesTryParse(string s, out int theValue)
        {
            try
            {
                theValue = int.Parse(s);
                return true;
            }
            catch (Exception)
            {
                theValue = 0;
                return false;
            }
        }
    }
}
