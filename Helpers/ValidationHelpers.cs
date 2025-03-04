using BankingSystemEx.Models;
using BankingSystemEx.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        public static void WidrawOrDepositValidation(RadioButton rdbWithdraw, RadioButton rdbDeposit, TextBox txtAmount, ref decimal amount)
        {
            if (rdbWithdraw.IsChecked is false && rdbDeposit.IsChecked is false)
            {
                MessageBox.Show("Please select witdraw or deposit!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Amount cannot be empty!");
                return;
            }
            if (decimal.TryParse(txtAmount.Text, out amount) is false)
            {
                MessageBox.Show("Amount should be numerical.");
                return;
            }
        }
    }
}
