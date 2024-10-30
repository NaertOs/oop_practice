using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Classes
{
    internal abstract class Vehicle
    {
        protected string _name;

        protected float _weight;

        protected int _maxSpeed;
        protected const int _MINSPEED = 0;
        protected short _acceleration;
        protected double _currSpeed;

        protected bool _isEngineRunning;

        public Vehicle(string name, float weight, int maxSpeed, short acceleration)
        {
            _name = name;
            _weight = weight;
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
            _currSpeed = _MINSPEED;
            _isEngineRunning = false;
        }

        public int VehicleMaxSpeed
        {
            get { return _maxSpeed; }
        }

        public int VehicleMinSpeed
        {
            get { return _MINSPEED; }
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

        internal enum WheelDriveTypes
        {
            FrontWheelDrive,
            RearWhellDrive,
            FourWheelDrive
        }


        internal static Dictionary<WheelDriveTypes, string> WheelDriveTypesDict = new Dictionary<WheelDriveTypes, string>()
        {
            { WheelDriveTypes.FrontWheelDrive,  "Передний"},
            { WheelDriveTypes.RearWhellDrive,  "Задний"},
            { WheelDriveTypes.FourWheelDrive,  "Полный"}
        };

        public enum VehicleActionTypes
        {
            StartEngine,
            SpeedUp,
            SlowDown,
            EmergencyBreaking,
            PedalToTheMetal,
            IncreaseAltitude,
            DecreaseAltitude,
            ShutdownfEngine,
            ReturnToGarage
        }

        static public Dictionary<VehicleActionTypes, string> VehicleActionTypesDict = new Dictionary<VehicleActionTypes, string>()
        {
            { VehicleActionTypes.StartEngine,  "Запустить двигатель"},
            { VehicleActionTypes.SpeedUp,  "Увеличить скорость"},
            { VehicleActionTypes.SlowDown,  "Снизить скорость"},
            { VehicleActionTypes.EmergencyBreaking,  "Резко затормозить!"},
            { VehicleActionTypes.PedalToTheMetal,  "Педаль в пол!"},
            { VehicleActionTypes.IncreaseAltitude,  "Увеличить высоту"},
            { VehicleActionTypes.DecreaseAltitude,  "Снизить высоту"},
            { VehicleActionTypes.ShutdownfEngine,  "Заглушить двигатель"},
            { VehicleActionTypes.ReturnToGarage,  "Вернуться в гараж"}
        };

        public enum GroundVehicleEngineTypes
        {
            Gasoline,
            Diesel,
            Electric
        };

        static public Dictionary<GroundVehicleEngineTypes, string> GroundVehicleEngineTypesDict = new Dictionary<GroundVehicleEngineTypes, string>()
        {
            { GroundVehicleEngineTypes.Gasoline,  "Бензиновый"},
            { GroundVehicleEngineTypes.Diesel,  "Дизельный"},
            { GroundVehicleEngineTypes.Electric,  "Электрический"}
        };

        public enum AirVehicleEngineTypes
        {
            Reactive,
            Radial,
            Turboshaft
        }

        static public Dictionary<AirVehicleEngineTypes, string> AirVehicleEngineTypesDict = new Dictionary<AirVehicleEngineTypes, string>()
        {
            { AirVehicleEngineTypes.Reactive,  "Реактивный"},
            { AirVehicleEngineTypes.Radial,  "Звёздообразный"},
            { AirVehicleEngineTypes.Turboshaft,  "Газотурбинный "}
        };


        public enum CarBodyTypes
        {
            Sedan,
            SUV,
            Supercar
        };


        static public Dictionary<CarBodyTypes, string> CarBodyTypesDict = new Dictionary<CarBodyTypes, string>()
        {
            { CarBodyTypes.Sedan,  "Седан"},
            { CarBodyTypes.SUV,  "Внедорожник/Кроссовер"},
            { CarBodyTypes.Supercar,  "Суперкар"}
        };
    }
}
