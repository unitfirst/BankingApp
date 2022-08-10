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
                        Account account = new Account(field[0], field[1], field[2], field[3]);

                        list.Add(account);
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
