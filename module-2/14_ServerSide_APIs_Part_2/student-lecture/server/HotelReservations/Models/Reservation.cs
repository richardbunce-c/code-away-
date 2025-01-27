﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservations.Models
{
    // TODO 01: Use Postman to show how we can enter invalid data
    /*** TODO 02: Add data validation attributes to protect the model data
    *          HotelId, FullName, Checkin, Checkout and Guests are all required
    *          The number of guests should be in the Range of 1 - 5
    *          Full name should be at least 6 characters long
    ***/
    public class Reservation
    {
        public int? Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        [MinLength(6, ErrorMessage ="Full name is too short")]
        public string FullName { get; set; }

        [Required]
        public DateTime CheckinDate { get; set; }

        [Required]
        public DateTime CheckoutDate { get; set; }

        [Required]
        [Range(1,5, ErrorMessage ="No more than 5 guests are allowed.")]
        public int Guests { get; set; }

        public Reservation(int? id, int hotelId, string fullName, DateTime checkinDate, DateTime checkoutDate, int guests)
        {
            Id = id ?? new Random().Next(100, int.MaxValue);
            HotelId = hotelId;
            FullName = fullName;
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
            Guests = guests;
        }
    }
}
