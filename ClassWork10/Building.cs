using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork10
{
    public class Building
    {
        private static uint IDcounter;
        public uint ID;
        public double height;
        public uint flats;
        public uint floors;
        public string material;

        static Building() => IDcounter = 0;

        public Building(double height = 9, uint flats = 9, uint floors = 3, string material = "Кирпич")
        {
            ID = IDcounter++;
            this.height = height;
            this.flats = flats;
            this.floors = floors;
            this.material = material;
        }

        public override string ToString() => $"ID здания: {ID}";
    }
}
