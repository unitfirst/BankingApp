using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    internal class AccessValidator
    {
        private bool access;

        public AccessValidator(bool access)
        {
            this.access = access;

            if (!access)
            {
                MainWindow mainWindow = new MainWindow(access = false);
                mainWindow.Show();
            }
            else
            {
                MainWindow mainWindow = new MainWindow(access = true);
                mainWindow.Show();
            }
        }
    }
}
