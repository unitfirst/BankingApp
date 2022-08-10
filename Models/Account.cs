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

        public DateTime AddTime { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
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
        public string Passport
        {
            get => passport;
            set
            {
                if (passport == value) return;

                passport = value;
                OnPropertyChanged(Passport);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Account(DateTime addTime, DateTime lastUpdated, int id, string firstName, string secondName, string lastName, string phoneNumber, string passport, bool isNew)
        {
            AddTime = addTime;
            LastUpdated = lastUpdated;
            Id = nextId();
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Passport = passport;
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
    }
}
