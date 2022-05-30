using System;

namespace ClassWork6
{
    class Building
    {
        private long ID;
        private int flats;
        private int floors;
        private double height;
        private int entrances;
        private static int counterID = 0;

        public long GetId() => ID;
        public int GetFlats() => flats;
        public int GetFloors() => floors;
        public double GetHeight() => height;
        public int GetEntrances() => entrances;

        public double FloorHeight => Math.Round(height / floors);
        public int FlatsPerEntrance => flats / entrances;
        public int FlatsPerFloor => FlatsPerEntrance / floors;

        public Building(int flats, int floors, double height, int entrances)
        {
            ID = counterID++;
            this.flats = flats;
            this.floors = floors;
            this.height = height;
            this.entrances = entrances;
        }

        public override string ToString()
        {
            return $"Инфоормация о здании[{ID}]:\n" +
                $"Высота: {height} м\n" +
                $"Кол-во подъездов: {entrances}\n" +
                $"Кол-во этажей: {floors}\n" +
                $"Кол-во квартир: {flats}\n" +
                $"Квартир на подъезд: {FlatsPerEntrance}\n" +
                $"Квартир в на этаж: {FlatsPerFloor}\n" +
                $"Высота этажа: {FloorHeight} м";
        }
    }
}
