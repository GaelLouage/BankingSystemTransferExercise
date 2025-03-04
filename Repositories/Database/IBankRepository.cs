using BankingSystemEx.Models;

namespace BankingSystemEx.Repositories.Database
{
    public interface IBankRepository
    {
        void CreateAccount(string onwer);
        BankAccount GetAccount(Guid accountNumber);
        string Transfer(Guid fromAccount, Guid toAccount, decimal amount);
        List<BankAccount> GetAll();
    }
}