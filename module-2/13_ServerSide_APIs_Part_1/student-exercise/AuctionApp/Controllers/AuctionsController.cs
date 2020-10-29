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
        //[HttpGet]
        //public List<Auction> SearchByTitle(string title_like = "")
        //{
        //    if (string.IsNullOrEmpty(title_like))
        //    {
        //        return dao.List();
        //    }
        //    else
        //    {
        //        return dao.SearchByTitle(title_like);
        //    }
        //}

        [HttpGet("{id}")]
        public ActionResult<Auction> GetOneAuction(int id)
        {
            Auction auc = dao.Get(id);
            if (auc == null)
            {
                return NoContent();
            }
            return auc;
        }

        [HttpPost()]
        public ActionResult<Auction> CreateAnAuction(Auction auction)
        {
            Auction auc = dao.Create(auction);
            return Created($"/auctions/{auc.Id}", auc);
        }


        [HttpGet]
        public List<Auction> SearchByTitleAndPrice(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return dao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return dao.SearchByPrice(currentBid_lte);
            }

            return dao.List();
        }

    }
}

