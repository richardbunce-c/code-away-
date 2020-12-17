using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoServer.Models;

namespace TenmoClient
{
    public class APIService
    {
        private readonly static string APIBaseUrl = "https://localhost:44315/";
        private RestClient client = new RestClient();

        public Account GetBalance(int userId)
        {

            RestRequest request = new RestRequest(APIBaseUrl + "account/" + userId);  
            IRestResponse<Account> response = client.Get<Account>(request);

            return response.Data;

        }

        public List<User> GetListOfUsers()           
        {
            RestRequest request = new RestRequest(APIBaseUrl + "account/");
            IRestResponse<List<User>> response = client.Get<List<User>>(request);

            return response.Data;
            
        }


        public Transfer SendMoney(int userIDInput, decimal money)
        {
            Transfer transfer = new Transfer();
            transfer.AccountFrom = UserService.GetUserId();
            transfer.AccountTo = userIDInput;
            transfer.Amount = money;
            transfer.TransferStatusId = 2;
            transfer.TransferTypeId = 2;

            RestRequest request = new RestRequest(APIBaseUrl + "transfer");
            request.AddJsonBody(transfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                return null;
            }
            else
            {
                return response.Data;
            }

        }

        public List<Transfer> TransferList(int userId)
        {
            RestRequest request = new RestRequest(APIBaseUrl + "transfer/"+ userId);
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                //response not received
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                //response non-2xx
                Console.WriteLine("An error response was received from the server. The status code is " + (int)response.StatusCode);
                return null;
            }
            else
            {
                //success
                return response.Data;
            }
        }

        public Transfer TransferDetails(int transferId)
        {
            RestRequest request = new RestRequest(APIBaseUrl + "transfer/" + transferId);
            IRestResponse<Transfer> response = client.Get<Transfer>(request);

            return response.Data;
        }







        // update account balance ?????????????????????
        //public Account UpdateAccount(Account accountToUpdate)      
        //{
        //    RestRequest request = new RestRequest(APIBaseUrl + "account/");         // can this have the same path as the above method(GetListOfUsers)?
        //    IRestResponse<Account> response = client.Put<Account>(request);
        //    request.AddJsonBody(accountToUpdate);
        //    if(response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
        //    {
        //        _= response;                // the _ discards data if response status is not completed or successful 
        //    }
        //    else
        //    {
        //        return response.Data;
        //    }

        //    return null;

        //}





    }
}
