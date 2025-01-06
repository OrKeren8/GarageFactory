using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public void AddNewVehicle(Vehicle i_Vehicle) 
        {
            ///this funciton add new veicle to the garage,
            ///if the vehicle is already exist, its status will be changed to in progress
        }

        public List<string> GetAllLicenseNumbersFiltered(eMaintenanceStatus i_Filter)
        {
            ///this funcition returns all of the license numbers of all of the cars in the garage
        }

        public void ChangeStatus(string i_LicenseNumber, eMaintenanceStatus i_NewState)
        {
            ///change the statis of a car in the garage to new state
            ///the car is chosen by input license number
        }

        public void FillWheelsToTheMax(string i_LicenseNumber)
        {
            ///fill air in a specific car to the max
        }

        public void FuelVehicle(string i_LicenseNumber, eEnergyType i_EnergyTpe, float i_Amount)
        {
            ///Add energy to the energy tank of a vehicle
        }

        public VehicleData GetVehicleData(string i_LicenseNumber)
        {
            ///returns all of the data on a specific vehicle in the garage
        }
    }
}
