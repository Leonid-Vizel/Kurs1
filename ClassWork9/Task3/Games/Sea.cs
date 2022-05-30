using System;

namespace ClassWork9
{
    class Sea : IGame
    {
        public Sea() {/*Nothing*/}
        public string name => "Море";

        public int Play(Member mem)
        {
            if (mem.luck > 4)
            {
                mem.EarnPoints(2);
                Console.WriteLine($"Игрок {mem.name} после заплыва на бойдарках вернулся целым и невредимым. Он зарабатывает 2 очка совей команде!");
                return 2;
            }
            else
            {
                Console.WriteLine($"Игрок {mem.name} после заплыва вернулся без бойдарки. Он зарабатывает 0 очков совей команде!");
                return 0;
            }
        }
    }
}
