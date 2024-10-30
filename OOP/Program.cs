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
            internal string _name;

            internal float _weight;

            internal int _maxSpeed;
            internal int _minSpeed;
            internal short _deltaSpeed;
            internal double _currSpeed;

            internal bool _isEngineRunning;

            public Vehicle(string name, float weight, int maxSpeed, int minSpeed, short deltaSpeed)
            {
                _name = name;
                _weight = weight;
                _maxSpeed = maxSpeed;
                _minSpeed = minSpeed;
                _deltaSpeed = deltaSpeed;
                _currSpeed = 0;
                _isEngineRunning = false;
            }

            public int VehicleMaxSpeed
            {
                get { return _maxSpeed; }
            }

            public int VehicleMinSpeed
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
            internal int _minAltitude;
            internal int _maxAltitude;
            internal short _deltaAltitude;
            internal int _currAltitude;

            public AirVehicle(string name, float weight, short maxSpeed, short minSpeed, 
                short deltaSpeed, short currSpeed, string vehicleName, short minAltitude,
                short maxAltitude, short deltaAltitude) : base (name, weight, maxSpeed, minSpeed, deltaSpeed)
            {
                _minAltitude = minAltitude;
                _maxAltitude = maxAltitude;
                _deltaAltitude = deltaAltitude;
                _currAltitude = 0;
            }

            public void SpeedUp()
            {
                if (_currSpeed < _maxSpeed)
                {
                    _currSpeed += _deltaSpeed;
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
                if (_currSpeed > _minSpeed)
                {
                    _currSpeed += _deltaSpeed;
                    Console.WriteLine($" Немного притормозили! {_name} сбавил скорость до: {_currSpeed}  км/ч");
                }
                else
                {
                    _currSpeed = _minSpeed;
                    Console.WriteLine($" {_name} Полностью остановился ");
                }
            }

            public void PedalToTHeMetal()
            {
                while (_currSpeed < _maxSpeed)
                {
                    _currSpeed += _deltaSpeed * 2;
                    Console.WriteLine($" Педаль в пол! {_name} мчится со скоростью: {_currSpeed} км/ч");
                }
                _currSpeed = _maxSpeed;
                Console.WriteLine($" Быстрее уже некуда! {_name} несётся с максимальной скоростью: {_currSpeed} км/ч");
            }

            public void IncreaseAltitude()
            {
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

        internal abstract class GroundVehicle : Vehicle, IMovableHorizontal, IDisplayVehicleInfo
        {
            internal byte _wheelsCount;
            internal WheelDriveTypes _wheelDriveType;
            internal ushort _horsePower;
            internal GroundVehicleEngineTypes _engineType;
            
            public GroundVehicle(string name, float weight, short maxSpeed, short minSpeed,
                short deltaSpeed, byte wheelsCount, WheelDriveTypes wheelDriveType, GroundVehicleEngineTypes engineType, ushort horsePower) : base(name, weight, maxSpeed, minSpeed, deltaSpeed)
            {
                _wheelsCount = wheelsCount;
                _wheelDriveType = wheelDriveType;
                _horsePower = horsePower;
                _engineType = engineType;
            }

            public abstract void DisplayVehicleInfo();

            public override void ShutdownEngine()
            {
                if (_isEngineRunning)
                {
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
                    Console.WriteLine("Двигатель запущен!");
                }
                else
                {
                    Console.WriteLine("Прежде чем запустить двигатель, его надо заглушить!");
                }
            }

            public void EmergencyStop()
            {
                while (_currSpeed > 10)
                {
                    _currSpeed = _currSpeed / 2;
                    Console.WriteLine($" {_name} совершает экстренное торможение! Текущая скорость: {_currSpeed}");
                }
                _currSpeed = 10;
                Console.WriteLine($" {_name} полностью остановился!");
            }

            public void PedalToTHeMetal()
            {
                while (_currSpeed < _maxSpeed)
                {
                    _currSpeed += _deltaSpeed * 2;
                    Console.WriteLine($" Педаль в пол! {_name} мчится со скоростью: {_currSpeed} км/ч" );
                }
                _currSpeed = _maxSpeed;
                Console.WriteLine($" Быстрее уже некуда! {_name} несётся с максимальной скоростью: {_currSpeed} км/ч" );
            }

            public void SpeedUp()
            {
                if(_currSpeed < _maxSpeed)
                { 
                    _currSpeed += _deltaSpeed;
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
                if (_currSpeed > _minSpeed)
                {
                    _currSpeed += _deltaSpeed;
                    Console.WriteLine($" Немного притормозили! {_name} сбавил скорость до: {_currSpeed}  км/ч");
                }
                else
                {
                    _currSpeed = _minSpeed;
                    Console.WriteLine($"{_name} полностью остановился ");
                }
            }
        }

        public class Car: GroundVehicle
        {
            private CarBodyTypes _bodyType;


            public Car(string name, float weight, short maxSpeed, short minSpeed,
                short deltaSpeed, short currSpeed, byte wheelsCount, 
                WheelDriveTypes wheelDriveType, GroundVehicleEngineTypes engineType, ushort horsePower, CarBodyTypes BodyType) 
                : base (name, weight, maxSpeed, minSpeed, deltaSpeed, wheelsCount, wheelDriveType, engineType, horsePower)
            {
                _bodyType = BodyType;
            }

            public override void DisplayVehicleInfo()
            {
                Console.WriteLine($"Название: {_name} ");
                Console.WriteLine($"Кузов: {_bodyType}, вес: {_weight} кг");
                Console.WriteLine($"Привод: {_wheelDriveType}, количество колёс: {_wheelsCount} ");
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

        internal Dictionary<WheelDriveTypes, string> WheelDriveTypesDict = new Dictionary<WheelDriveTypes, string>()
        {
            { WheelDriveTypes.FrontWheelDrive,  "Передний"},
            { WheelDriveTypes.RearWhellDrive,  "Задний"},
            { WheelDriveTypes.FourWheelDrive,  "Полный"}
        };

        internal enum VehicleActionTypes
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

        static internal Dictionary<VehicleActionTypes, string> VehicleActionTypesDict = new Dictionary<VehicleActionTypes, string>()
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

        internal enum GroundVehicleEngineTypes
        {
            Gasoline,
            Diesel,
            Electric
        };

        static internal Dictionary<GroundVehicleEngineTypes, string> GroundVehicleEngineTypesDict = new Dictionary<GroundVehicleEngineTypes, string>()
        {
            { GroundVehicleEngineTypes.Gasoline,  "Бензиновый"},
            { GroundVehicleEngineTypes.Diesel,  "Дизельный"},
            { GroundVehicleEngineTypes.Electric,  "Электрический"}
        };

        internal enum CarBodyTypes
        {
            Sedan,
            SUV,
            Supercar
        };


        static internal Dictionary<CarBodyTypes, string> CarBodyTypesDict = new Dictionary<CarBodyTypes, string>()
        {
            { CarBodyTypes.Sedan,  "Седан"},
            { CarBodyTypes.SUV,  "Внедорожник/Кроссовер"},
            { CarBodyTypes.Supercar,  "Суперкар"}
        };


    }
}
