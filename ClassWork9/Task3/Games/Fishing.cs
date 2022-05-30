using System;

namespace ClassWork9
{
    class Fishing : IGame
    {
        private Random rnd;
        public readonly int fishWin;
        public int attempts => fishWin + fishWin/2;
        public Fishing(int fishWin)
        {
            rnd = new Random(DateTime.Now.Millisecond);
            this.fishWin = fishWin;
        }
        public string name => "Рыбалка";

        public int Play(Member mem)
        {
            int needed;
            int fichFound = 0;
            for (int i = 0; i < attempts; i++)
            {
                needed = rnd.Next(0, 11) + rnd.Next(0, 11);
                if (needed < mem.luck + mem.skill)
                {
                    fichFound++;
                }
            }
            if (fichFound >= fishWin)
            {
                mem.EarnPoints(5);
                Console.WriteLine($"Игрок {mem.name} поймал {fichFound} рыб(у) (Для победы требуется {fishWin}) и заработал 5 очков своей команде!");
                return 5;
            }
            else
            {
                Console.WriteLine($"Игрок {mem.name} поймал {fichFound} рыб(у) (Для победы требуется {fishWin}) и заработал 0 очков своей команде!");
                return 0; 
            }
        }
    }
}
