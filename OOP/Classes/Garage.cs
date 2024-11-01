﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Classes
{
    internal class Garage
    {
        public List<GroundVehicle> _vehicles;



        public Garage()
        {
            _vehicles = new List<GroundVehicle>();
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

        public List<GroundVehicle> Vehicles
        {
            get { return _vehicles; }
        }

        public Vehicle GetVehicleByID(int vehicleNumber)
        {
            return _vehicles[vehicleNumber - 1];
        }

        public void PrintGarageInfo()
        {
            Console.WriteLine($"Добро пожаловать в Ваш гараж! Сейчас здесь {_vehicles.Count} единиц техники.");
            PrintListOfVehicles();
        }

        public int GetVNumberOfVehicles()
        {
            return _vehicles.Count;
        }

        public void AddVehicle(GroundVehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void RemoveVehicleByID(int vehicleNumber)
        {
            _vehicles.Remove(_vehicles[vehicleNumber-1]);
        }
    }
}
