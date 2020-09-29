using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Accounts.Models
{
    class BankAccount
    {

        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }
        public BankAccount(string accountHolderName, string accountNumber, decimal initialBalance)
        {
            AccountHolderName = accountHolderName;
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



