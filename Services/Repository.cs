using BankingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
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
        private readonly BindingList<Account> list = new BindingList<Account>();

        public Repository(string path)
        {
            this.path = path;
        }

        private string path { get; set; }

        public BindingList<Account> GetList()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path).Dispose();
                return new BindingList<Account>();
            }

            using (var reader = File.OpenText(path))
            {
                var result = JsonConvert.DeserializeObject<BindingList<Account>>(reader.ReadToEnd());
                return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
