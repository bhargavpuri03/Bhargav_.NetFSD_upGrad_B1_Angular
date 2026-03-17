using System;
using System.Collections.Generic;
using System.Text;

namespace C_.Net_Assignment_3
{
    using System;

    class Vehicle
    {
        public string VehicleNumber;
        public string Brand;

        public void StartVehicle()
        {
            Console.WriteLine("Vehicle Started");
        }
    }

    class Car : Vehicle
    {
        public string FuelType;
    }
}

//    public sealed class ElectricCar : Car
//    {
//    }

//    // class Tesla : ElectricCar { }

//    class vehicle1
//    {
//        static void Main()
//        {
//            ElectricCar e = new ElectricCar();
//            e.StartVehicle();
//        }
//    }
//}