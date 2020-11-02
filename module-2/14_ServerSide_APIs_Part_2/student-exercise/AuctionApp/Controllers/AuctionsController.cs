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
        private IAuctionDao auctionDao;
        

        public AuctionsController(IAuctionDao auctionDao)
        {
          this.auctionDao = auctionDao;
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return auctionDao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return auctionDao.SearchByPrice(currentBid_lte);
            }

            return auctionDao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = auctionDao.Get(id);
            if (auction == null)
            {
                return NotFound();
            }
            else
            {
                return auction;
            }
        }

        [HttpPost]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction auc= auctionDao.Create(auction);
        
            return Created($"/auctions/{auc.Id}", auc);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuction(int id)
        {
            if (auctionDao.Delete(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, Auction auction)
        {
            if (id != auction.Id)
            {
                return BadRequest("The id in the url does not match the id in the body");
            }
            return BadRequest();
          
        }

    }
}
