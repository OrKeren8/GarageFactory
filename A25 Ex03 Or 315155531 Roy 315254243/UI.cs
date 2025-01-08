using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace A25_Ex02_Or_315155531_Roy_315254243
{
    public class UI
    {
        private Vehicle m_Vehicle;


        private void printVehicleInfo(Vehicle i_VehicleToShow)
        {
            Console.WriteLine("The Complete details are:");
            Console.WriteLine($"License Number: {i_VehicleToShow.Name}");
            Console.WriteLine($"Model Name: {i_VehicleToShow.ModelName}");
            Console.WriteLine($"Owner Name: {i_VehicleToShow.OwnerName}");
            Console.WriteLine($"Status in the garage: {i_VehicleToShow.GarageStatus}");//need to add
            PrintWheels(i_VehicleToShow.Wheels);
            // need to add specific details to the specific vehicle type

        }
        private void PrintWheels(List<Wheel> i_WheelsToPrint)
        {
            Console.WriteLine("The wheels details are:");
            foreach (Wheel currWheel in i_WheelsToPrint)
            {
                Console.WriteLine($"Manufacturer: {currWheel.Manufacturer}");
                Console.WriteLine($"Current Air Pressure Status: {currWheel.CurrAirPressure}");
            }
        }

    }

    }