using Accounts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts
{


    /// <summary>
    /// Our ATM CLI (Command Line Interface).This is all UI. Business logic is in the Account classes (in Models)
    /// </summary>
    class ATMCLI
    {
        // TODO 05: Update the CLI to use the accounts
        private SavingsAccount savingsAccount;
        private CheckingAccount checkingAccount;

        private Dictionary<string, BankAccount> myAccounts = new Dictionary<string, BankAccount>(); 

        // TODO 05: Update the CLI to use the accounts
        public ATMCLI(SavingsAccount savingsAccount, CheckingAccount checkingAccount)
        {
            this.savingsAccount = savingsAccount;
            this.checkingAccount = checkingAccount;

            // These two forms are equivalent for adding the account to the dictionary
            myAccounts.Add(savingsAccount.AccountNumber, savingsAccount);
            myAccounts[checkingAccount.AccountNumber] = checkingAccount;

        }

        public void Run()
        {
            while (true)
            {
                DisplayBalance();
                Console.Write(@"
    1) Deposit into Savings
    2) Transfer from Savings to Checking
    3) Write a check
    4) Do monthly processing
    5) Display Accounts
    Q) Quit

Please choose an option: ");

                String input = Console.ReadLine().ToLower();

                if (input.Length == 0)
                {
                    Console.Clear();
                    continue;
                }
                input = input.Substring(0, 1);

                if (input == "q")
                {
                    break;
                }
                else if (input == "1")
                {
                    DepositSavings();
                }
                else if (input == "2")
                {
                    Transfer();
                }
                else if (input == "3")
                {
                    WriteCheck();
                }
                else if (input == "4")
                {
                    DoMonthlyProcessing();
                }
                else if (input == "5")
                {
                    DisplayAccounts();
                }
                else
                {
                    Error($"'{input}' is an invalid entry. Press enter, then try again.");
                }
                Console.ReadLine();
                Console.Clear();

            }
        }

        private void DisplayAccounts()
        {
            foreach(KeyValuePair<string, BankAccount> kvp in this.myAccounts)
            {
                BankAccount acct = kvp.Value;
                Console.WriteLine($"{kvp.Key}: {acct.Balance}, {acct.AccountNumber}");
            }
            Console.ReadLine();
        }

        private void DoMonthlyProcessing()
        {
            Success("Performing monthly processing...");
            // TODO 05: Update the CLI to use the accounts
            //Success(savingsAccount.DoMonthlyProcessing());
            //Success(checkingAccount.DoMonthlyProcessing());
        }

        private void WriteCheck()
        {
            decimal checkAmount = GetAmount("Enter the check value: ");
            Success($"Writing check for {checkAmount:C}");
            // TODO 05: Update the CLI to use the accounts
            //checkingAccount.WriteCheck(checkAmount);
        }

        private void Transfer()
        {
            decimal transferAmount = GetAmount("Enter the amount to transfer: ");
            Success($"Transferring {transferAmount:C} from savings to checking");
            // TODO 05: Update the CLI to use the accounts
            if (savingsAccount.Withdraw(transferAmount) > 0)
            {
                checkingAccount.Deposit(transferAmount);
            }
            else
            {
                Error("There was not enough money. Transfer cancelled");
            }
        }

        private void DepositSavings()
        {
            decimal depositAmount = GetAmount("Enter the amount to deposit: ");
            Success($"Depositing {depositAmount:C} into savings");
            // TODO 05: Update the CLI to use the accounts
            savingsAccount.Deposit(depositAmount);
        }

        private void DisplayBalance()
        {
            // TODO 05: Update the CLI to use the accounts

            string title = "The Savings account balance is";
            Success($"{title,-32} {savingsAccount.Balance,10:C}");
            title = "The Checking account balance is";
            Success($"{title,-32} {checkingAccount.Balance,10:C}");
            title = new string('-', 43);
            Success(title);
            title = "Your total balance is";
            Success($"{title,-32} {(checkingAccount.Balance + savingsAccount.Balance),10:C}");
        }

        private decimal GetAmount(string prompt)
        {
            decimal amount = 0;
            while (amount <= 0)
            {
                Console.Write(prompt);
                if (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Error("Invalid.");
                }
            }
            return amount;
        }

        private void Success(string msg)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = color;
        }

        private void Error(string msg)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = color;
        }

    }
}
