using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork11
{
    public class BuildingCollection
    {
        private Building[] array;

        public BuildingCollection(int capacity)
        {
            array = new Building[capacity];
            for (int i = 0; i < capacity; i++)
            {
                array[i] = new Building();
            }
        }

        public Building this[int index]
        {
            get
            {
                if (array.Any(x=>x.ID == index))
                {
                    return array.First(x => x.ID == index);
                }
                else
                {
                    throw new Exception("Здание с таким ID не найдено");
                }
            }
        }
    }
}
