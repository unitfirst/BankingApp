using BankingApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    internal class Repository: IEnumerable<Account>
    {
        private readonly List<Account> _list = new List<Account>();

        public Repository(string path)
        {
            Path = path;
        }

        private string Path { get; set; }

        public IEnumerator<Account> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public List<Account> GetList()
        {
            if (Path != null)
            {
                using (var file = new StreamReader(Path))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var field = line.Split(',');
                        var account = new Account
                        {
                            Id = int.Parse(field[0]),
                            FirstName = field[1],
                            LastName = field[2],
                            PhoneNumber = field[4],
                            Passport = field[5]
                        };

                        _list.Add(account);
                    }

                    file.Close();
                } 

            }
            else
            {
                var text = "This, path, is, not, correct";
                File.WriteAllText(Path, text);

                Console.WriteLine("File is not correct.");
            }

            return _list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
