using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
   public class CreditCardAccount : IAccountable
    {
       
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public int Debt { get; set; }
       
        public int Balance 
        {
            get
            {
                return Debt * -1;
                    }
        }
        public CreditCardAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            Debt = 0;
        }

        public int Pay(int amountToPay)
        {
            Debt -= amountToPay;
            return Debt;
        }
        public int Charge(int amount)
        {
            Debt += amount;
            return Debt;
        }
            }
}
