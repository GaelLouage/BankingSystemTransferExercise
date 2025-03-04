
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
        public void Withdraw(decimal amount)
        {
            if (Balance > 0)
            {
                Balance -= amount;
            }
        }
        public override string ToString()
        {
            return $"Account: {AccountNumber}, Owner: {Owner}, Balance: {Balance:C}";
        }
    }
}
