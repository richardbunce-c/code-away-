using System;
using System.Collections.Generic;
using System.Linq;
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

        public ReservationsController()
        {
            hotelDao = new HotelFakeDao();
            reservationDao = new ReservationFakeDao();
        }

        //Get a list of all reservations in the system
        [HttpGet]
        public List<Reservation> GetReservations()
        {
            return reservationDao.List();
        }

        //Get the reservation given an id
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation res = reservationDao.Get(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        //Get the reservations for a single hotel
        [HttpGet("/hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservationsForHotel(int hotelId)
        {
            return reservationDao.FindByHotel(hotelId);
        }

        //Add a reservation
        [HttpPost()]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            Reservation res = reservationDao.Create(reservation);
            return Created($"/reservations/{res.Id}", res );
        }
    //Update a reservation
    [HttpPut("{id}")]
    public Reservation UpdateReservation(Reservation reservation)
        {
           return reservationDao.Update(reservation);
        }
    //Delete a reservation
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
