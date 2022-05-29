using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork8
{
    class Beach:IGame
    {
        private Random rnd;
        public Beach()
        {
            rnd = new Random(DateTime.Now.Millisecond);
        }
        public string name => "Пляж";

        public int Play(Member mem)
        {
            int result = 0;
            int found;
            for (int i = 0; i < 20; i++)
            {
                found = rnd.Next(0, 4);
                switch(found)
                {
                    case 1:
                        result++; //Маленькая ракушка
                        break;
                    case 2:
                        result+=2; //Большая ракушка
                        break;
                    case 3:
                        result = 0; //Краб
                        break;
                }
            }
            Console.WriteLine($"Игрок {mem.name} прошёлся по пляжу и нашёл ракушек ценностью в {result} и принёс {result/2} очков своей команде!");
            return result;
        }
    }
}
