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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
