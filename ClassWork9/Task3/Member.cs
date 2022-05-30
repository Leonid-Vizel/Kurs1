using System;
using System.Threading;

namespace ClassWork9
{
    class Member
    {
        public static readonly Random rnd;
        public readonly string name;
        public readonly Team team;
        private long totalPoints;
        public readonly int skill;
        public readonly int luck;

        public long Points => totalPoints;
        static Member()
        {
            rnd = new Random(DateTime.Now.Millisecond);
        }

        public Member(string name, Team team)
        {
            this.name = name;
            this.team = team;
            skill = rnd.Next(0,11);
            luck = rnd.Next(0, 11);
            totalPoints = 0;
            Thread.Sleep(10);
        }

        public void EarnPoints(int amount) => totalPoints += amount;
    }

    public enum Team
    {
        Russia,
        France,
        Ukraine,
        China
    }
}
