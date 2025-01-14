using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic
{
    public enum eVehiclesTypes
    {
        Motorcycle,
        ElectricMotorcycle,
        Car,
        ElectricCar,
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

        /// <summary>
        /// creates a vehicle a new vehicle from specific type with already created object schema
        /// for all the data required in order to call the object constractor
        /// </summary>
        /// <param name="i_VehicleType">The type of a vehicle</param>
        /// <param name="i_ObjectSchema">A schema representing the required object</param>
        /// <returns>The new desired vehicle</returns>
        /// <exception cref="AppException">If the vehicle type does not exist</exception>
        public Vehicle CreateVehicle(eVehiclesTypes i_VehicleType)
        {
            Vehicle vehicle;

            switch (i_VehicleType)
            {
                case eVehiclesTypes.Car:
                    vehicle = new Car();
                    break;
                case eVehiclesTypes.Motorcycle:
                    vehicle = new Motorcycle();
                    break;
                case eVehiclesTypes.Track:
                    vehicle = new Track();
                    break;
                default:
                    throw new AppException($"Vehicle type [{i_VehicleType.ToString()}] does not exist", ErrorCode.VehicleTypeNotExist);
            }

            return vehicle;
        }
