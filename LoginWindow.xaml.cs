using BankingApp.Models;
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

namespace BankingApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Btn_Consultant_Click(object sender, RoutedEventArgs e)
        {
            AccessValidator accessValidator = new AccessValidator(false);
            Close();
        }

        private void Btn_Manager_Click(object sender, RoutedEventArgs e)
        {
            AccessValidator accessValidator = new AccessValidator(true);
            Close();
        }
    }
}
