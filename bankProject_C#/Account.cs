using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankProject_C_
{
    public abstract class Account
    {
        protected char type;

        protected decimal balance;

        public char Type { get { return type; } }

        public decimal Balance { get { return balance; } }
        
        public Account(decimal balance)
        {
            this.balance = balance;
        }

        public virtual void Deposit(decimal amount)
        {
            this.balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if(this.balance - amount < 0)
            {
                throw new Exception("Not enought money!");
            }
            this.balance -= amount;
        }

        public static Account operator+(Account a, Account b)
        {
            a.balance += b.balance;
            b.balance = 0;
            return a;
        }
    }

    public class SimpleAcc : Account
    {
        public SimpleAcc(decimal balance):base(balance)
        {
            this.type = 'S';
        }
    }

    public class CreditAcc : Account
    {
        private decimal credit;

        public decimal Credit { get { return credit; } }

        public CreditAcc(decimal balance, decimal credit):base(balance)
        {
            this.type = 'C';
            this.credit = credit;
        }

        public override void Withdraw(decimal amount)
        {
            if((this.balance+this.credit)-amount < 0)
            {
                throw new Exception("Not enought money!");
            }
            if(amount > this.balance)
            {
                this.balance -= amount;
                this.credit += this.balance;
                this.balance = 0;
            }
            this.balance -= amount;
        }
    }
}
