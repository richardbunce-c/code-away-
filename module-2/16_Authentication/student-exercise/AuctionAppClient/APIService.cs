using AuctionApp.Exceptions;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;

namespace AuctionApp
{
    public class APIService
    {
        private readonly static string API_BASE_URL = "https://localhost:44390/";
        private readonly static string AUCTIONS_URL = API_BASE_URL + "auctions";
        private readonly IRestClient client;
        private static API_User user = new API_User();

        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }

        public APIService()
        {
            client = new RestClient();
        }
        public APIService(IRestClient restClient)
        {
            client = restClient;
        }

        public List<Auction> GetAllAuctions()
        {
            RestRequest request = new RestRequest(AUCTIONS_URL);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        private void ProcessErrorResponse(IRestResponse<List<Auction>> response)
        {
            throw new NotImplementedException();
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            RestRequest requestOne = new RestRequest(AUCTIONS_URL + "/" + auctionId);
            IRestResponse<Auction> response = client.Get<Auction>(requestOne);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

       

        public void ProcessErrorResponse(RestResponse<Auction> response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedException("Authorization is required for this option. Please log in.");
                }
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new ForbiddenException("You do not have permission to perform the requested action");
                }

                throw new NonSuccessException($"Error occurred - received non-success response: {response.StatusCode} ({(int)response.StatusCode})");
            }
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTitle)
        {
            RestRequest request = new RestRequest(AUCTIONS_URL + "?title_like=" + searchTitle);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestRequest request = new RestRequest(AUCTIONS_URL + "?currentBid_lte=" + searchPrice);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Auction AddAuction(Auction newAuction)
        {
            RestRequest request = new RestRequest(AUCTIONS_URL);
            request.AddJsonBody(newAuction);
            IRestResponse<Auction> response = client.Post<Auction>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Auction UpdateAuction(Auction auctionToUpdate)
        {
            RestRequest request = new RestRequest(AUCTIONS_URL + "/" + auctionToUpdate.Id);
            request.AddJsonBody(auctionToUpdate);
            IRestResponse<Auction> response = client.Put<Auction>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public bool DeleteAuction(int auctionId)
        {
            RestRequest request = new RestRequest(AUCTIONS_URL + "/" + auctionId);
            IRestResponse response = client.Delete(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return true;
            }
            return false;
        }

        protected void ProcessErrorResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }

            else if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new ForbiddenException("");
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedException();
                }
                throw new NonSuccessException($"Error occurred - received non-success response: {response.StatusCode} ({(int)response.StatusCode})");
            }
        }

        public API_User Login(string submittedName, string submittedPass)
        {
            var credentials = new { username = submittedName, password = submittedPass };
            RestRequest request = new RestRequest($"{API_BASE_URL}login");
            request.AddJsonBody(credentials);

            IRestResponse<API_User> response = client.Post<API_User>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new NoResponseException("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                if (!string.IsNullOrWhiteSpace(response.Data.Message))
                {
                    throw new NonSuccessException("An error message was received: " + response.Data.Message);
                }
                else
                {
                    throw new NonSuccessException("An error response was received from the server. The status code is " + (int)response.StatusCode);
                }
            }
            else
            {
                //user.Token = response.Data.Token;
                user = response.Data;
                client.Authenticator = new JwtAuthenticator(user.Token);
                return user; /*response.Data;*/
            }
        }

        public void Logout()
        {
            user = new API_User();
            client.Authenticator = null;
        }
    }
}
