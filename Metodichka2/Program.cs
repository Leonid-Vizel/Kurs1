using System;

namespace Methodichka2
{
    class Program
    {
        static void Main(string[] args)
        {
            Num11();
            Num12();
            Num13();
            Console.ReadKey();
        }

        public static void Num11()
        {
            try
            {
                Console.WriteLine("Задание №3.1:");
                Console.WriteLine($"Введите тип банковского счёта:\n[{(int)BankType.Current}]{BankType.Current}\n[{(int)BankType.Savings}]{BankType.Savings}");
                int btInt = int.Parse(Console.ReadLine());
                if (btInt < 0 || btInt > 1) throw new Exception("Неправильно выбран тип счёта!");
                BankType bt = (BankType)btInt;
                Console.WriteLine($"Выбранный Вами тип банковского счёта это - \"{bt}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void Num12()
        {
            try
            {
                Console.WriteLine("Задание №3.2:");
                Console.Write("Введите номер банковского счёта: ");
                long ID = long.Parse(Console.ReadLine());
                Console.Write("Введите баланс банковского счёта: ");
                decimal balance = decimal.Parse(Console.ReadLine().Replace(".", ","));
                Bank bankInstance = new Bank(ID, balance);
                Console.WriteLine(bankInstance.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void Num13()
        {
            try
            {
                Console.WriteLine("Задание(ДЗ) №3.1:");
                Console.Write("Введите имя сотрудника: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Введите учреждение где он работает:\n[{(int)Univer.KGU}]{Univer.KGU}\n[{(int)Univer.KAI}]{Univer.KAI}\n[{(int)Univer.KHTI}]{Univer.KHTI}");
                int univer = int.Parse(Console.ReadLine());
                if (univer < 0 || univer > 3) throw new Exception("Направильно выбран номер ВУЗа!");
                Worker worker = new Worker(name, univer);
                Console.WriteLine(worker.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    struct Bank
    {
        public long ID;
        public decimal balance;

        public Bank(long ID, decimal balance)
        {
            this.ID = ID;
            this.balance = balance;
        }

        public override string ToString()
        {
            return $"Банковская информация:\nНомер счёта {ID}\nБаланс: {balance} условных единиц";
            //Если спросят, что за вставки такие {}, то назови это интерполяцией)
        }
    }

    struct Worker
    {
        public string name;
        public Univer univer;

        public Worker(string name, int univer)
        {
            this.name = name;
            this.univer = (Univer)univer;
        }

        public override string ToString()
        {
            return $"Сотрудник {name} работает в {univer}";
        }
    }

    enum Univer { KGU, KAI, KHTI }

    enum BankType { Current, Savings }
}
