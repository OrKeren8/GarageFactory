using System.Collections.Generic;
using Utils;

namespace Ex03.GarageLogic
{


    public class Garage
    {
        private Dictionary<string, MaintainedVehicle> Vehicles {  get; set; } = new Dictionary<string, MaintainedVehicle>();

        public bool IsVehicleExist(string i_LicenseNumber, bool i_ThrowException=false)
        {
            bool isExist = false;

            isExist = Vehicles.ContainsKey(i_LicenseNumber);
            if (i_ThrowException)
            {
                throw new Utils.Exceptions.AppException($"Vehicle with license Number: [{i_LicenseNumber}] does not exist in the garage", Utils.Exceptions.ErrorCode.VehiceNotExist);
            }

            return isExist;
        }

        public void AddVehicle(Vehicle i_Vehicle) 
        {
            ///add new veicle to the garage, if the vehicle is already exist throw an exception
            if (IsVehicleExist(i_Vehicle.LicenseNumber))
            {
                throw new Utils.Exceptions.AppException($"Vehicle with license Number: [{i_Vehicle.LicenseNumber}] already exist", Utils.Exceptions.ErrorCode.VehicleAlreadyExist);
            }
            else
            {
                MaintainedVehicle vehicleToAdd = new MaintainedVehicle(i_Vehicle);
                Vehicles.Add(i_Vehicle.LicenseNumber, vehicleToAdd);
            }
        }

        /// <summary>
        /// get all license numbers of the vehicles in the garage
        /// filtering is optional
        /// </summary>
        /// <param name="i_Filter">filter by maintenace status</param>
        /// <returns></returns>
        public List<string> GetAllLicenseNumbers(eMaintenanceStatus? i_Filter)
        {
            List<string> licenseNumbersFiltered = new List<string>();

            foreach (MaintainedVehicle currentVehicle in this.Vehicles.Values)
            {
                if(currentVehicle.Status == i_Filter)
                {
                    licenseNumbersFiltered.Add(currentVehicle.Vehicle.LicenseNumber);
                }
            }
            
            return licenseNumbersFiltered;
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

        public void FillWheelsToTheMax(string i_LicenseNumber)
        {
            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            
            MaintainedVehicle currVehicle = Vehicles[i_LicenseNumber];
            foreach(Wheel wheel in currVehicle.Vehicle.Wheels)
            {
                wheel.FillAir(wheel.MaxAirPressure - wheel.CurrAirPressure);
            }
        }

        public void FuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_Amount)
        {
            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);

            MaintainedVehicle currVehicle = Vehicles[i_LicenseNumber];
            currVehicle.Vehicle.EnergyTank.Fill(i_Amount, i_FuelType);
        }

        public void ChargeElectricBattery(string i_LicenseNumber, float i_AmountOfMinutes)
        {
            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);

            MaintainedVehicle currVehicle = Vehicles[i_LicenseNumber];
            currVehicle.Vehicle.EnergyTank.Fill(i_AmountOfMinutes);
        }

        public void GetVehicleData(string i_LicenseNumber)
        {
            //return Vehicles[i_LicenseNumber].GetInfo();
        }

        public virtual Dictionary<string, FieldDescriptor> GetVehicleSchema(string i_LicenseNumber)
        {
            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            return Vehicles[i_LicenseNumber].Vehicle.GetSchema();
        }
    }
}
