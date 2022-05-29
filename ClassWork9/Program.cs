using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using FabricsLib;

namespace ClassWork9
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cycleFlag = true;
            while (cycleFlag)
            {
                Console.Clear();
                Console.Write("Ввдите номер задания: ");
                if (byte.TryParse(Console.ReadLine(), out byte inputNum))
                {
                    switch (inputNum)
                    {
                        case 1:
                            Task1();
                            break;
                        case 2:
                            Task2();
                            break;
                        case 3:
                            Task3();
                            break;
                        case 4:
                            Task4();
                            break;
                        case 5:
                            Task5();
                            break;
                    }
                }
                Console.Write("Завершить работу? ");
                cycleFlag = Console.ReadLine().ToUpper().Equals("N");
            }
        }

        private static void Task1()
        {
            BankAccountFabric fabric = new BankAccountFabric();
            Console.WriteLine(fabric.ToString());
            SberBankAccount acc = fabric.CreateSberAccount(100,accountType.Current);
            Console.WriteLine(acc.ToString());
            Console.WriteLine(fabric.ToString());
            Console.WriteLine(fabric.CloseAccount(acc));
            Console.WriteLine(fabric.ToString());
        }
        private static void Task2()
        {
            BankAccountFabric fabric1 = new BankAccountFabric();
            BankAccountFabric fabric2 = new BankAccountFabric();
            RocketBankAccount acc1 = fabric1.CreateRocketAccount(100, accountType.Current);
            SberBankAccount acc2 = fabric2.CreateSberAccount(200, accountType.Current);
            Console.WriteLine(acc1.ToString());
            Console.WriteLine(acc2.ToString());
            Console.WriteLine(fabric1.ToString());
            Console.WriteLine(fabric1.CloseAccount(acc2));
            Console.WriteLine(fabric1.ToString());
        }
        private static void Task3()
        {
            IBuilding build1 = BuildingFabric.CreateBrickBuilding(20,4,60,1);
            build1.Build();
            IBuilding build2 = BuildingFabric.CreateWoodenBuilding(10, 2, 25, 2);
            build2.Build();
            build2.Inhabitate();
            Console.WriteLine(BuildingFabric.GetInfo());
            Console.WriteLine("\n\n\n");
            BuildingFabric.Destruct(0);
            Console.WriteLine(BuildingFabric.GetInfo());
        }
        private static void Task4()
        {
            Console.Write("Что разыгрываете: ");
            string thing = Console.ReadLine();
            Console.Write("Количество: ");
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                Console.WriteLine("Неверный формат ввода!");
                return;
            }
            List<Student> studs = Student.ReadAll("students.txt");
            List<Student> lottery = new List<Student>();
            foreach(Student stud in studs)
            {
                for (int n = 0; n < stud.luckAmount; n++)
                {
                    lottery.Add(stud);
                }
            }
            Suffle(lottery);
            Random rnd = new Random(DateTime.Now.Millisecond);
            while (amount > 0 && lottery.Any(x=>x.tickets <= amount))
            {
                Student winner = lottery[rnd.Next(0, lottery.Count)];
                if (winner.tickets <= amount)
                {
                    amount -= winner.tickets;
                    lottery.RemoveAll(x=>x == winner);
                    winner.ShiftWins(true);
                    Console.WriteLine($"{winner.FullName} из группы {winner.group} выигрывает {winner.tickets} билетов на '{thing}'");
                    File.AppendAllText("reports.txt", $"{DateTime.Now:dd.MM.yyyy}; {thing}:{winner.tickets}; {winner.FullName} {winner.group}\n");
                }
            }
            lottery.ForEach(x => x.ShiftWins(false));
            File.WriteAllLines("students.txt",studs.Select(x=>x.SaveString));
        }
        private static void Task5()
        {
            _Application excel = new Application();
            Workbook wb = excel.Workbooks.Open($"{Environment.CurrentDirectory}\\input.xlsx");
            Worksheet ws = wb.Worksheets[1];
            Console.WriteLine("Opened input");
            object[,] readRange = ws.Range["A2", "B10"].Value2;
            Dictionary<string, string> illcure = new Dictionary<string, string>();
            for (int i = 1; i <= readRange.GetLength(0); i++)
            {
                illcure.Add(readRange[i, 1].ToString().ToLower(), readRange[i, 2].ToString());
            }
            Console.WriteLine("Reading result:");
            foreach(var k in illcure)
            {
                Console.WriteLine($"{k.Key}->{k.Value}");
            }
            wb.Close();
            Console.WriteLine("Closed input");
            wb = excel.Workbooks.Open($"{Environment.CurrentDirectory}\\output.xlsx");
            ws = wb.Worksheets[1];
            Console.WriteLine("Opened output");
            readRange = ws.Range["G2", "G35"].Value2;
            for (int i = 1; i <= readRange.Length; i++)
            {
                string readString = readRange[i,1].ToString().ToLower();
                foreach (var pair in illcure)
                {
                    if (readString.Contains(pair.Key))
                    {
                        readRange[i,1] = pair.Value;
                        break;
                    }
                }
            }
            ws.Range["G2", "G35"].Value2 = readRange;
            Console.WriteLine("Written output");
            wb.Save();
            Console.WriteLine("Saved output");
            wb.Close();
            excel.Quit();
            Console.WriteLine("Closed output");
        }

        private static void Suffle(List<Student> list)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int index1, index2;
            Student temp;
            for (int i = 0; i < 5 * list.Count; i++)
            {
                index1 = rnd.Next(0, list.Count);
                index2 = rnd.Next(0, list.Count);
                temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }
        }
    }
}
