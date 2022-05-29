using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FabricsLib
{
    public abstract class BankAccount
    {
        public readonly long ID;
        private decimal balance;
        private accountType type;
        private Queue<BankTrasaction> transactions;
        private static long IDcounter = 0;
        internal BankAccount(decimal balance = 0, accountType type = accountType.Current)
        {
            ID = IDcounter++;
            this.balance = balance;
            this.type = type;
            transactions = new Queue<BankTrasaction>();
        }

        internal BankAccount(accountType type)
        {
            ID = IDcounter++;
            balance = 0;
            this.type = type;
            transactions = new Queue<BankTrasaction>();
        }

        internal BankAccount(decimal balance)
        {
            ID = IDcounter++;
            this.balance = balance;
            type = accountType.Current;
            transactions = new Queue<BankTrasaction>();
        }
        public override string ToString() => $"Информация о счёте #{ID}\nТип: {type}\nБаланс: {balance} условных единиц";
        public decimal GetBalance() => balance;
        public accountType GetAccType() => type;
        public bool Withdraw(decimal inputValue)
        {
            if (balance < inputValue)
            {
                return false;
            }
            else
            {
                balance -= inputValue;
                transactions.Enqueue(new BankTrasaction(ID, -1, inputValue));
                return true;
            }
        }
        private void Add(decimal inputValue)
        {
            balance += inputValue;
            transactions.Enqueue(new BankTrasaction(-1, ID, inputValue));
        }
        public bool SendMoney(BankAccount receiver, decimal value)
        {
            if (balance >= value)
            {
                balance -= value;
                receiver.balance += value;
                BankTrasaction bt = new BankTrasaction(ID, receiver.ID, value);
                transactions.Enqueue(bt);
                receiver.transactions.Enqueue(bt);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<BankTrasaction> GetTransactions() => new List<BankTrasaction>(transactions);
        //Делает копию, поэтому изменения приватной очереди невозможно будет осуществить.
        //Ссылки на сами транзакции остаюься такими же, однако все поля в них readonly, поэтому такая передача безопасна
    }

    public enum accountType
    {
        Current = 0,
        Savings = 1
    }
}