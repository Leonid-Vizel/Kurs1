using System;
using System.Drawing;

namespace ClassWork8
{
    class Program
    {
        private static void Main()
        {
            bool cycleFlag = true;
            while (cycleFlag)
            {
                Console.WriteLine("Ввдите номер задания:");
                if (byte.TryParse(Console.ReadLine(), out byte inputNum))
                {
                    switch(inputNum)
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
                    }
                }
                Console.Write("Завершить работу? ");
                cycleFlag = !Console.ReadLine().ToUpper().Equals("Y");
            }
            Console.ReadKey();
        }

        private static void Task1()
        {
            ACipher aCipher = new ACipher();
            BCipher bCipher = new BCipher();
            Console.Write("Введите исходную строку: ");
            string input = Console.ReadLine();
            string aEncode = aCipher.encode(input);
            string bEncode = bCipher.encode(input);
            Console.WriteLine($"Шифр А: {aEncode}");
            Console.WriteLine($"Шифр Б: {bEncode}");
            Console.WriteLine($"Расшифровка А: {aCipher.decode(aEncode)}");
            Console.WriteLine($"Расшифровка Б: {bCipher.decode(bEncode)}");
        }

        private static void Task2()
        {
            Point p = new Point(10, 10, Color.Red, true);
            Circle c = new Circle(10, 10, 10, Color.Red, true);
            Rectangle r = new Rectangle(10, 10, 10, 20, Color.Red, true);
            Console.WriteLine($"Инфо1: {p.status}");
            Console.WriteLine($"Инфо2: {c.status}");
            Console.WriteLine($"Инфо3: {r.status}");
        }

        private static void Task3()
        {
            BigRace race = new BigRace()
                .AddGame(new Beach())       //
                .AddGame(new Fishing(5))    //Ловля рыбы
                .AddGame(new Hill(10))      //Проверка скиллов
                .AddGame(new Mousetrap(15)) //Проверка удачи
                .AddGame(new MyGame())      //
                .AddGame(new Postman())     //
                .AddGame(new Sea())         //
                .AddMember(new Member("Россиянин1", Team.Russia))
                .AddMember(new Member("Россиянин2", Team.Russia))
                .AddMember(new Member("Украинец1", Team.Ukraine))
                .AddMember(new Member("Украинец2", Team.Ukraine))
                .AddMember(new Member("Китаец1", Team.China))
                .AddMember(new Member("Китаец2", Team.China))
                .AddMember(new Member("Француз1", Team.France))
                .AddMember(new Member("Француз2", Team.France));
            race.StartGame();
        }
    }
}
