using System.Buffers.Text;

namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
    

        public decimal OverDraftFee { get;  } = 10;

 // Constructor
    
        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance): base(accountHolderName, accountNumber, balance)
        {

        }

        //Method
    
    public override decimal Withdraw(decimal amountToWithDraw)
    {
        if ((Balance - amountToWithDraw) <= -100M && amountToWithDraw > Balance)
        {
            return Balance;
            }
       if (Balance-amountToWithDraw>-99M && amountToWithDraw>Balance)
        {
                return base.Withdraw(amountToWithDraw + OverDraftFee);
        }
        return base.Withdraw(amountToWithDraw);
    }
    }
}
/*********************************
 * Withdraw(amount)
 * 
 * decimal targetBalance=Balance-amount;
 * if (targetBalance<= -100)
 * {
 *             //Do Nothing
 * return Balance;
 * {
 * else if targetBalance<0)
 * {
 *     ///allow it, but sock em with a charge of more of what they don't have
 *     base.Withdraw(amount = 10);
 *     return Balance;
 *     }
 *     else
 *     {
 *         /// Allow it with no penalty
 *         return base.Withdraw(amount);
}
}
*/