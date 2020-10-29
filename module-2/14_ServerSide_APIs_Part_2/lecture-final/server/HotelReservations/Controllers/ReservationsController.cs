using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotelReservations.Dao;
using HotelReservations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
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

        private IReservationDao reservationDao;

        public ReservationsController(IReservationDao reservationDao)
        {
            this.reservationDao = reservationDao;
        }

        /// <summary>
        /// Get a list of all reservations in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            return reservationDao.List();
        }

        /// <summary>
        /// Get the reservation given an id
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        [HttpGet("{reservationId}")]
        public ActionResult<Reservation> GetReservation(int reservationId)
        {
            Reservation res = reservationDao.Get(reservationId);
            if (res == null)
            {
                return NotFound();
            }

            return res;
        }

        [HttpGet("/hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservationsForHotel(int hotelId)
        {
            return reservationDao.FindByHotel(hotelId);
        }

        [HttpPost]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            if (reservation.CheckinDate >= reservation.CheckoutDate)
            {
                return BadRequest("Checkout date must be beyond Checkin date.");
            }

            Reservation res = reservationDao.Create(reservation);
            return Created($"/reservations/{res.Id}", res);
        }

        [HttpPut("{id}")]
        public Reservation UpdateReservation(Reservation reservation)
        {
            return reservationDao.Update(reservation);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            if (reservationDao.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

    }
}
