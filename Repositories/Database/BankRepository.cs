using BankingSystemEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystemEx.Repositories.Database
{
    internal class BankRepository : IBankRepository
    {
        private static List<BankAccount> _bankAccounts = new List<BankAccount>
        {
            new BankAccount { Owner  = "Alice Johnson", Balance = 1500.75m },
            new BankAccount {Owner = "Bob Smith", Balance = 2340.50m },
            new BankAccount { Owner = "Charlie Brown", Balance = 500.00m },
            new BankAccount { Owner = "Diana Prince", Balance = 7850.20m }
        };

        public List<BankAccount> GetAll()
        {
            return _bankAccounts;
        }
        public void CreateAccount(string onwer)
        {
            _bankAccounts.Add(new BankAccount { Owner = onwer });
        }

        public BankAccount GetAccount(Guid accountNumber)
        {
            var getAccount = _bankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            if (getAccount is not null)
            {
                return getAccount;
            }
            return new BankAccount();
        }

        public string Transfer(Guid fromAccount, Guid toAccount, decimal amount)
        {
            var from = _bankAccounts.FirstOrDefault(x => x.AccountNumber == fromAccount);
            var to = _bankAccounts.FirstOrDefault(x => x.AccountNumber == toAccount);
            if (from is not null && to is not null)
            {
                if (from.Balance >= amount)
                {
                    from.Balance -= amount;
                    to.Balance += amount;
                    return "";
                }
            }
            return "Insufficient funds";
        }
    }
}
