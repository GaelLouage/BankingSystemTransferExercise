using BankingSystemEx.Models;
using BankingSystemEx.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankingSystemEx.Helpers
{
    internal class ValidationHelpers
    {
        public static void TransferValidation(IBankRepository bankRepository, string fromAmount, BankAccount? from, BankAccount? to)
        {
            if (to is null)
            {
                MessageBox.Show("To required!");
                return;
            }
            if (from is null)
            {
                MessageBox.Show("From required!");
                return;
            }
            if (decimal.TryParse(fromAmount.ToString(), out decimal fromAm) is false)
            {
                MessageBox.Show("From textfield has to be numeric");
                return;
            }
            if (from.AccountNumber == to.AccountNumber)
            {
                MessageBox.Show("From cannot be the same as To.");
                return;
            }

            var result = bankRepository.Transfer(from.AccountNumber, to.AccountNumber, fromAm);
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
                return;
            }
        }
    }
}
