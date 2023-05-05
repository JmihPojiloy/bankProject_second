using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankProject_C_
{
    public class Bank : IInfo
    {
        private List<Client>? clients;

        public List<Client>? Clients { get { return clients; } }

        public Bank(int numberOfRecords)
        {
            clients = Load(numberOfRecords);
        }

        private List<Client> Load(int numberOfRecords)
        {
            clients = new List<Client>();
            string? name;

            for (int i = 0; i < numberOfRecords; i++)
            {
                name = $"Name_{i} Surname_{i}";
                clients.Add(new Client(i, name, 300m));
            }

            return clients;
        }

        public void Add(string name, decimal sum)
        {
            clients.Add(new Client(this.clients.Count, name, sum));
        }

        public void Remove(int id)
        {
            foreach (var item in this.clients)
            {
                if(item.Id == id)
                {
                    clients.Remove(item);
                }
            }
        }

        public string Transactions(int id, decimal sum, int operation, char type)
        {
            var client = new Client();

            foreach (var item in this.clients)
            {
                if(item.Id == id)
                {
                    client = item;
                }
            }
            try
            {
                switch (operation)
                {
                    case 0:
                        client.Deposit(sum);
                        break;

                    case 1:
                        client.Withdrawal(sum, type);
                        break;

                    case 2:
                        client.Transfer();
                        break;
                }
            }
            catch(Exception ex) 
            { 
                return ex.Message;
            }

            return "Transaction done!";
        }

        public string Info()
        {
            string info = "\nBank clients list";

            foreach (var item in this.clients)
            {
                info += $"\n{item.Info()}";
            }

            return info;
        }
    }
}
