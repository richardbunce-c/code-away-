﻿namespace HotelReservationsClient.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int RoomsAvailable { get; set; }
        public decimal CostPerNight { get; set; }
        public string CoverImage { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
