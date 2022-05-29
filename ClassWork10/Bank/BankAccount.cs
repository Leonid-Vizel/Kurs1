using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;

namespace ClassWork7
{
    class BankAccount
    {
        public readonly int ID;
        public decimal balance { get; private set; }
        public accountType type { get; private set; }
        public string holder { get; private set; }
        private List<BankTrasaction> transactions;
        private static int IDcounter = 0;
        public BankAccount(string holder, decimal balance = 0, accountType type = accountType.Current)
        {
            ID = IDcounter++;
            this.holder = holder;
            this.balance = balance;
            this.type = type;
            transactions = new List<BankTrasaction>();
        }
        public BankAccount(accountType type)
        {
            ID = IDcounter++;
            balance = 0;
            this.type = type;
            transactions = new List<BankTrasaction>();
        }
        public BankAccount(decimal balance)
        {
            ID = IDcounter++;
            this.balance = balance;
            type = accountType.Current;
            transactions = new List<BankTrasaction>();
        }

        public BankTrasaction this[int index] => transactions[index];

        public override string ToString() => $"Информация о счёте #{ID}\nТип: {type}\nБаланс: {balance} условных единиц";
        public bool Withdraw(decimal inputValue)
        {
            if (balance < inputValue)
            {
                return false;
            }
            else
            {
                balance -= inputValue;
                transactions.Add(new BankTrasaction(ID, -1, inputValue));
                return true;
            }
        }
        private void Add(decimal inputValue)
        {
            balance += inputValue;
            transactions.Add(new BankTrasaction(-1, ID, inputValue));
        }
        public bool SendMoney(BankAccount receiver, decimal value)
        {
            if (balance >= value)
            {
                balance -= value;
                receiver.balance += value;
                BankTrasaction bt = new BankTrasaction(ID, receiver.ID, value);
                transactions.Add(bt);
                receiver.transactions.Add(bt);
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
        public void Dispose()
        {
            List<string> transactionInfo = new List<string>();
            foreach(var trans in transactions)
            {
                transactionInfo.Add(trans.ToString());
            }
            File.WriteAllLines($"bankAccount{ID}.txt",transactionInfo);
            GC.SuppressFinalize(this);
        }

        public static bool operator ==(BankAccount a1, BankAccount a2) => ReferenceEquals(a1, a2);

        public static bool operator !=(BankAccount a1, BankAccount a2) => !(a1 == a2);

        public override bool Equals(object obj)
        {
            if (obj is BankAccount)
            {
                BankAccount acc = obj as BankAccount;
                return acc.ID == ID && acc.balance == balance && acc.type == type;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode() => ID;
    }

    enum accountType
    {
        Current = 0,
        Savings = 1
    }
}