using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public abstract class Vehicle
        {
            private string _name;

            private float _weight;

            private short _maxSpeed;
            private short _minSpeed;
            private short _deltaSpeed;
            private short _currSpeed;

            private bool _isEngineRunning;

            public Vehicle(string name, float weight, short maxSpeed, short minSpeed, short deltaSpeed, short currSpeed)
            {
                _name = name;
                _weight = weight;
                _maxSpeed = maxSpeed;
                _minSpeed = minSpeed;
                _deltaSpeed = deltaSpeed;
                _currSpeed = currSpeed;
                _isEngineRunning = false;
            }

            public short VehicleMaxSpeed
            {
                get { return _maxSpeed; }
            }

            public short VehicleMinSpeed
            {
                get { return _minSpeed; }
            }

            public string VehicleName
            {
                get { return _name; }
                set { _name = value; }
            }

            public float VehicleWeight
            {
                get { return _weight; }
            }

            abstract public void StartEngine();


            abstract public void ShutdownEngine();

        }

        abstract class AirVehicle : Vehicle, IMovableHorizontal, IMovableVertical
        {
            private short _minAltitude;
            private short _maxAltitude;
            private short _deltaAltitude;
            private short _currAltitude;

            public AirVehicle(string name, float weight, short maxSpeed, short minSpeed, 
                short deltaSpeed, short currSpeed, string vehicleName, short minAltitude,
                short maxAltitude, short deltaAltitude, short currAltitude) : base (name, weight, maxSpeed, minSpeed, deltaSpeed, currSpeed)
            {
                _minAltitude = minAltitude;
                _maxAltitude = maxAltitude;
                _deltaAltitude = deltaAltitude;
                _currAltitude = currAltitude;
            }

            public void SpeedUp()
            {

            }

            public void SlowDown()
            {

            }

            public void IncreaseAltitude()
            {

            }

            public void DecreaseAltitude()
            {

            }

            void DisplayVehicleInfo()
            {

            }
        }

        abstract class GroundVehicle : Vehicle, IMovableHorizontal
        {
            private byte _wheelsCount;

            public GroundVehicle(string name, float weight, short maxSpeed, short minSpeed,
                short deltaSpeed, short currSpeed, string vehicleName, short minAltitude,
                short maxAltitude, short deltaAltitude, short currAltitude) : base(name, weight, maxSpeed, minSpeed, deltaSpeed, currSpeed)
            {

            }

            public void SpeedUp()
            {

            }

            public void SlowDown()
            {

            }

        }


        interface IMovableHorizontal
        {
            void SpeedUp();
            void SlowDown();
        }

        interface IMovableVertical
        {
            void IncreaseAltitude();
            void DecreaseAltitude();
        }

        interface IDisplayVehicleInfo
        {
            void DisplayVehicleInfo();
        }

        enum WheelDriveTypes
        {
            FrontWheelDrive,
            RearWhellDrive,
            FourWheelDrive

        }
        enum VehicleActionTypes
        {
            StartEngine,
            SpeedUp,
            SlowDown,
            IncreaseAltitude,
            DecreaseAltitude,
            ShutdownfEngine
        }
    }
}
