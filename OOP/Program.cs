using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OOP.Classes;

namespace OOP
{
    internal class Program
    {
        public static Garage garage = new Garage();
        public static Hangar hangar = new Hangar();

        static void Main(string[] args)
        {
            SetGarageDefaults();
            SetHangarDefaults();


            garage.PrintGarageInfo();
            foreach (GroundVehicle gVehicle in garage.Vehicles) 
            {
                gVehicle.DisplayVehicleInfo();
            }

            hangar.PrintHangarInfo();
            foreach (AirVehicle aVehicle in hangar.Vehicles)
            {
                aVehicle.DisplayVehicleInfo();
            }

            Console.ReadLine();
        }

        internal static void SetGarageDefaults()
        {
            
            garage.AddVehicle(new Car(name: "Жигули", weight: 1500, maxSpeed: 100, acceleration: 5, wheelDriveType: Vehicle.WheelDriveTypes.RearWhellDrive,
                engineType: Vehicle.GroundVehicleEngineTypes.Gasoline, horsePower: 70, bodyType: Vehicle.CarBodyTypes.Sedan));

            garage.AddVehicle(new Motorcycle(name: "Harley-Davidson", weight: 100, maxSpeed: 290, acceleration: 30,
                engineType: Vehicle.GroundVehicleEngineTypes.Gasoline, horsePower: 70));

        }

        internal static void SetHangarDefaults()
        {
            hangar.AddVehicle(new Helicopter(name: "Ми-24", weight: 5000, maxSpeed: 400, acceleration: 40, maxAltitude: 4000,
                verticalAcceleration: 60, loadCapacity: 10000, Vehicle.AirVehicleEngineTypes.Turboshaft));

            hangar.AddVehicle(new Plane(name: "Sea Wixen", weight: 3000, maxSpeed: 1151, acceleration: 100, maxAltitude: 9000,
                verticalAcceleration: 180, loadCapacity: 3000, Vehicle.AirVehicleEngineTypes.Reactive, runwayLength: 300));

            hangar.AddVehicle(new Plane(name: "F4U Corsair", weight: 2000, maxSpeed: 485, acceleration: 40, maxAltitude: 3500,
                verticalAcceleration: 20, loadCapacity: 1500, Vehicle.AirVehicleEngineTypes.Radial, runwayLength: 350));
        }
    }
}


