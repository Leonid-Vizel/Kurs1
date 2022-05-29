using System;

namespace FabricsLib
{
    public interface IBuilding
    {
        int flats { get; }
        int floors { get; }
        double height { get; }
        int entrances { get; }
        double FloorHeight { get; }
        int FlatsPerEntrance { get; }
        int FlatsPerFloor { get; }
        bool isBuilt { get; }
        bool isInhabited { get; }
        void Build();
        void Inhabitate();
    }
}
