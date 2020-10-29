using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
            {
                dao = new AuctionDao();
            }
            else
            {
                dao = auctionDao;
            }
        }
        //Get a list of all reservations in the system
        [HttpGet]
        public List<Auction> List()
        {
            return dao.List();
        }
        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auc = dao.Get(id);
            if (auc == null)
            {
                return NoContent();
            }
            return auc;
        }

        [HttpPost()]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction auc = dao.Create(auction);
            return Created($"/auctions/{auc.Id}", auc);
        }
    }
}
