using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClassWork12
{
    [DevelopementInfo("Vizel Leonid","VZprogs")]
    class BankAccount
    {
        private static int IDcounter = 0;
        private List<BankTrasaction> transactions;
        public int ID { get; }
        public decimal Balance { get; private set; }
        public accountType Type { get; private set; }
        public string Holder { get; private set; }
        public BankAccount(string holder, decimal balance = 0, accountType type = accountType.Current)
        {
            ID = IDcounter++;
            Holder = holder;
            Balance = balance;
            Type = type;
            transactions = new List<BankTrasaction>();
        }
        public BankAccount(accountType type)
        {
            ID = IDcounter++;
            Balance = 0;
            Type = type;
            transactions = new List<BankTrasaction>();
        }
        public BankAccount(decimal balance)
        {
            ID = IDcounter++;
            Balance = balance;
            Type = accountType.Current;
            transactions = new List<BankTrasaction>();
        }
        public BankTrasaction this[int index] => transactions[index];
        public override string ToString() => $"Информация о счёте #{ID}\nТип: {Type}\nБаланс: {Balance} условных единиц";
        public bool Withdraw(decimal inputValue)
        {
            if (Balance < inputValue)
            {
                return false;
            }
            else
            {
                Balance -= inputValue;
                transactions.Add(new BankTrasaction(ID, -1, inputValue));
                return true;
            }
        }
        private void Add(decimal inputValue)
        {
            Balance += inputValue;
            transactions.Add(new BankTrasaction(-1, ID, inputValue));
        }
        public bool SendMoney(BankAccount receiver, decimal value)
        {
            if (Balance >= value)
            {
                Balance -= value;
                receiver.Balance += value;
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

        //Для того, чтобы этот метод не был пропущен проделайте следующие манипуляции:
        //1)ПКМ по проекту
        //2)Свойства
        //3)Сборка
        //4)Обозначения условной компиции
        //5)Вписываете туда DEBUG_ACCOUNT
        //6)Наслаждаетесь результатом
        [Conditional("DEBUG_ACCOUNT")]
        public void DumpToScreen() => Console.WriteLine($"{this}\nHashCode:{GetHashCode()}\nКол-во хранящихся транзакций:{transactions.Count}");

        public static bool operator ==(BankAccount a1, BankAccount a2) => ReferenceEquals(a1, a2);

        public static bool operator !=(BankAccount a1, BankAccount a2) => !(a1 == a2);

        public override bool Equals(object obj)
        {
            if (obj is BankAccount)
            {
                BankAccount acc = obj as BankAccount;
                return acc.ID == ID && acc.Balance == Balance && acc.Type == Type;
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