using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    internal class Account
    {
        private static int staticId;
        static Account()
        {
            staticId = 1;
        }
        private static int nextId()
        {
            return staticId++;
        }

        private int id;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private int passport;

        public DateTime AddTime { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Id { get; set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value) return;

                firstName = value;
                OnPropertyChanged(FirstName);
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value) return;

                lastName = value;
                OnPropertyChanged(LastName);
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (phoneNumber == value) return;

                phoneNumber = value;
                OnPropertyChanged(PhoneNumber);
            }
        }
        public int Passport
        {
            get => passport;
            set
            {
                if (passport == value) return;

                passport = value;
                OnPropertyChanged(Passport.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Account(string firstName, string lastName, string phoneNumber, int passport)
        {
            Id = nextId();
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Passport = passport;
            AddTime = DateTime.Now;
            LastUpdated = DateTime.Now;
        }

        public string ToString(bool access)
        {
            return
                $"{Id}" +
                $"{FirstName}" +
                $"{LastName}" +
                $"{PhoneNumber}" +
                $"{Passport}";
        }

        public bool Equals(Account other)
        {
            return this.Id == other.Id
                && this.FirstName == other.FirstName
                && this.LastName == other.LastName
                && this.PhoneNumber == other.PhoneNumber
                && this.Passport == other.Passport;
        }

        public class SortById : IComparer<Account>
        {
            public int Compare(Account x, Account y)
            {
                Account X = x as Account;
                Account Y = y as Account;

                if (X.Id == Y.Id) return 0;
                else if (X.Id > Y.Id) return 0;
                else return -1;
            }
        }

        public class SortByFirstName : IComparer<Account>
        {
            public int Compare(Account x, Account y)
            {
                Account X = x as Account;
                Account Y = y as Account;

                return string.Compare(X.FirstName, Y.FirstName);
            }
        }

        public class SortByLastName : IComparer<Account>
        {
            public int Compare(Account x, Account y)
            {
                Account X = x as Account;
                Account Y = y as Account;

                return string.Compare(X.LastName, Y.LastName);
            }
        }

        public class SortByPhone : IComparer<Account>
        {
            public int Compare(Account x, Account y)
            {
                Account X = x as Account;
                Account Y = y as Account;

                return string.Compare(X.PhoneNumber, Y.PhoneNumber);
            }
        }
    }
}
