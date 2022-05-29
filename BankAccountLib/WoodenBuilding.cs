using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricsLib
{
    public class WoodenBuilding : IBuilding
    {
        public bool isBuilt { get; private set; }
        public bool isInhabited { get; private set; }
        public int flats { get; private set; }
        public int floors { get; private set; }
        public double height { get; private set; }
        public int entrances { get; private set; }

        public double FloorHeight => Math.Round(height / floors);
        public int FlatsPerEntrance => flats / entrances;
        public int FlatsPerFloor => FlatsPerEntrance / floors;
        public void Build() => isBuilt = true;
        public void Inhabitate() => isInhabited = isBuilt;
        internal WoodenBuilding(int flats, int floors, double height, int entrances)
        {
            this.flats = flats;
            this.floors = floors;
            this.height = height;
            this.entrances = entrances;
            isBuilt = isInhabited = false;
        }
        public override string ToString()
        {
            return $"Инфоормация о здании:\n" +
                $"Материал: Кирпич\n" +
                $"Высота: {height} м (Макс: 6.5 м)\n" +
                $"Кол-во подъездов: {entrances}\n" +
                $"Кол-во этажей: {floors}\n (Макс: 3)" +
                $"Кол-во квартир: {flats}\n" +
                $"Квартир на подъезд: {FlatsPerEntrance}\n" +
                $"Квартир в на этаж: {FlatsPerFloor}\n" +
                $"Высота этажа: {FloorHeight} м\n" +
                $"Построено: {isBuilt}\n" +
                $"Заселено: {isInhabited}";
        }
    }
}
