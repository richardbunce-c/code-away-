using Accounts.Models;
using System;
using System.Collections.Generic;

/***
 * REQUIREMENTS
 * 
 * Savings accounts and Checking accounts each have a Balance property, as well as the following methods:
 *      Deposit(amount) - add money to the account
 *      Withdraw(amount) - remove money from the account
 *      DoMonthlyProcessing() - apply monthly debits and credits to the balnce of the account
 *      
 * Saving accounts have these special rules:
 *      They have an InterestRate property so that monthly interest can be earned.
 *      Savings accounts do not allow a withdrawal which is greater than the balance.
 *      For monthly processing, credit interest to the account balance
 *      
 * Checking accounts have these special rules:
 *      When the account is created, a per-transaction fee is set. Every check written will be charged this amount.
 *      Checking accounts will allow overdraws. However, a $5 fee will be added to the monthly fees for each overdraw.
 *      For monthly processing, debit total overdraft fees as well as a transaction fee for every check written.
 ***/

// TODO 01: Create a BankAccount class with default behavior.
// TODO 02: Create a SavingAccount to specialize the BankAccount
// TODO 03: Create a CheckingAccount to specialize the BankAccount


namespace Accounts
{
    class Program
    {
        /// <summary>
        /// The Main program just gets things rolling.  It creates our accounts, and an instance of our ATM.
        /// Then it lets the ATM take over flow control
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            //SavingsAccount acct = new SavingsAccount("1234-abc", 0);
            //acct.Deposit(100.00M);
            //acct.Withdraw(25.00M);
            //acct.Withdraw(125.00M);
            //Console.WriteLine($"Account has {acct.Balance:C}");
            //Console.ReadLine();

            // TODO 04: Create a savings account and a checking account for the user, and pass those into
            // the ATM
            SavingsAccount savings = new SavingsAccount("AAA", 500.00M);
            CheckingAccount checking = new CheckingAccount("CCC", 100.00M, 0.50M);

            // Create the CLI and let it run the rest of the logic flow
            ATMCLI cli = new ATMCLI(savings, checking);
            cli.Run();

            Console.WriteLine("Thank you for using our ATM!");
            Console.ReadKey();
        }

    }
}
