using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    internal class Account
    {
        private static int staticId;
        static Account()
        {
            staticId = 0;
        }
        private static int nextId()
        {
            return staticId++;
        }

        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _passport;
    }
}
