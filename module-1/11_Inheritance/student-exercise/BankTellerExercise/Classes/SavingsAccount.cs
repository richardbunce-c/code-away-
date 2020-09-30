namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {

        public decimal ServiceCharge{get;} = 2;
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance):base (accountHolderName, accountNumber, balance)
        {

        }
        public override decimal Withdraw(decimal amount)
        { 
          if (amount<Balance && Balance<150)
            {
                return base.Withdraw(ServiceCharge+amount);
            }
        
           else if (amount < Balance && Balance-amount<150)
            {
                
                return base.Withdraw(amount+ServiceCharge); 
            }
       
            else
            {
                return base.Withdraw(amount);
            }
        }

    }
}
