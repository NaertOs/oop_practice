using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP.Program;

namespace OOP.Classes
{
    internal abstract class GroundVehicle : Vehicle, IMovableHorizontal, IDisplayVehicleInfo
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

    internal class Car : GroundVehicle
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
            Console.WriteLine("\n");
        }
    }

    internal class Motorcycle : GroundVehicle
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
            Console.WriteLine("\n");
        }
    }
}
