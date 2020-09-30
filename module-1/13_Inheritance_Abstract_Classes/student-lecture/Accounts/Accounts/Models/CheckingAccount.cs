using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Models
{
    public class CheckingAccount : BankAccount
    {
        private decimal transactionFee;
        public CheckingAccount(string accountNumber, decimal initialBalance, decimal transactionFee) : base(accountNumber, initialBalance)
        {
            this.transactionFee = transactionFee;
        }
    }
}
