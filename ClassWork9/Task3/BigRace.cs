using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassWork9
{
    class BigRace
    {
        private List<IGame> games;
        private List<Member> members;
        public BigRace()
        {
            games = new List<IGame>();
            members = new List<Member>();
        }

        public void StartGame()
        {
            games = games.Distinct().ToList();
            members = members.Distinct().ToList();
            if (members.Select(x=>x.team).Distinct().Count() == 4)
            {
                if (games.Count >= 6)
                {
                    Console.WriteLine("Большие Гонки объявлются открытыми!");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("В этому году Россию представляют:");
                    Console.WriteLine(string.Join("\n", members.Where(x => x.team == Team.Russia).Select(x => $"{x.name}(Удача:{x.luck}, Скилл: {x.skill})")));
                    Console.WriteLine("В этому году Украину представляют:");
                    Console.WriteLine(string.Join("\n", members.Where(x => x.team == Team.Ukraine).Select(x => $"{x.name}(Удача:{x.luck}, Скилл: {x.skill})")));
                    Console.WriteLine("В этому году Францию представляют:");
                    Console.WriteLine(string.Join("\n", members.Where(x => x.team == Team.France).Select(x => $"{x.name}(Удача:{x.luck}, Скилл: {x.skill})")));
                    Console.WriteLine("В этому году Китай представляют:");
                    Console.WriteLine(string.Join("\n", members.Where(x => x.team == Team.China).Select(x => $"{x.name}(Удача:{x.luck}, Скилл: {x.skill})")));
                    SuffleLimitGames();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Участники будут играть в игры:");
                    Console.WriteLine(string.Join("\n", games.Select(x=>x.name)));
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Игры начинаются!");
                    foreach(IGame game in games)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Текущая игра: {game.name}");
                        foreach(Member mem in members)
                        {
                            switch(mem.team)
                            {
                                case Team.Russia:
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    break;
                                case Team.Ukraine:
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    break;
                                case Team.China:
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    break;
                                case Team.France:
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                            }
                            game.Play(mem);
                        }
                    }
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Все команды притихли и ждут окончательного ответа жюри!");
                    Console.WriteLine("Побеждает...");
                    Console.WriteLine("*Барабанная дробь*");
                    var t = members.Select(x => (x.team, x.Points)).GroupBy(x => x.team);
                    long maxAmount = 0;
                    Team Winner = Team.Russia;
                    for (int i = 0; i < 4; i++)
                    {
                        long points = members.Where(x => x.team == (Team)i).Sum(x => x.Points);
                        if (points > maxAmount)
                        {
                            Winner = (Team)i;
                            maxAmount = points;
                        }
                    }
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{Winner}!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("В этом году недостаточно игр было придумано. Большие Гонки не могут быть открыты!");
                }
            }
            else
            {
                Console.WriteLine("В этом году недостаточно человек приехало а соревнование. Большие Гонки не могут быть открыты!");
            }
        }

        public BigRace AddGame(IGame game)
        {
            games.Add(game);
            return this;
        }

        public BigRace AddMember(Member mem)
        {
            members.Add(mem);
            return this;
        }

        private void SuffleLimitGames()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int index1, index2;
            IGame temp;
            for (int i = 0; i < 5 * games.Count; i++)
            {
                index1 = rnd.Next(0, games.Count);
                index2 = rnd.Next(0, games.Count);
                temp = games[index1];
                games[index1] = games[index2];
                games[index2] = temp;
            }
            while (games.Count > 6)
            {
                games.RemoveAt(games.Count - 1);
            }
        }
    }
}
