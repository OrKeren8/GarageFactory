using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, MaintainedVehicle> Vehicles {  get; set; }

        public bool IsVehicleExist(string i_LicenseNumber, bool i_ThrowException=false)
        {
            bool isExist = false;

            isExist = Vehicles.ContainsKey(i_LicenseNumber);
            if (i_ThrowException)
            {
                throw new System.ArgumentException("Vehicle does not exist");
            }
            
            return isExist;
        }

        public void AddNewVehicle(Vehicle i_Vehicle) 
        {
            ///add new veicle to the garage, if the vehicle is already exist throw an exception

        }

        public List<string> GetAllLicenseNumbersFiltered(eMaintenanceStatus i_Filter)
        {
            ///this funcition returns all of the license numbers of all of the cars in the garage
            ///
            return new List<string>();
        }

        public void ChangeStatus(string i_LicenseNumber, eMaintenanceStatus i_Status)
        {
            ///change the statis of a car in the garage to new state
            ///the car is chosen by input license number

            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            Vehicles[i_LicenseNumber].ChangeStatus(i_Status);
        }

        public void FillWheelsToTheMax(string i_LicenseNumber)
        {
            ///fill air in a specific car to the max
        }

        public void FuelVehicle(string i_LicenseNumber, eFuelType i_FuelTpe, float i_Amount)
        {
            ///Add energy to the energy tank of a vehicle
        }

        public Dictionary<string, string> GetVehicleData(string i_LicenseNumber)
        {
            return m_Vehicles[i_LicenseNumber].GetInfo();
        }

    }
}
