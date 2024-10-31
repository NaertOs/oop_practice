using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Classes
{
    internal class Hangar
    {
        private List<AirVehicle> _vehicles;
        private short _runawatLength;
        



        public Hangar()
        {
            _vehicles = new List<AirVehicle>();
            _runawatLength = 600;
        }

        public void PrintListOfVehicles()
        {
            if (_vehicles.Count != 0)
            {
                int i = 1;
                foreach (var vehicle in _vehicles)
                {
                    Console.WriteLine("{0}. {1}", i, vehicle.VehicleName);
                    i++;
                }
            }
        }

        public List<AirVehicle> Vehicles
        {
            get { return _vehicles; }
        }

        public Vehicle GetVehicleByID(int vehicleNumber)
        {
            return _vehicles[vehicleNumber - 1];
        }

        public void PrintHangarInfo()
        {
            Console.WriteLine($"Добро пожаловать в Ваш ангар! Сейчас здесь {_vehicles.Count} единиц техники. \nДлина взлётной полосы: {_runawatLength} м.");
            PrintListOfVehicles();
        }

        public int GetVNumberOfVehicles()
        {
            return _vehicles.Count;
        }

        public void AddVehicle(AirVehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void RemoveVehicleByID(int vehicleNumber)
        {
            _vehicles.Remove(_vehicles[vehicleNumber - 1]);
        }
    }
}
