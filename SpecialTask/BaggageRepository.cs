using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SpecialTask
{
    public class BaggageRepository
    {
        public string location;
        public BaggageCollector collector;
        public List<string> reports;
        public List<string> prohibited;
        public List<Worker> workers;
        public Queue<Visitor> visitors;
        public int maxQueue = 0;
        public int profit = 0;

        #region delays
        private readonly ushort WeightDelay = 500;
        private readonly ushort QueueShiftDelay = 1000;
        private readonly ushort ExtractBaggageDelay = 2000;
        private readonly ushort CheckAvailibleDelay = 1500;
        private readonly ushort PutBaggageDelay = 2000;
        private readonly ushort DocumentCheckDelay = 500;
        private readonly ushort InsidesCheckDelay = 750;
        private readonly ushort PaymentDelay = 500;
        //Заержки для действий кассира, весов и аппарата для проверки внутренностей багажа.
        #endregion

        public BaggageRepository(List<Worker> wkers, Queue<Visitor> vtors, string prohibiteds, List<string> reports, int maxQueue, int maxCells, double maxWeight, string loadPath, string location = "Ул. Пушкина д. Колотушкина")
        {
            collector = new BaggageCollector(maxCells, maxWeight, loadPath);
            this.maxQueue = maxQueue;
            workers = wkers;
            visitors = vtors;
            this.reports = reports;
            this.location = location;
            if (prohibiteds.Length == 0)
            {
                prohibited = new List<string>();
            }
            else
            {
                prohibited = prohibiteds.Split(',').ToList();
            }
            workers.AddRange(Worker.ReadFromSQLite(loadPath));
            Visitor.LoadFromSQLite(loadPath).ForEach(x => visitors.Enqueue(x));
        }

        public BaggageRepository(List<Worker> wkers, Queue<Visitor> vtors, string prohibiteds, List<string> reports, int maxQueue, int maxCells, double maxWeight, string location = "Ул. Пушкина д. Колотушкина")
        {
            collector = new BaggageCollector(maxCells, maxWeight);
            this.maxQueue = maxQueue;
            workers = wkers;
            visitors = vtors;
            this.reports = reports;
            this.location = location;
            if (prohibiteds.Length == 0)
            {
                prohibited = new List<string>();
            }
            else
            {
                prohibited = prohibiteds.Split(',').ToList();
            }
        }

        private bool CheckBaggageInsides(string[] inside)
        {
            foreach(string ins in prohibited)
            {
                if (inside.Contains(ins))
                {
                    return false;
                }
            }
            return true;
        }

        public bool ServeClient(Visitor vis)
        {
            if (vis.aim == Aim.Give)
            {
                Console.WriteLine($"Обслуживаем клиента {vis.Name}(Отдаёт на хранение)");
                Thread.Sleep(QueueShiftDelay);
                Console.WriteLine("Проверяем докумены...");
                Thread.Sleep(DocumentCheckDelay);
                if (vis.Age < 11)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Извините, не обслуживаем граждан младше 11 лет. Следующий!\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
                Console.WriteLine("Взвешиваем багаж...");
                Thread.Sleep(WeightDelay);
                if (vis.baggage.weight > collector.MaxWeight)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Извините, наш лимит по массе багажа составяет {collector.MaxWeight} кг. Следующий!\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
                Console.WriteLine("Пропустим багаж через аппарат обнаружения запрещённых вещей");
                Thread.Sleep(InsidesCheckDelay);
                if (!CheckBaggageInsides(vis.baggage.inside))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"В вашем багаже обнаружены запрещённые предметы, мы не можем Вас обслужить. Следующий!");
                    Thread.Sleep(750);
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Сообщаем информацию в правоохранительные органы.\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Thread.Sleep(500);
                    return false;
                }
                Console.WriteLine("Багаж соответствует параметрам. Проверяем наличие свободной ячейки хранения...");
                Thread.Sleep(CheckAvailibleDelay);
                if (collector.Availible == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("К сожалению в нашем хранилище не осталось свободных мест, приходите позже. Следущий!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
                Console.WriteLine($"Свободное место найдено! Стоимость хранения - 500 рублей в сутки. С Вас: {500 * vis.days} RUB");
                Thread.Sleep(PaymentDelay);
                if (vis.Cash < 500*vis.days)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("У Вас недостаточно денег. Следующий!\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
                profit += 500 * vis.days;
                vis.Cash -= 500 * vis.days;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Отлично. платёж прошёл! Помещаем ваш багаж на хранение, подождите...");
                Thread.Sleep(PutBaggageDelay);
                collector.FindAndPut(vis.GiveBaggage());
                Console.WriteLine("Ваш багаж положен на хранение. Забрать можно будет только по документам. Хоршего дня! Следующий!\n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.WriteLine($"Обслуживаем клиента {vis.Name}(Получает)");
                Thread.Sleep(QueueShiftDelay);
                Console.WriteLine("Проверяем докумены...");
                Thread.Sleep(DocumentCheckDelay);
                if (vis.Age < 11)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Извините, не обслуживаем граждан младше 11 лет. Следующий!\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
                Console.WriteLine("Проверяем наличие Вашего багажа на складе...");
                Thread.Sleep(CheckAvailibleDelay);
                if (!collector.OwnerIDs.Contains(vis.ID))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы не сдавали багаж в наше хранилище. Возможно Вы ошиблись адресом. Следующий!\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Ваш багаж найден! Подождите немного, сейчас Вам его принесём!");
                Thread.Sleep(ExtractBaggageDelay);
                vis.TakeBaggage(collector.FindAndExtract(vis.ID));
                Console.WriteLine("Ваш багаж возвращён. Хорошего пути! Следующий!\n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            return true;
        }

        public override string ToString()
        {
            return $"Местонахождение: {location}\nМаксимальная длина очереди: {maxQueue} человек\n" +
                $"Максимальный вес: {collector.cells[0].weightLimit} кг\n" +
                $"Ячеек занято: {collector.cells.Length - collector.Availible} шт\n" +
                $"Всего ячеек {collector.cells.Length} из них свободны {collector.Availible}\n" +
                $"Запрещено к хранению: {string.Join(",", prohibited)}\n" +
                $"Отзывы:\n{string.Join("\n", reports)}\n" +
                $"Работники:\n{string.Join("\n", workers.Select(x => x.ToString()))}\n" +
                $"Очередь посетителей:\n{string.Join("\n", visitors.Select(x => x.ToString()))}";
        }
    }
}
