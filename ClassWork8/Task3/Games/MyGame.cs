using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork8
{
    class MyGame : IGame
    {
        public MyGame() {/*Nothing*/}
        public string name => "Прога";

        public int Play(Member mem)
        {
            if (mem.skill > 7)
            {
                mem.EarnPoints(2);
                Console.WriteLine($"Игрок {mem.name} написал великолепную программу. Он зарабатывает 4 очка совей команде!");
                return 4;
            }
            else if (mem.skill > 4)
            {
                mem.EarnPoints(2);
                Console.WriteLine($"Игрок {mem.name} написал средненькую программу. Он зарабатывает 1 очко совей команде!");
                return 1;
            }
            else
            {
                Console.WriteLine($"Игрок {mem.name} написал плохую программу. Он зарабатывает 0 очков совей команде!");
                return 0;
            }
        }
    }
}
