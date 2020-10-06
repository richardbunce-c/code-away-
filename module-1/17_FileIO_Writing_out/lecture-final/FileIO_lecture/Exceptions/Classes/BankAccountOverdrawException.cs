using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.Classes
{
    public class BankAccountOverdrawException : Exception
    {
        public string AccountNumber { get; }
        public decimal InitialBalance { get; }
        public decimal AmountToWithdraw { get; }
        public BankAccountOverdrawException(BankAccount account, decimal amount) : base("There has been an attempt to overdraw this account")
        {
            AccountNumber = account.AccountNumber;
            InitialBalance = account.Balance;
            AmountToWithdraw = amount;
        }
    }
}
