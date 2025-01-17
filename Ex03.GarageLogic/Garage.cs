using System.Collections.Generic;
using Utils;
using System;
using System.Runtime.CompilerServices;

namespace Ex03.GarageLogic
{


    public class Garage
    {
        private Dictionary<string, MaintainedVehicle> Vehicles { get; set; } = new Dictionary<string, MaintainedVehicle>();

        public bool IsVehicleExist(string i_LicenseNumber, bool i_ThrowException = false)
        {
            bool isExist = false;

            isExist = Vehicles.ContainsKey(i_LicenseNumber);
            if (i_ThrowException && !isExist)
            {
                throw new Utils.Exceptions.AppException($"Vehicle with license Number: [{i_LicenseNumber}] does not exist in the garage", Utils.Exceptions.eErrorCode.VehiceNotExist);
            }

            return isExist;
        }

        public void AddVehicle(Vehicle i_Vehicle)
        {
            ///add new veicle to the garage, if the vehicle is already exist throw an exception
            if (IsVehicleExist(i_Vehicle.LicenseNumber))
            {
                throw new Utils.Exceptions.AppException($"Vehicle with license Number: [{i_Vehicle.LicenseNumber}] already exist", Utils.Exceptions.eErrorCode.VehicleAlreadyExist);
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
        public List<string> GetAllLicenseNumbers(eMaintenanceStatusWithDefault? i_Filter)
        {
            List<string> licenseNumbersFiltered = new List<string>();
            bool withFilter;
            eMaintenanceStatus filter = default;
            
            if(i_Filter == eMaintenanceStatusWithDefault.All)
            {
                withFilter = false;
            }
            else
            {
                filter = (eMaintenanceStatus)i_Filter;
                withFilter = true;
            }

            foreach (MaintainedVehicle currentVehicle in this.Vehicles.Values)
            {
                
                if ((withFilter && (currentVehicle.Status == filter)) || !withFilter)
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
            foreach (Wheel wheel in currVehicle.Vehicle.Wheels)
            {
                wheel.FillAir(wheel.MaxAirPressure - wheel.CurrAirPressure);
            }
        }

        public bool IsFueledVehicle(string i_LicenseNumber)
        {
            bool isFueledVehicle = false;

            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            if (this.Vehicles[i_LicenseNumber].Vehicle.EnergyTank.GetType() == eEnergyTankType.FuelTank)
            {
                isFueledVehicle = true;
            }

            return isFueledVehicle;
        }

        public void FuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_Amount)
        {
            if(!this.IsFueledVehicle(i_LicenseNumber))
            {
                throw new Utils.Exceptions.AppException("cannot fuel an unfueled vehicle", Utils.Exceptions.eErrorCode.VehicleFuelError);
            }

            MaintainedVehicle currVehicle = Vehicles[i_LicenseNumber];
            currVehicle.Vehicle.EnergyTank.Fill(i_Amount, i_FuelType);
        }

        public bool IsElectricVehicle(string i_LicenseNumber)
        {
            bool isElectricVehicle = false;

            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            if (this.Vehicles[i_LicenseNumber].Vehicle.EnergyTank.GetType() == eEnergyTankType.ElectricBattery)
            {
                isElectricVehicle = true;
            }

            return isElectricVehicle;
        }

        public void ChargeElectricBattery(string i_LicenseNumber, float i_AmountOfMinutes)
        {
            if (!this.IsElectricVehicle(i_LicenseNumber))
            {
                throw new Utils.Exceptions.AppException("cannot charge an unelectric vehicle", Utils.Exceptions.eErrorCode.VehicleChargeError);
            }

            MaintainedVehicle currVehicle = Vehicles[i_LicenseNumber];
            currVehicle.Vehicle.EnergyTank.Fill(i_AmountOfMinutes);
        }

        public Dictionary<string, FieldDescriptor> GetVehicleData(string i_LicenseNumber)
        {
            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            return Vehicles[i_LicenseNumber].Vehicle.GetSchema();
        }

        public virtual Dictionary<string, FieldDescriptor> GetVehicleSchema(string i_LicenseNumber)
        {
            IsVehicleExist(i_LicenseNumber, i_ThrowException: true);
            return Vehicles[i_LicenseNumber].Vehicle.GetSchema();
        }

        public void InitVehicle(string i_LicenseNumber, Dictionary<string, FieldDescriptor> i_VehicleDataSchema)
        {
            try
            {
                this.Vehicles[i_LicenseNumber].Vehicle.Init(i_VehicleDataSchema);
            }
            catch (Exception e)
            {
                this.removeVehicle(i_LicenseNumber);
                throw e;
            }
        }

        private void removeVehicle(string i_LicenseNumber)
        {
            if (this.IsVehicleExist(i_LicenseNumber))
            {
                this.Vehicles.Remove(i_LicenseNumber);
            }
            
        }

        
    }
}
