using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricsLib
{
    public class BuildingFabric
    {
        private static ulong counterID;
        private static Dictionary<ulong, IBuilding> savedDict;
        //Здесь решил не выпендриваться и представил хеш таблицу как Dictionary
        static BuildingFabric()
        {
            counterID = 0;
            savedDict = new Dictionary<ulong, IBuilding>();
        }

        public static WoodenBuilding CreateWoodenBuilding(int flats, int floors, double height, int entrances)
        {
            WoodenBuilding build = new WoodenBuilding(flats, floors, height, entrances);
            savedDict.Add(counterID++, build);
            return build;
        }

        public static BrickBuilding CreateBrickBuilding(int flats, int floors, double height, int entrances)
        {
            BrickBuilding build = new BrickBuilding(flats, floors, height, entrances);
            savedDict.Add(counterID++, build);
            return build;
        }

        public static bool Destruct(ulong ID) => savedDict.Remove(ID);

        public static string GetInfo() => string.Join("\n", savedDict.Select(x => $"[{x.Key}]{x.Value}"));
    }
}
