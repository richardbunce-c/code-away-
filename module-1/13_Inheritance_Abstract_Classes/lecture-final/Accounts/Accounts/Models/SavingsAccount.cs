using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Models
{
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public SavingsAccount(string acctNum, decimal bal) : base(acctNum, bal)
        {
            InterestRate = 0.0025;
        }

        public override decimal Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                // do not allow overdraw
                return 0;
            }

            return base.Withdraw(amount);
        }
    }
}
