using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Classes
{
    internal class Controller
    {
        Garage garage;
        public Controller() 
        {
            garage = new Garage();

            SetDefaultsVehicles();


            Console.WriteLine($"Добро пожаловать в Ваш гараж! Сейчас здесь {garage.GetVNumberOfVehicles()} единиц техники. \nВведите номер той, с которой хотели бы взаимодействовать: ");
            garage.PrintListOfVehicles();

            ConsoleHandler();
        }

        internal void ConsoleHandler()
        {
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "Выйти из гаража":
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

        }

        public void SetDefaultsVehicles()
        {
            garage.AddVehicle(new Car(name: "Жигули", weight: 1500, maxSpeed: 100, acceleration: 5, wheelDriveType: Vehicle.WheelDriveTypes.RearWhellDrive,
engineType: Vehicle.GroundVehicleEngineTypes.Gasoline, horsePower: 70, bodyType: Vehicle.CarBodyTypes.Sedan));
            garage.AddVehicle(new Motorcycle(name: "Harley-Davidson", weight: 100, maxSpeed: 290, acceleration: 30,
                engineType: Vehicle.GroundVehicleEngineTypes.Gasoline, horsePower: 70));
            garage.AddVehicle(new Helicopter(name: "Ми-24", weight: 5000, maxSpeed: 400, acceleration: 40, maxAltitude: 4000,
                verticalAcceleration: 60, loadCapacity: 10000, Vehicle.AirVehicleEngineTypes.Turboshaft));
            garage.AddVehicle(new Plane(name: "Sea Wixen", weight: 3000, maxSpeed: 1151, acceleration: 100, maxAltitude: 9000,
                verticalAcceleration: 180, loadCapacity: 3000, Vehicle.AirVehicleEngineTypes.Reactive, runwayLength: 300));
            garage.AddVehicle(new Plane(name: "F4U Corsair", weight: 2000, maxSpeed: 485, acceleration: 40, maxAltitude: 3500,
                verticalAcceleration: 20, loadCapacity: 1500, Vehicle.AirVehicleEngineTypes.Radial, runwayLength: 350));
        }
    }
}
