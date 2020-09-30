using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BankTellerExercise.Classes
{
    public class BankAccount
    {

        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }
        
        
        //Constructor
        public BankAccount(string accountHolderName, string accountNumber, decimal initialBalance)
       
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        public BankAccount(string accountHolderName, string accountNumber)

        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            
        }



        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return Balance;
        }
        virtual public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }

      
    }
}



