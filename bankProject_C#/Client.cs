using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Класс клиент реализует работу со счетамию При вызове конструктора
    вызывает функцию начальной настройки. Наследует интерфейс и реализует
    его функцию показа информации.
 */

namespace bankProject_C_
{
    public class Client : IInfo
    {
        private int id;

        private string? name;

        private string? surname;

        private List<Account>? accounts;

        public int Id { get { return id; } }

        public string? Name { get { return name; } }

        public string? Surname { get { return surname; } }

        public List<Account>? Accounts { get { return accounts; } }

        public Client() { }

        public Client(int id, string name, decimal balance)
        {
            this.id = id;
            Load(name, balance);
        }

        private void Load(string name, decimal balance)
        {
            string[] words = name.Split(new char[] { ' ', ',', ':', ';' });
            this.name = words[0];
            this.surname = words[1];

            this.accounts = new List<Account>();
            this.accounts.Add(new SimpleAcc(balance));
            this.accounts.Add(new CreditAcc(balance, 200m));
        }

        public void Deposit(decimal amount)
        {
            foreach(var acc in this.accounts)
            {
                if (acc is SimpleAcc)
                {
                    acc.Deposit(amount);
                }
            }
        }

        public void Withdrawal(decimal amount, char type)
        {
            foreach(var acc in this.accounts)
            {
                if(acc.Type == type)
                {
                    acc.Withdraw(amount);
                }
            }
        }

        public void Transfer()
        {
            Account result =  accounts[1] + accounts[0];
            accounts[1] = result;
        }

        public string Info()
        {
            string info = $"ID {this.id} " +
                          $"Name {this.name} " +
                          $"Surname {this.surname} " +
                          $"\nAccounts:";

            foreach(var acc in this.accounts)
            {
                info += $"\nType {acc.Type} Balance {acc.Balance}";
                if (acc is CreditAcc)
                {
                    info += $"\nCredit {(acc as CreditAcc).Credit}";
                }  
            }

            return info;
        }
    }
}
