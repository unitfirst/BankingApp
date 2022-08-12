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
        private string path = $"{Environment.CurrentDirectory}\\accounts.json";
        private Repository repo { get; }
        private ObservableCollection<Account> accounts = new ObservableCollection<Account>();
        private Account item { get; set; }
        private DataGrid dg { get; set; }
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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
            DataGrid dg = sender as DataGrid;
            item = DgAccounts.SelectedItem as Account;

            try
            {
                if (item != null)
                {
                    item.FirstName = firstNameTxt.Text;
                    item.LastName = lastNameTxt.Text;
                    item.PhoneNumber = phoneNumberTxt.Text;
                    item.Passport = Convert.ToInt32(passportTxt.Text);
                }
                else if (item == null)
                {
                    accounts.Add(new Account(firstNameTxt.Text, lastNameTxt.Text, phoneNumberTxt.Text, Convert.ToInt32(passportTxt.Text), DateTime.Now, DateTime.Now));
                    Btn_ChangeAccountInfo.Content = "ADD";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }


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
            item = DgAccounts.SelectedItem as Account;

            Btn_ChangeAccountInfo.Content = "APPLY";

            if (item != null)
            {
                firstNameTxt.Text = item.FirstName;
                lastNameTxt.Text = item.LastName;
                phoneNumberTxt.Text = item.PhoneNumber;
                passportTxt.Text = item.Passport.ToString();
            }
        }
    }
}
