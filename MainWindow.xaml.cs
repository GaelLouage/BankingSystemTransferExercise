using BankingSystemEx.Helpers;
using BankingSystemEx.Models;
using BankingSystemEx.Repositories.Database;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingSystemEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBankRepository _bankRepository;

        public MainWindow(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
     
        }

        public MainWindow() : this(new BankRepository())
        {
            InitializeComponent();
            UpdateUi();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
            UpdateUi();
        }

        private void lbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedAccount = lbAccounts.SelectedItem;
            if(selectedAccount is BankAccount account)
            {
                var bankAcc = _bankRepository.GetAccount(account.AccountNumber);
                var bankAccountDetailWindow = new BankAccountWindow(bankAcc);
                bankAccountDetailWindow.Show();
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var owner = txtOwner.Text;
            if (string.IsNullOrWhiteSpace(owner))
            {
                MessageBox.Show("Owner name required!");
                return;
            }
            _bankRepository.CreateAccount(owner);
            UpdateUi();
        }



        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var fromAmount = txtFromAmount.Text;
            var from = cmbFrom.SelectedItem as BankAccount;
            var to = cmbTo.SelectedItem as BankAccount;
            ValidationHelpers.TransferValidation(_bankRepository, fromAmount, from, to);
            txtFromAmount.Text = string.Empty;
            UpdateUi();
        }

       

        private void UpdateUi()
        {
            lbAccounts.ItemsSource = null;
            lbAccounts.ItemsSource = _bankRepository.GetAll();

            cmbFrom.ItemsSource = null;
            cmbFrom.ItemsSource = _bankRepository.GetAll();

            cmbTo.ItemsSource = null;
            cmbTo.ItemsSource = _bankRepository.GetAll();
        }
    }
}