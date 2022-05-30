using System;

namespace ClassWork9
{
    class Hill : IGame
    {
        private Random rnd;
        public readonly int obsticles;
        public Hill(int obsticles)
        {
            rnd = new Random(DateTime.Now.Millisecond);
            this.obsticles = obsticles;
        }
        public string name => "Горка";

        public int Play(Member mem)
        {
            int neededSkill;
            int pointsAdd = 0;
            for (int i = 0; i < obsticles; i++)
            {
                neededSkill = rnd.Next(0, 11);
                if (neededSkill <= mem.skill)
                {
                    pointsAdd++;
                }
            }
            mem.EarnPoints(pointsAdd);
            Console.WriteLine($"Игрок {mem.name} прошёл {pointsAdd} припятствий из {obsticles} и заработал {pointsAdd} очков своей команде!");
            return pointsAdd;
        }
    }
}
