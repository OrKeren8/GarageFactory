using System.Collections.Generic;
using Utils;

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
                throw new AppException($"Vehicle with license Number: [{i_LicenseNumber}] does not exist in the garage", ErrorCode.VehiceNotExist);
            }

            return isExist;
        }

        public void AddNewVehicle(Vehicle i_Vehicle) 
        {
            ///add new veicle to the garage, if the vehicle is already exist throw an exception

        }

        /// <summary>
        /// get all license numbers of the vehicles in the garage
        /// filtering is optional
        /// </summary>
        /// <param name="i_Filter">filter by maintenace status</param>
        /// <returns></returns>
        public List<string> GetAllLicenseNumbers(eMaintenanceStatus? i_Filter)
        {
            return new List<string>();
        }

        /// <summary>
        ///change status of a car in the garage to a new state
        ///the car is chosen by input license number
        /// </summary>
        /// <param name="i_LicenseNumber">the license number of the vehicle to change the status to</param>
        /// <param name="i_Status">the desired status</param>
        public void ChangeStatus(string i_LicenseNumber, eMaintenanceStatus i_Status)
        {
            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            Vehicles[i_LicenseNumber].ChangeStatus(i_Status);
        }

        /// <summary>
        /// check if the license number is exist and if it is it fill it to maximum
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <exception cref="AppException"></exception>
        public void FillWheelsToTheMax(string i_LicenseNumber)
        {
            ///fill air in a specific car to the max
            if (!IsVehicleExist(i_LicenseNumber))
            {
                throw new Utils.AppException($"Vehicle with license Number: [{i_LicenseNumber}] does not exist in the garage", ErrorCode.VehiceNotExist);
            }
            else
            {
                MaintainedVehicle currVehicle = Vehicles[i_LicenseNumber];
                foreach(Wheel wheel in currVehicle.Vehicle.Wheels)
                {
                    wheel.FillAir(wheel.MaxAirPressure - wheel.CurrAirPressure);
                }

            }
            
        }

        public void FuelVehicle(string i_LicenseNumber, eFuelType i_FuelTpe, float i_Amount)
        {
            ///Add energy to the energy tank of a vehicle
        }

        public Dictionary<string, string> GetVehicleData(string i_LicenseNumber)
        {
            return Vehicles[i_LicenseNumber].GetInfo();
        }

    }
}
