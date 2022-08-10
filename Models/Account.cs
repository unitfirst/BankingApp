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

        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string passport;
    }
}
