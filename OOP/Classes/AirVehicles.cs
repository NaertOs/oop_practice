using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP.Program;

namespace OOP.Classes
{
    internal abstract class AirVehicle : Vehicle, IMovableHorizontal, IMovableVertical
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

    internal class Helicopter : AirVehicle
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
            Console.WriteLine("\n");
        }
    }

    internal class Plane : AirVehicle
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
                $"Длина взлётной полосы: {_runwayLength}");
            Console.WriteLine("\n");
        }
    }
}
