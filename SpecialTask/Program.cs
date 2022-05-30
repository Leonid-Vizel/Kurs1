using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Data.SQLite;

namespace SpecialTask
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            List<Visitor> accepted = new List<Visitor>();
            Random r = new Random(DateTime.Now.Millisecond);
            Console.WriteLine("Наcтроки симуляции:");
            BaggageRepository repos = new BaggageRepository(new List<Worker>(), new Queue<Visitor>(), "gun,drug,explosive,radioactive", new List<string>() { "Неплохое хранилище.", "Всё оперативно. Понравилось." }, 10, 100, 30, loadPath:"SpecialTask.db");
            Console.WriteLine(repos.ToString());
            Console.Write("Изменить параметры?(Y/N)");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                bool cycleFlag = true;
                while (cycleFlag)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(repos.ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Выберите параметр для изменения(вводить без скобок):\nМаксимальный вес\nЗапрещённые вещи(Добавить)\nОтзывы(Добавить)\nМаксимальная очередь\nМестоположение\nКол-во ячеек\nОчередь посетителей(Добавить)\nОтвет: ");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "максимальный вес":
                            Console.Write("Введите новую величину максимального веса: ");
                            if (!double.TryParse(Console.ReadLine(),out double inputMaxWeight))
                            {
                                Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                Thread.Sleep(1000);
                                continue;
                            }
                            repos.collector.MaxWeight = inputMaxWeight;
                            break;
                        case "запрещённые вещи":
                            Console.Write("Введите название вещи, которую хотите запретить: ");
                            repos.prohibited.Add(Console.ReadLine().ToLower());
                            break;
                        case "отзывы":
                            Console.Write("Введите новый отзыв: ");
                            repos.reports.Add(Console.ReadLine().ToLower());
                            break;
                        case "максимальная очередь":
                            Console.Write("Введите новую величину максимальноый очереди: ");
                            if (!int.TryParse(Console.ReadLine(), out int inputMaxQueue))
                            {
                                Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                Thread.Sleep(1000);
                                continue;
                            }
                            repos.maxQueue = inputMaxQueue;
                            break;
                        case "местоположение":
                            Console.Write("Введите новый адрес: ");
                            repos.location = Console.ReadLine();
                            break;
                        case "start":
                            cycleFlag = false;
                            break;
                        case "random":
                            for (int i = repos.visitors.Count; i < repos.maxQueue; i++)
                            {
                                long generatedID = GenID(repos.visitors);
                                repos.visitors.Enqueue(new Visitor(generatedID, $"client{i}", (byte)r.Next(1,100), Sex.Alternative, r.Next(100, 50000), r.Next(1,4), new Baggage(generatedID,r.Next(15,45),"white","clothes"), Aim.Give));
                            }
                            break;
                        case "кол-во ячеек":
                            Console.Write("Введите новое кол-во ячеек: ");
                            if (!int.TryParse(Console.ReadLine(), out int inputMaxCells))
                            {
                                Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                Thread.Sleep(1000);
                                continue;
                            }
                            repos.collector.SetAmount(inputMaxCells);
                            break;
                        case "добавить работников":
                            Sex inputWorkerSex;
                            Profession inputProfession;
                            Console.Write("Введите имя нового клиента: ");
                            string inputWorkerName = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            if (!byte.TryParse(Console.ReadLine(), out byte inputWorkerAge))
                            {
                                Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                Thread.Sleep(1000);
                                continue;
                            }
                            Console.Write("Введите пол (Male|Female|TransGender|Alternative(Clown)): ");
                            switch (Console.ReadLine().ToLower())
                            {
                                case "male":
                                    inputWorkerSex = Sex.Man;
                                    break;
                                case "female":
                                    inputWorkerSex = Sex.Woman;
                                    break;
                                case "transgender":
                                    inputWorkerSex = Sex.TransGender;
                                    break;
                                case "clown":
                                case "alternative":
                                default:
                                    inputWorkerSex = Sex.Alternative;
                                    break;
                            }
                            Console.Write("Введите профессию(Кассир/Охраниик): ");
                            switch (Console.ReadLine().ToLower())
                            {
                                case "кассир":
                                    inputProfession = Profession.Cashier;
                                    break;
                                case "охранник":
                                    inputProfession = Profession.Security;
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    continue;
                            }
                            repos.workers.Add(new Worker(GenID(repos.workers),inputWorkerName,inputWorkerAge,inputWorkerSex,inputProfession));
                            Console.Write("Сохранить работника в базу: ");
                            if (Console.ReadLine().ToLower().Equals("Y"))
                            {
                                var worker = repos.workers.Last();
                                using (var connection = new SQLiteConnection($"DataSource='SpecialTask.db';Version=3;"))
                                {
                                    connection.Open();
                                    SQLiteCommand sqCom = connection.CreateCommand();
                                    sqCom.CommandText = $"INSERT INTO Workers (ID,Name,Age,Sex,Profession)VALUES ({worker.ID},'{worker.Name}',{worker.Age},{(int)worker.Sex},{(int)worker.profession});";
                                    sqCom.ExecuteNonQuery();
                                    connection.Close();
                                }
                            }
                            break;
                        case "очередь посетителей":
                            if (repos.visitors.Count >= repos.maxQueue)
                            {
                                Console.WriteLine("Лимит посетителей в очереди достигнут. Увеличьте максимальное количество людей в очереди.");
                                Thread.Sleep(1000);
                                continue;
                            }
                            Sex inputSex;
                            Aim inputAim;
                            Console.Write("Введите имя нового клиента: ");
                            string inputName = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            if (!byte.TryParse(Console.ReadLine(), out byte inputAge))
                            {
                                Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                Thread.Sleep(1000);
                                continue;
                            }
                            Console.Write("Введите кол-во денег с собой: ");
                            if (!int.TryParse(Console.ReadLine(), out int inputCash))
                            {
                                Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                Thread.Sleep(1000);
                                continue;
                            }
                            Console.Write("Введите пол (Male|Female|TransGender|Alternative(Clown)): ");
                            switch(Console.ReadLine().ToLower())
                            {
                                case "male":
                                    inputSex = Sex.Man;
                                    break;
                                case "female":
                                    inputSex = Sex.Woman;
                                    break;
                                case "transgender":
                                    inputSex = Sex.TransGender;
                                    break;
                                case "clown":
                                case "alternative":
                                default:
                                    inputSex = Sex.Alternative;
                                    break;
                            }
                            Console.Write("Введите по какой причине клиент пришёл (Получить/Сдать): ");
                            switch (Console.ReadLine().ToLower())
                            {
                                case "получить":
                                    inputAim = Aim.Take;
                                    break;
                                case "сдать":
                                    inputAim = Aim.Give;
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод! Попробуйте снова.");
                                    Thread.Sleep(1000);
                                    continue;
                            }
                            if (inputAim == Aim.Give)
                            {
                                Console.Write("Введите кол-во дней на которое собираются сдать багаж: ");
                                if (!int.TryParse(Console.ReadLine(), out int inputDays))
                                {
                                    Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                    Thread.Sleep(1000);
                                    continue;
                                }
                                Console.WriteLine("Теперь создадим багаж.");
                                Console.Write("Введите вес: ");
                                if (!double.TryParse(Console.ReadLine(), out double inputBaggageWeight))
                                {
                                    Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                                    Thread.Sleep(1000);
                                    continue;
                                }
                                Console.Write("Введите цвет: ");
                                string inputColor = Console.ReadLine();
                                Console.Write("Введите внутренности багажа через запятую: ");
                                string inputInside = Console.ReadLine().ToLower();
                                var vis = new Visitor(GenID(repos.visitors), inputName, inputAge, inputSex, inputCash, inputDays, null, inputAim);
                                Baggage bag = new Baggage(vis.ID, inputBaggageWeight, inputColor, inputInside);
                                vis.baggage = bag;
                                repos.visitors.Enqueue(vis);
                            }
                            else
                            {
                                repos.visitors.Enqueue(new Visitor(GenID(repos.visitors), inputName, inputAge, inputSex, inputCash, 0, null, inputAim));
                            }
                            Console.Write("Сохранить посетителя в базу(Y/N): ");
                            if (Console.ReadLine().ToLower().Equals("y"))
                            {
                                var visitor = repos.visitors.Last();
                                using (var connection = new SQLiteConnection($"DataSource='SpecialTask.db';Version=3;"))
                                {
                                    connection.Open();
                                    SQLiteCommand sqCom = connection.CreateCommand();
                                    sqCom.CommandText = $"INSERT INTO Visitors (ID,Name,Age,Sex,Cash,Days,Aim) VALUES ({visitor.ID},'{visitor.Name}',{visitor.Age},{(int)visitor.Sex},{visitor.Cash},{visitor.days},{(int)visitor.aim});";
                                    sqCom.ExecuteNonQuery();
                                    connection.Close();
                                }
                                if (visitor.baggage != null)
                                {
                                    using (var connection = new SQLiteConnection($"DataSource='SpecialTask.db';Version=3;"))
                                    {
                                        connection.Open();
                                        SQLiteCommand sqCom = connection.CreateCommand();
                                        sqCom.CommandText = $"INSERT INTO Baggage (OwnerID,Weight,Color,Inside,Cell) VALUES ({visitor.ID},{visitor.baggage.weight},'{visitor.baggage.color}','{string.Join(",", visitor.baggage.inside)}',-1);";
                                        sqCom.ExecuteNonQuery();
                                        connection.Close();
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("Симуляция запущена!");
            Console.WriteLine(GrayscaleImageToASCII(Image.FromFile("facade.png")));
            if (repos.workers.Count(x=>x.profession == Profession.Cashier) == 0 && repos.workers.Count(x => x.profession == Profession.Security) == 0)
            {
                Console.WriteLine("Недостаточно персонала. Должен быть как минимум 1 охраниик и 1 кассир.");
                return;
            }
            while (repos.visitors.Count > 0)
            {
                var visitor = repos.visitors.Dequeue();
                if (repos.ServeClient(visitor))
                {
                    accepted.Add(visitor);
                }
            }
            Console.WriteLine("Все клиенты обслужены. Все данные переданы. Пора подсчитать прибыль.");
            Console.WriteLine($"Всего получено: {repos.profit} RUB|В налоговую уйдёт: {repos.profit*0.155} RUB");
            if (accepted.Count() > 0)
            {
                Console.Write($"Поставить клиентов в очередь обратно на обратную процедуру(Y/N)? ");
                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    accepted.ForEach(x => repos.visitors.Enqueue(x));
                    while (repos.visitors.Count > 0)
                    {
                        repos.ServeClient(repos.visitors.Dequeue());
                    }
                }
            }
            Console.Write("Работа завершена. Перезапустить программу(Y/N)?");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Environment.Exit(0);
            }
            Console.ReadKey();
        }

        public static long GenID(IEnumerable<Person> collection)
        {
            if (collection.Count() == 0) return 0;
            List<Person> fondsFind = collection.OrderBy(x => x.ID).ToList();
            long last = 0;
            for (int i = 1; i < fondsFind.Count; i++)
            {
                if (last + 1 != fondsFind[i].ID)
                {
                    return last + 1;
                }
                else last++;
            }
            return fondsFind[fondsFind.Count - 1].ID + 1;
        }

        private static string GrayscaleImageToASCII(Image img)
        {
            StringBuilder builder = new StringBuilder();
            using (Bitmap bmp = new Bitmap(img))
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color col = bmp.GetPixel(x, y);
                        byte rValue = (byte)((col.R + col.G + col.B) / 3);
                        builder.Append(GetGrayShade(ref rValue));
                    }
                    builder.Append("\n");
                }
                return builder.Remove(builder.Length - 1, 1).ToString();
            }
        }

        private static string GetGrayShade(ref byte redValue)
        {
            if (redValue >= 230)
            {
                //White
                return " ";
            }
            else if (redValue >= 200)
            {
                //LightGray
                return ".";
            }
            else if (redValue >= 180)
            {
                //SlateGry
                return "*";
            }
            else if (redValue >= 160)
            {
                //Gray
                return ":";
            }
            else if (redValue >= 130)
            {
                //Medium
                return "o";
            }
            else if (redValue >= 100)
            {
                //MediumGray
                return "&";
            }
            else if (redValue >= 70)
            {
                //DarkGray
                return "8";
            }
            else if (redValue >= 50)
            {
                //Charcoal
                return "#";
            }
            else
            {
                //Black
                return "@";
            }
        }
    }
}
