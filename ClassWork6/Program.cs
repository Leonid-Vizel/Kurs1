using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            Num1();
            Num2();
            Num3();
            Num4();
            Home1();
            IerarchyTask();
            Console.ReadKey();
        }

        private static void Num1()
        {
            Console.WriteLine("Задание #1");
            Console.Write("Введите баланс первого счёта: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal inputBalance))
            {
                Console.WriteLine("Неверный формат числа!");
                return;
            }
            Console.Write("Введите тип первого счёта(сберегательный/текущий): ");
            accountType inputType;
            switch (Console.ReadLine().ToLower())
            {
                case "сберегательный":
                    inputType = accountType.Savings;
                    break;
                case "текущий":
                    inputType = accountType.Current;
                    break;
                default:
                    Console.WriteLine("Неверный формат!");
                    return;
            }
            BankAccount account1 = new BankAccount(inputBalance, inputType);
            Console.WriteLine($"\n{account1}\n");
            Console.Write("Введите баланс второго счёта: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal inputBalance2))
            {
                Console.WriteLine("Неверный формат числа!");
                return;
            }
            Console.Write("Введите тип второго счёта(сберегательный/текущий): ");
            accountType inputType2;
            switch (Console.ReadLine().ToLower())
            {
                case "сберегательный":
                    inputType2 = accountType.Savings;
                    break;
                case "текущий":
                    inputType2 = accountType.Current;
                    break;
                default:
                    Console.WriteLine("Неверный формат!");
                    return;
            }
            BankAccount account2 = new BankAccount(inputBalance2, inputType2);
            Console.WriteLine($"\n{account2}\n");
            Console.WriteLine("Хотите перевести деньги со Второго счёта на Первый(Y/N)?");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                if (!decimal.TryParse(Console.ReadLine(), out decimal inputSendValue))
                {
                    Console.WriteLine("Ошибка: неверный формат числа!");
                    return;
                }
                if (!account1.SendMoney(account2, inputSendValue))
                {
                    Console.WriteLine("Недостаточно средств на счету-отправителе, перевод не выполнен.");
                }
            }
            Console.WriteLine($"\n{account2}\n");
        }

        private static void Num2()
        {
            Console.WriteLine("Задание #2");
            Console.Write("Введите строку для разворота: ");
            Console.WriteLine($"Результат: {ReverseMethod(Console.ReadLine())}");
        }

        private static string ReverseMethod(string input) => string.Join("", input.ToCharArray().Reverse());

        private static void Num3()
        {
            Console.WriteLine("Задание #3");
            Console.Write("Введите имя файла: ");
            string inputPath = Console.ReadLine();
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Такого файла не существует!");
            }
            else
            {
                File.WriteAllText("output.txt", File.ReadAllText(inputPath).ToUpper());
            }
        }

        private static void Num4()
        {
            Console.WriteLine("Задание #4");
            int intInstance = 0;
            BankAccount baInstance = new BankAccount(0, accountType.Current);
            if (isIFormattable(intInstance))
            {
                Console.WriteLine("Int32 is IFormattable!");
            }
            else
            {
                Console.WriteLine("Int32 is not IFormattable!");
            }

            if (isIFormattable(baInstance))
            {
                Console.WriteLine("BankAccount is IFormattable!");
            }
            else
            {
                Console.WriteLine("BankAccount is not IFormattable!");
            }
        }

        private static bool isIFormattable(object inputObj) => inputObj is IFormattable;

        private static void Home1()
        {
            Console.WriteLine("Задание #5");
            if (File.Exists("num5.txt"))
            {
                string[] inputArray = File.ReadAllLines("num5.txt");
                List<string> emails = new List<string>();
                for (int i = 0; i < inputArray.Length; i++)
                {
                    emails.Add(SearchMail(ref inputArray[i]));
                }
                Console.Write("Введите путь для сохранения: ");
                File.WriteAllLines(Console.ReadLine(), emails);
                Console.WriteLine("Сохранено!");
            }
            else
            {
                Console.WriteLine("Входной фал не обнаружен!");
            }
        }

        private static string SearchMail(ref string s)
        {
            string[] splitArray = s.Split('#');
            if (splitArray.Length >= 2)
            {
                return splitArray[1];
            }
            else
            {
                return "";
            }
        }

        private static void Home2()
        {
            Console.WriteLine("Задание #6");
            Song[] songArray = new Song[4];
            Song temp = null;
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Введите песню #{i + 1} по формату ИМЯ ИСПОЛНИТЕЛЬ: ");
                temp = Song.Parse(Console.ReadLine());
                if (temp != null)
                {
                    songArray[i] = temp;
                }
                else
                {
                    songArray[i] = Song.Default;
                    Console.WriteLine("Неверный формат ввода!");
                }
                songArray[i].SetPrev(songArray.Last());
            }

            Console.WriteLine($"Сравнение первых двух песен вернёт:{songArray[0].Equals(new Worker("", WorkerType.controller))}");
        }

        private static void IerarchyTask()
        {
            Console.WriteLine("Задание #7");
            Worker Orkady = new Worker("Оркадий", WorkerType.controller,
                new Worker("Володя", WorkerType.controller,
                    new Worker("Сергей", WorkerType.controllerProgrammer,
                            new Worker("Ляйсан", WorkerType.controllerProgrammer, new Worker("Дина", WorkerType.programmer),
                                                                                        new Worker("Марат", WorkerType.programmer),
                                                                                        new Worker("Ильдар", WorkerType.programmer),
                                                                                        new Worker("Антон", WorkerType.programmer))),
                    new Worker("Ильшат", WorkerType.controllerAdmin,
                            new Worker("Иваныч", WorkerType.controllerAdmin, new Worker("Илья", WorkerType.sysAdmin),
                                                                                        new Worker("Витя", WorkerType.sysAdmin),
                                                                                        new Worker("Женя", WorkerType.sysAdmin)))));
            Orkady.Ask(new WorkerTask("ТЕСТ#1", TaskType.ForProgrammers));
            Orkady.Ask(new WorkerTask("ТЕСТ#2", TaskType.ForProgrammers));
            Orkady.Ask(new WorkerTask("ТЕСТ#3", TaskType.ForSysAdmins));
            Orkady.Ask(new WorkerTask("ТЕСТ#4", TaskType.ForSysAdmins));
            Console.Write("Хотите ещё послать задания? (Y/N): ");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Список работников:");
                Worker.Existingworkers.ForEach(x => Console.WriteLine(x));
                Console.WriteLine("Выберите действие(введите номер):\n[1]Передать задание(от одного к другому)\n[2]Распределить задание\nОтвет: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите ID отправителя: ");
                        if (!int.TryParse(Console.ReadLine(), out int inputSender))
                        {
                            Console.WriteLine("Неверный формат. Перезапустите программу и попробуйте снова!");
                            return;
                        }
                        if (!Worker.Existingworkers.Select(x => x.GetID()).Contains(inputSender))
                        {
                            Console.WriteLine("Отправитель с таким ID не найден!");
                            return;
                        }
                        Console.Write("Введите ID получателя: ");
                        if (!int.TryParse(Console.ReadLine(), out int inputReceiver))
                        {
                            Console.WriteLine("Неверный формат. Перезапустите программу и попробуйте снова!");
                            return;
                        }
                        if (!Worker.Existingworkers.Select(x => x.GetID()).Contains(inputReceiver))
                        {
                            Console.WriteLine("Получатель с таким ID не найден!");
                            return;
                        }
                        Worker send = Worker.GetByID(inputSender);
                        Worker receive = Worker.GetByID(inputReceiver);
                        if (send.Equals(receive))
                        {
                            Console.WriteLine("Самому себе задание дать можно!");
                        }
                        else if (send.GetLower().Contains(receive))
                        {
                            Console.WriteLine($"{send.GetName()} может дать задание {receive.GetName()} напрямую так как последний является его подчинённым!");
                        }
                        else
                        {
                            Console.WriteLine($"{send.GetName()} не может дать задание {receive.GetName()} напрямую так как последний является его подчинённым!");
                        }
                        break;
                    case "2":
                        Console.Write("Введите ID отправителя: ");
                        if (!int.TryParse(Console.ReadLine(), out int inputAsker))
                        {
                            Console.WriteLine("Неверный формат. Перезапустите программу и попробуйте снова!");
                            return;
                        }
                        if (!Worker.Existingworkers.Select(x => x.GetID()).Contains(inputAsker))
                        {
                            Console.WriteLine("Отправитель с таким ID не найден!");
                            return;
                        }
                        Worker asker = Worker.GetByID(inputAsker);
                        Console.Write("Введите название задания: ");
                        string inputTaskName = Console.ReadLine();
                        TaskType inputTaskType = TaskType.ForProgrammers;
                        Console.Write("Введите спецификацию задания:\n[PROGA] - Для программистов\n[ADMIN] - Для администраторов\nОтвет: ");
                        switch (Console.ReadLine().ToUpper())
                        {
                            case "PROGA":
                                inputTaskType = TaskType.ForProgrammers;
                                break;
                            case "ADMIN":
                                inputTaskType = TaskType.ForSysAdmins;
                                break;
                        }
                        asker.Ask(new WorkerTask(inputTaskName, inputTaskType));
                        break;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        return;
                }
            }
            else
            {
                Console.WriteLine("Алгоритм закончил свою работу!");
            }
        }
    }
}
