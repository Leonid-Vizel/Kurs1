using System;

namespace ClassWork8
{
    class Mousetrap : IGame
    {
        private Random rnd;
        public readonly int obsticles;
        public Mousetrap(int obsticles)
        {
            rnd = new Random(DateTime.Now.Millisecond);
            this.obsticles = obsticles;
        }
        public string name => "Мышеловка";

        public int Play(Member mem)
        {
            int neededLuck;
            int pointsAdd = 0;
            for (int i = 0; i < obsticles; i++)
            {
                neededLuck = rnd.Next(0, 11);
                if (neededLuck <= mem.luck)
                {
                    pointsAdd++;
                }
            }
            mem.EarnPoints(pointsAdd);
            Console.WriteLine($"Игрок {mem.name} смог избежать {pointsAdd} мышеловок из {obsticles} и заработал {pointsAdd} очков своей команде!");
            return pointsAdd;
        }
    }
}
