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

        /***************
         * TODO: Implement these endpoints:
         * 
         *  /hotels             GET     - list of all hotels
         *  /hotels/{id}        GET     - get a single hotel
         *  /reservations       GET     - List all reservations
         *  /reservations/{id}  GET     - get a single reservation
         *  /hotels/{id}/reservations GET - Get all reservations for a hotel
         *  /reservations       POST    - Add a new reservation
         *  /reservations/{id}  PUT     - Update a res
         *  /reservations/{id}  DELETE  - Delete a res
         *  
         ***************/
        private IHotelDao hotelDao;
        private IReservationDao reservationDao;

        public HotelsController()
        {
            hotelDao = new HotelFakeDao();
            reservationDao = new ReservationFakeDao();
        }

        [HttpGet()]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        // TODO 03: Return 404 if the Id is not found (using NotFound()). Change return type to ActionResult<>
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
