using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        // TO DO  Implement these endpoints:
            //**/hotels       GET - list of all hotels
            //**/hotels/{id}   GET - get a single hotel
            //**/reservations  GET -List all reservations
            //**/reservations/{id} GET - get a single reservation
            //**/hotels/{id}/reservations GET- get all reservations for a hotel
            //**/reservations     POST  - Add a new reservation
            //**/reservations/{id} PUT - Update a reservation
            //**/reservations/{id} DELETE - delete a reservation

        private IHotelDao hotelDao;
        private IReservationDao reservationDao;

        public HotelsController()
        {
            hotelDao = new HotelFakeDao();
            reservationDao = new ReservationFakeDao();
        }

        [HttpGet]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        [HttpGet("{id}")]
        public Hotel GetHotel(int id)
        {
            Hotel hotel = hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }



    }
}
