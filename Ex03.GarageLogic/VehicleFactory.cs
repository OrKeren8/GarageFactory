using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eVehiclesTypes
    {
        Motorcycle,
        Car,
        Track
    }

    public class FieldDescriptor
    {
        public string StringDescription { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; } = null;
        public bool IsRequired { get; set; }
    }

    public class VehicleFactory
    {
        public Garage CreateGarage()
        {
            return new Garage();
        }

        public List<string> GetAllFueledType()
        {
            List<string> vehiclesFeulOptions = new List<string>();
            foreach (eFuelType fuelType in Enum.GetValues(typeof(eFuelType)))
            {
                vehiclesFeulOptions.Add($"{fuelType.GetHashCode()}. {fuelType}");
            }

            return vehiclesFeulOptions;
        }
        

        /// <summary>
        /// creates new vehivle from specific type
        /// </summary>
        /// <param name="i_VehicleType">The type of a vehicle</param>
        /// <returns>The new desired vehicle</returns>
        /// <exception cref="AppException">If the vehicle type does not exist</exception>
        public Vehicle CreateVehicle(eVehiclesTypes i_VehicleType, string I_LicenseNumber)
        {
            Vehicle vehicle;

            switch (i_VehicleType)
            {
                case eVehiclesTypes.Car:
                    vehicle = new Car(I_LicenseNumber);
                    break;
                case eVehiclesTypes.Motorcycle:
                    vehicle = new Motorcycle(I_LicenseNumber);
                    break;
                case eVehiclesTypes.Track:
                    vehicle = new Track(I_LicenseNumber);
                    break;
                default:
                    throw new Utils.Exceptions.AppException($"Vehicle type [{i_VehicleType.ToString()}] does not exist", Utils.Exceptions.ErrorCode.VehicleTypeNotExist);
            }

            return vehicle;
        }
    }
}

            