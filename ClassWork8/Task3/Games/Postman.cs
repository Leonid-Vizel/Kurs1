using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork8
{
    class Postman : IGame
    {
        public Postman() {/*Nothing*/}
        public string name => "Почтальон";

        public int Play(Member mem)
        {
            if (mem.skill*mem.luck > 40)
            {
                mem.EarnPoints(2);
                Console.WriteLine($"Игрок {mem.name} написал великолепное письмо на англиском языке. Он зарабатывает 9 очков совей команде!");
                return 9;
            }
            else
            {
                mem.EarnPoints(2);
                Console.WriteLine($"Игрок {mem.name} написал не самое лучшее письмо. Он зарабатывает 1 очко совей команде!");
                return 1;
            }
        }
    }
}
