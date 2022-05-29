using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricsLib
{
    public class BankAccountFabric
    {
        List<BankAccount> accounts = new List<BankAccount>();
        //List - тоже можно отнести к Хеш таблице так как
        //Хеш-табли́ца — это структура данных, реализующая интерфейс ассоциативного массива,
        //а именно, она позволяет хранить пары (ключ, значение) и выполнять три операции: операцию добавления новой пары, операцию поиска и операцию удаления пары по ключу
        public BankAccountFabric() => accounts = new List<BankAccount>();

        public SberBankAccount CreateSberAccount(decimal balance, accountType type)
        {
            if (balance < 0)
            {
                return null;
            }
            else if ((int)type != 0 && (int)type != 1)
            {
                return null;
            }
            else
            {
                SberBankAccount bankAccount = new SberBankAccount(balance, type);
                accounts.Add(bankAccount);
                return bankAccount;
            } 
        }

        public TinkoffBankAccount CreateTinkoffAccount(decimal balance, accountType type)
        {
            if (balance < 0)
            {
                return null;
            }
            else if ((int)type != 0 && (int)type != 1)
            {
                return null;
            }
            else
            {
                TinkoffBankAccount bankAccount = new TinkoffBankAccount(balance, type);
                accounts.Add(bankAccount);
                return bankAccount;
            }
        }

        public RocketBankAccount CreateRocketAccount(decimal balance, accountType type)
        {
            if (balance < 0)
            {
                return null;
            }
            else if ((int)type != 0 && (int)type != 1)
            {
                return null;
            }
            else
            {
                RocketBankAccount bankAccount = new RocketBankAccount(balance, type);
                accounts.Add(bankAccount);
                return bankAccount;
            }
        }

        public bool CloseAccount(long accID)
        {
            BankAccount bankAccount = accounts.FirstOrDefault(x => x.ID == accID);
            if (bankAccount != null)
            {
                return accounts.Remove(bankAccount);
            }
            else
            {
                return false;
            }
        }

        public bool CloseAccount(BankAccount acc) => accounts.Remove(acc);

        public override string ToString() => $"Аккаунтов запомнено: {accounts.Count}";
    }
}
