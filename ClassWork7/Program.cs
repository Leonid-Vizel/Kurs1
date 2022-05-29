using System;
using System.Threading;

namespace ClassWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Домашняя работы была достаточно простой, кроме TaskManager, поэтому протестировал все через одно задание.");
            Nums();
            Console.WriteLine("Проверьте папку решения.\nНажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }

        private static void Nums()
        {
            BankAccount acc1 = new BankAccount();
            BankAccount acc2 = new BankAccount(200);
            acc2.SendMoney(acc1, 75);
            acc2.SendMoney(acc1, 60);
            Thread.Sleep(1000);
            acc2.SendMoney(acc1, 15);
            Thread.Sleep(123);
            acc2.SendMoney(acc1, 50);
            acc1.Dispose();
            acc2.Dispose();
        }
    }
}
