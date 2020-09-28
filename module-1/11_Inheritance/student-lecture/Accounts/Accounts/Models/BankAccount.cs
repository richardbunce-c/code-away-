using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Models
{
    class BankAccount
    {
   
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        //Constructor accepts new account number and initial balance
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return amount;
        }
     virtual public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return amount;
        }
    }
}
