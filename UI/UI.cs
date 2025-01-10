using Ex03.GarageLogic;
using System.Collections.Generic;
using System;

namespace UI
{
    public class UI
    {
        private Garage m_Garage;

        public UI(Garage i_Garage)
        {
            m_Garage = i_Garage;
        }

        private void printVehicleInfo(string i_LicenseNumber)
        {
            ///prints all of the data of a specific vehicle by its license number

            Dictionary<string, string> vehicleInfo = m_Garage.GetVehicleData();

            printDictionary(vehicleInfo);

        }

        private void printDictionary(Dictionary<string, string> i_VehicleInfo)
        {
            foreach (KeyValuePair<string, string> item in i_VehicleInfo)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
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
