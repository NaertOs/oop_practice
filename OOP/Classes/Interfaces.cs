using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Classes
{
    internal interface IMovableHorizontal
    {
        void SpeedUp();
        void SlowDown();
    }

    internal interface IMovableVertical
    {
        void IncreaseAltitude();
        void DecreaseAltitude();
    }

    internal interface IDisplayVehicleInfo
    {
        void DisplayVehicleInfo();
    }
}
