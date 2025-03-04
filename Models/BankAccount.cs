
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystemEx.Models
{
    public class BankAccount
    {
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public string Owner { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public string Withdraw(decimal amount)
        {
            if (Balance > amount)
            {
                Balance -= amount;
                return "";
            }
            return "Unsifficient Funds!";
        }
        public override string ToString()
        {
            return $"Account: {AccountNumber} \n Owner: {Owner} \n Balance: {Balance:C}";
        }
    }
}
