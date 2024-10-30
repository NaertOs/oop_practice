using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Car car = new Car(name: "Жигули", weight: 1500, maxSpeed: 100, acceleration: 5, wheelDriveType: WheelDriveTypes.RearWhellDrive,
                engineType: GroundVehicleEngineTypes.Gasoline, horsePower: 70, bodyType: CarBodyTypes.Sedan);

            Motorcycle moto = new Motorcycle(name: "Harley-Davidson", weight: 1500, maxSpeed: 290, acceleration: 30,
                engineType: GroundVehicleEngineTypes.Gasoline, horsePower: 70);

            Helicopter heli = new Helicopter(name: "Ми-24", weight: 5000, maxSpeed: 400, acceleration: 40, maxAltitude: 4000,
                verticalAcceleration: 60, loadCapacity: 10000, AirVehicleEngineTypes.Turboshaft);


            Plane plane = new Plane(name: "Sea Wixen", weight: 3000, maxSpeed: 1151, acceleration: 100, maxAltitude: 9000,
                verticalAcceleration: 180, loadCapacity: 3000, AirVehicleEngineTypes.Reactive, runwayLength: 300);

            Plane plane2 = new Plane(name: "F4U Corsair", weight: 2000, maxSpeed: 485, acceleration: 40, maxAltitude: 3500,
                verticalAcceleration: 20, loadCapacity: 1500, AirVehicleEngineTypes.Radial, runwayLength: 350);

            Console.ReadLine();
        }





        public abstract class Vehicle
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

        }

        public abstract class AirVehicle : Vehicle, IMovableHorizontal, IMovableVertical
        {
            protected int _minAltitude;
            protected int _maxAltitude;
            protected short _deltaAltitude;
            protected int _currAltitude;
            protected int _loadCapacity;
            protected AirVehicleEngineTypes _engineType;

                public AirVehicle(string name, float weight, short maxSpeed,
                short acceleration, int maxAltitude, short verticalAcceleration, int loadCapacity, AirVehicleEngineTypes engineType) :
                base(name, weight, maxSpeed, acceleration)
            {
                _minAltitude = 0;
                _maxAltitude = maxAltitude;
                _deltaAltitude = verticalAcceleration;
                _currAltitude = 0;
                _loadCapacity = loadCapacity;
                _engineType = engineType;
            }

            public override void ShutdownEngine()
            {
                if (_isEngineRunning)
                {
                    if (_currAltitude == 0)
                    {
                        _isEngineRunning = false;
                        Console.WriteLine("Двигатель заглушен!");
                    }
                    else
                    {
                        Console.WriteLine("Сначала необходимо совершить посадку!");
                    }
                }
                else
                {
                    Console.WriteLine("Прежде чем заглушить двигатель, его надо запустить!");
                }
            }

            public override void StartEngine()
            {
                if (!_isEngineRunning)
                {
                    _isEngineRunning = true;
                    Console.WriteLine("Двигатель запущен!");
                }
                else
                {
                    Console.WriteLine("Прежде чем запустить двигатель, его надо заглушить!");
                }
            }

            public void SpeedUp()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                System.Threading.Thread.Sleep(500);
                if (_currSpeed < _maxSpeed)
                {
                    _currSpeed += _acceleration;
                    Console.WriteLine($" Нажимаем педаль газа! {_name} летит уверенно и умеренно набирает скорость: {_currSpeed} км/ч");
                }
                else
                {
                    _currSpeed = _maxSpeed;
                    Console.WriteLine($" Быстрее уже некуда! {_name} несётся с максимальной скоростью: {_currSpeed}  км/ч");
                }

            }

            public void SlowDown()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                System.Threading.Thread.Sleep(500);
                if (_currSpeed > _MINSPEED)
                {
                    _currSpeed += _acceleration;
                    Console.WriteLine($" Немного притормозили! {_name} сбавил скорость до: {_currSpeed}  км/ч");
                }
                else
                {
                    _currSpeed = _MINSPEED;
                    Console.WriteLine($" {_name} Полностью остановился ");
                }
            }

            public void PedalToTHeMetal()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                while (_currSpeed < _maxSpeed)
                {
                    _currSpeed += _acceleration * 2;
                    Console.WriteLine($" Педаль в пол! {_name} мчится со скоростью: {_currSpeed} км/ч");
                    System.Threading.Thread.Sleep(500);
                }
                _currSpeed = _maxSpeed;
                Console.WriteLine($" Быстрее уже некуда! {_name} несётся с максимальной скоростью: {_currSpeed} км/ч");
            }

            public void IncreaseAltitude()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                System.Threading.Thread.Sleep(500);
                if (_currAltitude < _maxAltitude)
                {
                    _currAltitude += _deltaAltitude;
                    Console.WriteLine($" Потихоньку набираем высоту! {_name} поднялся на высоту: {_currSpeed} метров");
                }
                else
                {
                    _currAltitude = _maxAltitude;
                    Console.WriteLine($" Выше уже не куда! {_name} набрал свою максимальную высоту");
                }
            }

            public void DecreaseAltitude()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                System.Threading.Thread.Sleep(500);
                if (_currAltitude > _minAltitude)
                {
                    _currAltitude += _deltaAltitude;
                    Console.WriteLine($" Потихоньку снижаем высоту! {_name} снизился на высоту: {_currSpeed} метров");
                }
                else
                {
                    _currAltitude = _minAltitude;
                    Console.WriteLine($" Ниже уже не куда! {_name} совершил мягкую посадку");
                }
            }

            public abstract void DisplayVehicleInfo();
        }

        public class Helicopter : AirVehicle
        {
            public Helicopter(string name, float weight, short maxSpeed,
                short acceleration, int maxAltitude, short verticalAcceleration,
                int loadCapacity, AirVehicleEngineTypes engineType) : base(name, weight, maxSpeed, acceleration, maxAltitude,
                    verticalAcceleration, loadCapacity, engineType)
            {
                _loadCapacity = loadCapacity;
            }

            public override void DisplayVehicleInfo()
            {
                Console.WriteLine($"Название: {_name}, тип: Вертолёт");
                Console.WriteLine($"Грузопдъемность: {_loadCapacity}, вес: {_weight} кг");
                Console.WriteLine($"Максимальная высота: {_maxAltitude}, Тип двигателя: {AirVehicleEngineTypesDict[_engineType]}");
            }
        }

        public class Plane : AirVehicle
        {
            private short _runwayLength;

            public Plane(string name, float weight, short maxSpeed,
                short acceleration, int maxAltitude, short verticalAcceleration,
                int loadCapacity, AirVehicleEngineTypes engineType, short runwayLength) : base(name, weight, maxSpeed, acceleration,
                    maxAltitude, verticalAcceleration, loadCapacity, engineType)
            {
                _loadCapacity = loadCapacity;
                _runwayLength = runwayLength;
            }

            public override void DisplayVehicleInfo()
            {
                Console.WriteLine($"Название: {_name}, тип: Самолёт");
                Console.WriteLine($"Грузопдъемность: {_loadCapacity}, вес: {_weight} кг");
                Console.WriteLine($"Максимальная высота: {_maxAltitude}, Тип двигателя: {AirVehicleEngineTypesDict[_engineType]}, " +
                    $"Длина взлётной полосы:{_runwayLength}");
            }
        }

        public abstract class GroundVehicle : Vehicle, IMovableHorizontal, IDisplayVehicleInfo
        {
            protected byte _wheelsCount;
            protected WheelDriveTypes _wheelDriveType;
            protected ushort _horsePower;
            protected GroundVehicleEngineTypes _engineType;

            protected GroundVehicle(string name, float weight, short maxSpeed,
                short acceleration, byte wheelsCount, WheelDriveTypes wheelDriveType,
                GroundVehicleEngineTypes engineType, ushort horsePower) : base(name, weight, maxSpeed, acceleration)
            {
                _wheelsCount = wheelsCount;
                _wheelDriveType = wheelDriveType;
                _horsePower = horsePower;
                _engineType = engineType;
            }

            protected GroundVehicle(string name, float weight, short maxSpeed,
                short acceleration, byte wheelsCount,
                GroundVehicleEngineTypes engineType, ushort horsePower) : base(name, weight, maxSpeed, acceleration)
            {
                _wheelsCount = wheelsCount;
                _horsePower = horsePower;
                _engineType = engineType;
            }

            public abstract void DisplayVehicleInfo();

            public override void ShutdownEngine()
            {
                if (_isEngineRunning)
                {
                    _isEngineRunning = false;
                    Console.WriteLine("Двигатель заглушен!");
                }
                else
                {
                    Console.WriteLine("Прежде чем заглушить двигатель, его надо запустить!");
                }
            }

            public override void StartEngine()
            {
                if (!_isEngineRunning)
                {
                    _isEngineRunning = true;
                    Console.WriteLine("Двигатель запущен!");
                }
                else
                {
                    Console.WriteLine("Прежде чем запустить двигатель, его надо заглушить!");
                }
            }

            public void EmergencyStop()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                while (_currSpeed > 10)
                {
                    _currSpeed = _currSpeed / 2;
                    Console.WriteLine($" {_name} совершает экстренное торможение! Текущая скорость: {_currSpeed}");
                    System.Threading.Thread.Sleep(500);
                }
                _currSpeed = 10;
                Console.WriteLine($" {_name} полностью остановился!");
            }

            public void PedalToTHeMetal()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                while (_currSpeed < _maxSpeed)
                {
                    _currSpeed += _acceleration * 2;
                    Console.WriteLine($" Педаль в пол! {_name} мчится со скоростью: {_currSpeed} км/ч");
                    System.Threading.Thread.Sleep(500);
                }
                _currSpeed = _maxSpeed;
                Console.WriteLine($" Быстрее уже некуда! {_name} несётся с максимальной скоростью: {_currSpeed} км/ч");

            }

            public void SpeedUp()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                if (_currSpeed < _maxSpeed)
                {
                    _currSpeed += _acceleration;
                    Console.WriteLine($" Нажимаем педаль газа! {_name} умеренно набирает скорость: {_currSpeed} км/ч");
                }
                else
                {
                    _currSpeed = _maxSpeed;
                    Console.WriteLine($" Быстрее уже некуда! {_name} несётся с максимальной скоростью: {_currSpeed}  км/ч");
                }
            }

            public void SlowDown()
            {
                if (!_isEngineRunning)
                {
                    this.StartEngine();
                }
                if (_currSpeed > _MINSPEED)
                {
                    _currSpeed += _acceleration;
                    Console.WriteLine($" Немного притормозили! {_name} сбавил скорость до: {_currSpeed}  км/ч");
                }
                else
                {
                    _currSpeed = _MINSPEED;
                    Console.WriteLine($"{_name} полностью остановился ");
                }
            }
        }

        public class Car : GroundVehicle
        {
            private CarBodyTypes _bodyType;
            private const byte _WHEELSCOUNT = 4;


            public Car(string name, float weight, short maxSpeed,
                short acceleration, WheelDriveTypes wheelDriveType, GroundVehicleEngineTypes engineType,
                ushort horsePower, CarBodyTypes bodyType) : base(name, weight, maxSpeed, acceleration,
                    _WHEELSCOUNT, wheelDriveType, engineType, horsePower)
            {
                _bodyType = bodyType;
            }

            public override void DisplayVehicleInfo()
            {
                Console.WriteLine($"Название: {_name}, тип: Автомобиль");
                Console.WriteLine($"Кузов: {_bodyType}, вес: {_weight} кг");
                Console.WriteLine($"Привод: {WheelDriveTypesDict[_wheelDriveType]}, количество колёс: {_WHEELSCOUNT} ");
                Console.WriteLine($"Тип двигателя: {GroundVehicleEngineTypesDict[_engineType]}, мощность: {_horsePower} л/с");
            }
        }

        public class Motorcycle : GroundVehicle
        {
            private const byte _WHEELSCOUNT = 2;


            public Motorcycle(string name, float weight, short maxSpeed,
                short acceleration, GroundVehicleEngineTypes engineType,
                ushort horsePower) : base(name, weight, maxSpeed, acceleration,
                    _WHEELSCOUNT, engineType, horsePower)
            {

            }

            public override void DisplayVehicleInfo()
            {
                Console.WriteLine($"Название: {_name}, тип: Мотоцикл");
                Console.WriteLine($"Вес: {_weight} кг");
                Console.WriteLine($"Привод: {WheelDriveTypesDict[_wheelDriveType]}, количество колёс: {_WHEELSCOUNT} ");
                Console.WriteLine($"Тип двигателя: {GroundVehicleEngineTypesDict[_engineType]}, мощность: {_horsePower} л/с");
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

        internal enum WheelDriveTypes
        {
            FrontWheelDrive,
            RearWhellDrive,
            FourWheelDrive
        }


        static Dictionary<WheelDriveTypes, string> WheelDriveTypesDict = new Dictionary<WheelDriveTypes, string>()
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


