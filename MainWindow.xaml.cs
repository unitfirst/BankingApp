using BankingApp.Models;
using BankingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Repository repo;
        private string path = $"{Environment.CurrentDirectory}\\accounts.json";
        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        public MainWindow(bool access)

        {
            InitializeComponent();

            if (!access)
            {
                UserRole.Text = "Role: Consultant";
            }
            else
            {
                UserRole.Text = "Role: Manager";
            }

            repo = new Repository(path);
            DataContext = repo;
            //accounts = repo.GetList();
            DgAccounts.ItemsSource = accounts;
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void AboutButton_Click(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hey! This is my first Windows app \nv0.10");
        }

        private void Btn_ChangeAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            accounts.Add(new Account(firstNameTxt.Text, lastNameTxt.Text, phoneNumberTxt.Text, Convert.ToInt32(passportTxt.Text), DateTime.Now, DateTime.Now));
            ClearInputs();
        }

        private void ClearInputs()
        {
            firstNameTxt.Text = "";
            lastNameTxt.Text = "";
            phoneNumberTxt.Text = "";
            passportTxt.Text = "";
        }

        private void DgAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            if (dg.SelectedItem != null)
            {
                var item = dg.SelectedItem as Account;

                firstNameTxt.Text = item.FirstName;
                lastNameTxt.Text = item.LastName;
                phoneNumberTxt.Text = item.PhoneNumber;
                passportTxt.Text = item.Passport.ToString();

            }

        }
    }
}
