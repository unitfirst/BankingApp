using BankingApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    internal class Repository: IEnumerable<Account>
    {
        private readonly List<Account> list = new List<Account>();

        public Repository(string path)
        {
            this.path = path;
        }

        private string path { get; set; }

        public IEnumerator<Account> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public List<Account> GetList()
        {
            if (path != null)
            {
                using (var file = new StreamReader(path))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var field = line.Split(',');
                        Account account = new Account
                        {
                            Id = Convert.ToInt32(field[0]),
                            FirstName = field[1],
                            LastName = field[2],
                            PhoneNumber = field[3],
                            Passport = Convert.ToInt32(field[4])
                        };

                        list.Add(account);
                        Debug.WriteLine(list);
                    }

                    file.Close();
                } 

            }
            else
            {
                var text = "This, path, is, not, correct";
                File.WriteAllText(path, text);

                Console.WriteLine("File is not correct.");
            }

            return list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
