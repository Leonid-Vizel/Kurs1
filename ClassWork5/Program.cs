using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClassWork5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание #1");
            Num1();
            Console.WriteLine("Задание #2");
            Num2();
            Console.WriteLine("\nЗадание #3");
            Num3();
            Console.WriteLine("Задание #4");
            Num4();
            Console.WriteLine("Задание #5");
            Num5();
            Console.ReadKey();
        }

        private static void Num1()
        {
            List<byte> team1Numbers = new List<byte>();
            List<byte> team2Numbers = new List<byte>();
            byte inputTemp;
            Console.WriteLine("Для завершения ввода чисел - введите любой символ кроме 0-9.");
            Console.WriteLine("Комманда \"Bavarian Beer Bears\" покажите свои числа!");
            while (byte.TryParse(Console.ReadLine(), out inputTemp))
            {
                team1Numbers.Add(inputTemp);
            }
            Console.WriteLine("Комманда \"Scandinavian Schöllers\" покажите свои числа!");
            while (byte.TryParse(Console.ReadLine(), out inputTemp))
            {
                team2Numbers.Add(inputTemp);
            }
            if (team1Numbers.Count(x => x == 5) == team2Numbers.Count(x => x == 5))
            {
                Console.WriteLine("Восславим пиво!(Хорошая концовка)");
                Console.WriteLine("Drinks All Round! Free Beers on Bjorg!");
            }
            else
            {
                Console.WriteLine("Пива не будет, расходимся!(Плохая концовка)");
                Console.WriteLine("Ой, Бьорг - пончик! Ни для кого пива!");
            }
        }

        private static void Num2()
        {
            List<byte> numbers32 = new List<byte>();
            for (byte i = 0; i <= 31; i++)
            {
                numbers32.Add(i);
                numbers32.Add(i);
            }
            Console.WriteLine("Изначальный список:");
            for (int i = 0; i < 64; i++)
            {
                Console.Write($"{numbers32[i]} ");
            }
            Shuffle(ref numbers32);
            Console.WriteLine("\nПеремешанный список:");
            for (int i = 0; i < 64; i++)
            {
                Console.WriteLine(DrawNumber(numbers32[i]));
            }
        }

        private static void Num3()
        {
            string path = "students.txt";
            Console.WriteLine("Добро пожаловать в базу студентов!");
            //Читаю из файла
            Dictionary<string, StudentInfo> students = new Dictionary<string, StudentInfo>();
            string[] readResult = File.ReadAllLines(path);
            Console.WriteLine("Текущий список студентов:");
            foreach (string s in readResult)
            {
                string[] temp = s.Split(' ');
                if (ushort.TryParse(temp[4], out ushort scores) && DateTime.TryParse(temp[2], out DateTime birthday))
                {
                    var stInfo = new StudentInfo(birthday, temp[3], scores);
                    students.Add($"{temp[0]} {temp[1]}", stInfo);
                    Console.WriteLine($"{temp[0]} {temp[1]} {stInfo.ToString()}");
                }
            }
            bool workFlag = true;
            while (workFlag)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("Новый студент");
                Console.WriteLine("Удалить");
                Console.WriteLine("Сортировать");
                Console.WriteLine("Список");
                Console.WriteLine("Стоп(завершить работу)");
                string userRespond = Console.ReadLine().ToLower();
                Console.Clear();
                switch (userRespond)
                {
                    case "новый студент":
                        Console.WriteLine("Введите основные характеристики студента:");
                        Console.Write("Имя и Фамилия через пробел: ");
                        string names = Console.ReadLine();
                        if (!names.Contains(" "))
                        {
                            Console.WriteLine("Введённая строка не содержала пробелов. Поробуйте снова!");
                            continue;
                        }
                        Console.Write("Дата рождения в формате dd.MM.yyyy: ");
                        DateTime birth;
                        if (!DateTime.TryParse(Console.ReadLine(), out birth))
                        {
                            Console.WriteLine("Неверный формат даты. Поробуйте снова!");
                            continue;
                        }
                        Console.Write("Наименование предмета, который сдавал студент: ");
                        string subject = Console.ReadLine();
                        Console.Write("Кол-во баллов, которое набрал абитуриент: ");
                        if (!ushort.TryParse(Console.ReadLine(), out ushort scores))
                        {
                            Console.WriteLine("Неверный формат числа. Поробуйте снова!");
                            continue;
                        }
                        students.Add(names, new StudentInfo(birth, subject, scores));
                        File.AppendAllText(path, $"\n{names} {birth:dd.MM.yyyy} {subject} {scores}");
                        Console.WriteLine("Студент был успешно добавлен в базу!");
                        break;
                    case "удалить":
                        Console.Write("Введите имя и фамилию удаляемого студента через пробел: ");
                        string deleteNames = Console.ReadLine();
                        if (!students.ContainsKey(deleteNames))
                        {
                            Console.WriteLine("Студент с такой фамилией не найден. Поробуйте снова!");
                            continue;
                        }
                        students.Remove(deleteNames);
                        StringBuilder writeString = new StringBuilder();
                        foreach (var sts in students)
                        {
                            writeString.AppendLine($"{sts.Key} {sts.Value.birthday:dd.MM.yyyy} {sts.Value.subject} {sts.Value.scores}\n");
                        }
                        writeString.Remove(writeString.Length - 1, 1);
                        File.WriteAllText(path, writeString.ToString());
                        break;
                    case "сортировать":
                        Console.WriteLine("Текущий список студентов:");
                        foreach (var st in students.OrderBy(x => x.Value.scores))
                        {
                            Console.WriteLine(st.ToString());
                        }
                        Console.WriteLine($"Всего {students.Count}");
                        break;
                    case "стоп":
                        Console.WriteLine("Спасибо за работу!");
                        workFlag = false;
                        break;
                    case "список":
                        Console.WriteLine("Текущий список студентов:");
                        foreach (var st in students)
                        {
                            Console.WriteLine($"'{st.Key}' {st.Value.ToString()}");
                        }
                        Console.WriteLine($"Всего {students.Count}");
                        break;
                }
            }

        }

        private static void Num4()
        {
            string path = "workers.txt";
            List<Worker> queueList = new List<Worker>();
            Queue<Worker> queue = new Queue<Worker>();
            Stack<Table> tables = new Stack<Table>();
            for (short i = 0; i <= 6; i++)
            {
                tables.Push(new Table(i, "White"));
            }
            //Reading
            foreach (string s in File.ReadAllLines(path))
            {
                if (s.StartsWith("None")) continue;
                queueList.Add(new Worker(s));
            }
            //queue movements
            while (queueList.Count(x => !x.analyzed) != 0)
            {
                for (int i = 0; i < queueList.Count; i++)
                {
                    var r = queueList[i];
                    if (r.analyzed) return;
                    int startPosition = queueList.IndexOf(r);
                    if (r.stupidity && r.impudence == 0)
                    {
                        if (startPosition != 0)
                        {
                            var temp = queueList[startPosition];
                            queueList[startPosition] = queueList[startPosition - 1];
                            queueList[startPosition - 1] = temp;
                        }
                    }
                    else if (r.stupidity && r.impudence > 0)
                    {
                        if (startPosition - r.impudence >= 0)
                        {
                            var temp = queueList[startPosition];
                            queueList[startPosition] = queueList[startPosition - 1];
                            queueList[startPosition - 1] = temp;
                        }
                        else
                        {
                            var temp = queueList[startPosition];
                            queueList[startPosition] = queueList[0];
                            queueList[0] = temp;
                        }
                    }
                    r.analyzed = true;
                }
            }
            Console.WriteLine("Очередь после всех телодвижений:");
            for (int i = 0; i < queueList.Count; i++)
            {
                queue.Enqueue(queueList[i]);
                Console.WriteLine(queueList[i].name);
            }
            //table movements
            while (queue.Count > 0)
            {
                var worker = queue.Dequeue();
                if (worker.friend.Equals("None"))
                {
                    if (worker.impudence > 0)
                    {
                        foreach (Table t in tables)
                        {
                            if (t.occupied < 4)
                            {
                                t.TakeASeat(worker);
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (Table t in tables)
                        {
                            if (t.occupied < 3)
                            {
                                t.TakeASeat(worker);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (worker.impudence > 0 && worker.stupidity)
                    {
                        foreach (Table t in tables)
                        {
                            if (t.occupied < 4)
                            {
                                t.TakeASeat(worker);
                                break;
                            }
                        }
                    }
                    else if (worker.stupidity)
                    {
                        foreach (Table t in tables)
                        {
                            if (t.occupied < 3)
                            {
                                t.TakeASeat(worker);
                                break;
                            }
                        }
                    }
                    else if (worker.impudence > 0)
                    {
                        Table friendTable = GetTableByOccupier(worker.friend, tables);
                        if (friendTable == null || friendTable.occupied == 4)
                        {
                            foreach (Table t in tables)
                            {
                                if (t.occupied < 4)
                                {
                                    t.TakeASeat(worker);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            friendTable.TakeASeat(worker);
                        }
                    }
                    else
                    {
                        Table friendTable = GetTableByOccupier(worker.friend, tables);
                        if (friendTable == null || friendTable.occupied >= 3)
                        {
                            foreach (Table t in tables)
                            {
                                if (t.occupied < 3)
                                {
                                    t.TakeASeat(worker);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            friendTable.TakeASeat(worker);
                        }
                    }
                }
            }
            Console.WriteLine("Итоговая рассадка:");
            while (tables.Count > 0)
            {
                Table t = tables.Pop();
                Console.WriteLine($"Стол #{t.ID}({t.color}):");
                foreach (string s in t.occupiers)
                {
                    Console.WriteLine(s);
                }
            }
        }

        private static void Num5()
        {
            Queue<Babka> babkas = new Queue<Babka>();
            Stack<Hospital> hospitals = new Stack<Hospital>();
            List<Babka> LeftCrying = new List<Babka>();
            hospitals.Push(new Hospital("Hospital #1", "Osteoporosis Ateroscalerosis Heanorrhiodes")); //Остеопороз Атероскалероз Геморрой
            hospitals.Push(new Hospital("Hospital #2", "Diabetes Hypertension Hypotesion")); //Диабет Гипертония Гипотония
            hospitals.Push(new Hospital("Hospital #3", "Onkology Alzheimer Clementia")); //Онкология Альцгеймер Деменция
            babkas.Enqueue(new Babka("Виноградова Полина", 91, "Osteoporosis"));
            babkas.Enqueue(new Babka("Матвеева Алина", 84, "Clementia"));
            babkas.Enqueue(new Babka("Коршунова Варвара", 90, "Hypertension"));
            babkas.Enqueue(new Babka("Орлова Мирослава", 78, "Osteoporosis Clementia"));
            babkas.Enqueue(new Babka("Скворцова Дарья", 97, "Onkology Alzheimer"));
            babkas.Enqueue(new Babka("Шарова Мария", 83, "")); //Здоровая
            babkas.Enqueue(new Babka("Белова Василиса", 89, "")); //Здоровая
            babkas.Enqueue(new Babka("Некрасова Ангелина", 98, "Hypotesion"));
            babkas.Enqueue(new Babka("Никольская Стефания", 88, "Ateroscalerosis"));
            babkas.Enqueue(new Babka("Соколова Варвара", 85, "")); //Здоровая
            babkas.Enqueue(new Babka("Белоусова Злата", 88, "Alzheimer Diabetes"));
            babkas.Enqueue(new Babka("Зотова Анастасия", 80, "Clementia"));
            babkas.Enqueue(new Babka("Серова Александра", 89, "Osteoporosis Hypotesion"));
            babkas.Enqueue(new Babka("Прохорова Аиша", 80, "Diabetes"));
            babkas.Enqueue(new Babka("Гордеева Алиса", 82, "Osteoporosis"));
            babkas.Enqueue(new Babka("Иванчук Антонина", 70, "")); //Здоровая
            Console.Write("Хотите добавить бабку(Y/N)? ");
            if (Console.ReadLine().ToUpper().Equals("Y"))
            {
                bool babkaflag = true;
                while (babkaflag)
                {
                    Console.Write("Введите Фамилию и имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите возраст: ");
                    if (!byte.TryParse(Console.ReadLine(), out byte age))
                    {
                        Console.WriteLine("Неверный формат числа, попробуйте снова!");
                        continue;
                    }
                    Console.Write("Введите список болезней через пробел: ");
                    babkas.Enqueue(new Babka(name, age, Console.ReadLine()));
                    Console.WriteLine("Хотите добавить ещё бабку(Y/N)?");
                    babkaflag = Console.ReadLine().ToUpper().Equals("Y");
                }
            }
            Console.Write("Хотите добавить больницу(Y/N)? ");
            if (Console.ReadLine().ToUpper().Equals("Y"))
            {
                bool hospitalFlag = true;
                while (hospitalFlag)
                {
                    Console.Write("Введите название: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите заболевания, которые лечат здесь: ");
                    hospitals.Push(new Hospital(name, Console.ReadLine()));
                    Console.WriteLine("Хотите добавить ещё больницу(Y/N)?");
                    hospitalFlag = Console.ReadLine().ToUpper().Equals("Y");
                }
            }
            while (babkas.Count > 0)
            {
                Babka current = babkas.Dequeue();
                List<Hospital> accepatable = new List<Hospital>();
                if (current.illness.Count > 0)
                {
                    foreach (Hospital host in hospitals.Where(x => x.queue.Count < 5))
                    {
                        int found = 0;
                        foreach (string ill in current.illness)
                        {
                            if (host.cure.Contains(ill))
                            {
                                found++;
                            }
                        }
                        if ((double)found / current.illness.Count >= 0.5D)
                        {
                            accepatable.Add(host);
                        }
                    }
                    if (accepatable.Count == 0)
                    {
                        LeftCrying.Add(current);
                    }
                    else
                    {
                        accepatable.OrderBy(x => x.queue.Count).First().queue.Enqueue(current);
                    }
                }
                else
                {
                    var found = hospitals.Where(x => x.queue.Count < 5).OrderBy(x => x.queue.Count);
                    if (found.Count() > 0)
                    {
                        found.First().queue.Enqueue(current);
                    }
                    else
                    {
                        LeftCrying.Add(current);
                    }
                }
            }
            Console.WriteLine("Госпитали:");
            foreach (Hospital host in hospitals)
            {
                Console.WriteLine(host.ToString());
            }
            Console.Write("Остались плакать:");
            foreach (Babka b in LeftCrying)
            {
                Console.WriteLine(b.ToString());
            }
        }

        #region Num5

        class Babka
        {
            public string name;
            public byte age;
            public List<string> illness;

            public Babka(string name, byte age, string ills)
            {
                this.name = name;
                this.age = age;
                if (ills.Length > 0)
                {
                    illness = ills.Split(' ').ToList();
                }
                else
                {
                    illness = new List<string>();
                }
            }

            public override string ToString()
            {
                return $"Бабка {name}({age})";
            }
        }

        class Hospital
        {
            public string name;
            public List<string> cure;
            public Queue<Babka> queue;
            public Hospital(string name, string ills)
            {
                this.name = name;
                cure = ills.Split(' ').ToList();
                queue = new Queue<Babka>();
            }

            public byte fullness
            {
                get => (byte)Math.Truncate((double)queue.Count / 5 * 100);
            }

            public override string ToString()
            {
                StringBuilder build = new StringBuilder($"Госпиталь '{name}' заполнен на {fullness}%\nВ текущей момент в очереди стоят:\n");
                foreach (Babka b in queue)
                {
                    build.AppendLine(b.ToString());
                }
                return build.ToString();
            }
        }
        #endregion

        #region Num4
        private static Table GetTableByOccupier(string name, Stack<Table> tables)
        {
            foreach (Table t in tables)
            {
                if (t.occupiers.Contains(name)) return t;
            }
            return null;
        }

        class Worker
        {
            public string name;
            public string profession;
            public byte impudence; //наглость
            public bool stupidity;
            public string friend;
            public bool analyzed;

            public Worker(string inputLine)
            {
                string[] input = inputLine.Split(' ');
                name = input[0];
                profession = input[1];
                impudence = 0;
                byte.TryParse(input[2], out impudence);
                stupidity = input[3].Equals("1");
                if (input.Length == 5)
                {
                    friend = input[4];
                }
                else
                {
                    friend = "None";
                }
                analyzed = false;
            }
        }

        class Table
        {
            public Table(short ID, string color)
            {
                this.ID = ID;
                this.color = color;
                places = new Worker[4];
            }

            public short ID;
            public string color;
            private Worker[] places;

            public byte occupied
            {
                get
                {
                    for (byte i = 0; i < 4; i++)
                    {
                        if (places[i] == null) return i;
                    }
                    return 4;
                }
            }

            public string[] occupiers
            {
                get => places.Where(x => x != null).Select(x => x.name).ToArray();
            }

            public void TakeASeat(Worker r)
            {
                if (occupied < 4)
                {
                    places[occupied] = r;
                }
            }
        }
        #endregion

        #region Num3
        struct StudentInfo
        {
            public DateTime birthday;
            public string subject;
            public ushort scores;

            public StudentInfo(DateTime birthday, string subject, ushort scores)
            {
                this.birthday = birthday;
                this.subject = subject;
                this.scores = scores;
            }

            public override string ToString()
            {
                return $"({birthday:dd.MM.yyyy}) сдал предмет {subject} на {scores} балл(ов)";
            }
        }
        #endregion

        #region Num2
        private static void Shuffle(ref List<byte> input)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            byte temp;
            int first, second;
            for (int i = 0; i < 120; i++)
            {
                first = r.Next(64);
                second = r.Next(64);
                temp = input[first];
                input[first] = input[second];
                input[second] = temp;
            }
        }

        private static string GrayscaleImageToASCII(Image img)
        {
            StringBuilder builder = new StringBuilder();
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(img);
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
            catch (Exception exc)
            {
                return $"Ошибка(Image->ASCII): {exc.Message}";
            }
            finally
            {
                bmp.Dispose();
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

        public static string DrawNumber(byte number)
        {
            if (number >= 0 && number <= 9)
            {
                return GrayscaleImageToASCII(Image.FromFile($"images\\{number}.PNG"));
            }
            else if (number > 9)
            {
                string[] firstNum = GrayscaleImageToASCII(Image.FromFile($"images\\{number / 10}.PNG")).Split('\n');
                string[] secondNum = GrayscaleImageToASCII(Image.FromFile($"images\\{number % 10}.PNG")).Split('\n');
                for (int i = 0; i < Math.Min(firstNum.Length, secondNum.Length); i++)
                {
                    firstNum[i] += secondNum[i];
                }
                return string.Join("\n", firstNum);
            }
            else
            {
                return GrayscaleImageToASCII(Image.FromFile($"images\\ERR.PNG"));
            }
        }
        #endregion
    }
}