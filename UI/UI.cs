using Ex03.GarageLogic;
using System.Collections.Generic;
using System;

namespace UI
{
    public class UI
    {
        private ClassFactory m_ClassFactory = new ClassFactory();
        private Garage m_Garage = new Garage();

        public UI()
        {
        }

        public void StartGragageUI()
        {
            this.printVehicleInfo("11111");
        }

        private void printVehicleInfo(string i_LicenseNumber)
        {
            ///prints all of the data of a specific vehicle by its license number

            Dictionary<string, string> vehicleInfo = m_Garage.GetVehicleData(i_LicenseNumber);
            
            printDictionary(vehicleInfo);

        }

        private void printDictionary(Dictionary<string, string> i_VehicleInfo)
        {
            foreach (KeyValuePair<string, string> item in i_VehicleInfo)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
