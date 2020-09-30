using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        private List<IAccountable> accounts = new List<IAccountable>();
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVip
        {
            get
            {
                //TODO Calculate Is VIP based on account balance here....





                //initial a sum of balances
                int sum = 0;
                foreach (IAccountable acct in accounts)
                {
                    sum += acct.Balance;
                }
                return (sum >= 25000);
            }
        }
                public void AddAccount(IAccountable newAccount)
                {
                    //Add the new ACCOUNT to our private list of accounts
                    accounts.Add(newAccount);
                }
            public IAccountable[] GetAccounts()
            {
                //IAccountable[] resultArray = new IAccountable[accounts.Count];
                //for (int i =0; i<resultArray.Length; i++)
                //{
                //    resultArray[i] = accounts[i];
                //}
                //return resultArray;
                return accounts.ToArray();
            }
        }
    }
