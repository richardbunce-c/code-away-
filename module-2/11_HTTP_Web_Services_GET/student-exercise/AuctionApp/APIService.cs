using RestSharp;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AuctionApp
{
    public class APIService
    {
       
        string API_URL = "http://localhost:3000";
        
        private readonly RestClient client;
     
        public List<Auction> GetAllAuctions()
        {
            RestClient client = new RestClient(API_URL);
            RestRequest request = new RestRequest("/auctions");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
           
            return response.Data;
        }

        public Auction GetDetailsForAuction(int auctionId)
        {

            RestClient client = new RestClient(API_URL);
            RestRequest request = new RestRequest($"/auctions/{auctionId}");
            IRestResponse <Auction> response = client.Get<Auction>(request);
            return response.Data;

        }

        public List<Auction> GetAuctionsSearchTitle(string searchTitle)
        {
            RestClient client = new RestClient(API_URL);
            RestRequest request = new RestRequest($"?searchTitle={searchTitle}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            return response.Data;
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestClient client = new RestClient(API_URL);
            RestRequest request = new RestRequest($"?searchPrice={searchPrice}");
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            return response.Data;
        }
    }
}
