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
    }
}
