using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankProject_C_
{
    public class Client : IInfo
    {
        private string id;

        private string name;

        private string surname;

        private List<Account> accounts;

        public Client(string name, decimal balance)
        {
            Load(name, balance);
        }

        private void Load(string name, decimal balance)
        {

        }
        public void Info()
        {
            throw new NotImplementedException();
        }
    }
}
