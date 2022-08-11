using BankingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    internal class Repository: IEnumerable
    {
        private readonly ObservableCollection<Account> list = new ObservableCollection<Account>();

        public Repository(string path)
        {
            this.path = path;
        }

        private string path { get; set; }

        public ObservableCollection<Account> GetList()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path).Dispose();
                return new ObservableCollection<Account>();
            }

            using (var reader = File.OpenText(path))
            {
                var result = JsonConvert.DeserializeObject<ObservableCollection<Account>>(reader.ReadToEnd());
                return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
