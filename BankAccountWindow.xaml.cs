using BankingSystemEx.Helpers;
using BankingSystemEx.Models;
using BankingSystemEx.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankingSystemEx
{
    /// <summary>
    /// Interaction logic for BankAccountWindow.xaml
    /// </summary>
    public partial class BankAccountWindow : Window
    {
        private BankAccount _bankAccount;

        public BankAccountWindow(BankAccount bankAccount)
        {

            InitializeComponent();
            _bankAccount = bankAccount;
            txtBankAccountDetails.Text = _bankAccount.ToString();
        
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            var widrawSelected = rdbWithdraw.IsChecked;
            var depositSelected = rdbDeposit.IsChecked;
            decimal amount = 0;
            ValidationHelpers.WidrawOrDepositValidation(rdbWithdraw, rdbDeposit, txtAmount,ref amount);

            if(widrawSelected is true)
            {
                var withdraw = _bankAccount.Withdraw(amount);
                if(string.IsNullOrEmpty(withdraw) is false)
                {
                    MessageBox.Show(withdraw);
                    return;
                }

            } 
            else if (depositSelected is true) 
            {
                _bankAccount.Deposit(amount);
            }
            txtBankAccountDetails.Text = string.Empty;
            txtBankAccountDetails.Text = _bankAccount.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //var main =  (MainWindow)Application.Current.MainWindow;
            //main.Show();
            var main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
