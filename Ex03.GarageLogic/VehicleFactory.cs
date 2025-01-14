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

        public Dictionary<string, FieldDescriptor> GetVehicleSchema(eVehiclesTypes i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehiclesTypes.Motorcycle:
                    return Motorcycle.GetSchema();
                case eVehiclesTypes.ElectricMotorcycle:
                    return Motorcycle.GetSchema();
                case eVehiclesTypes.Track:
                    return Track.GetSchema();
                case eVehiclesTypes.Car:
                    return Car.GetSchema();
                case eVehiclesTypes.ElectricCar:
                    return Car.GetSchema();
                    break;
                default:
                    throw new AppException($"Vehicle type [{i_VehicleType.ToString()}] does not exist", ErrorCode.VehicleTypeNotExist);
            }

            return vehicle;
        }

        /// <summary>
        /// creates a vehicle a new vehicle from specific type with already created object schema
        /// for all the data required in order to call the object constractor
        /// </summary>
        /// <param name="i_VehicleType">The type of a vehicle</param>
        /// <param name="i_ObjectSchema">A schema representing the required object</param>
        /// <returns>The new desired vehicle</returns>
        /// <exception cref="AppException">If the vehicle type does not exist</exception>
        public Vehicle CreateVehicle(eVehiclesTypes i_VehicleType, List<FieldDescriptor> i_ObjectSchema)
        {
            Vehicle vehicle;

            switch (i_VehicleType)
            {
                case eVehiclesTypes.Car:
                    vehicle = createCar(i_ObjectSchema);
                    break;
                case eVehiclesTypes.Motorcycle:
                    vehicle = createMotorcycle();
                    break;
                case eVehiclesTypes.ElectricMotorcycle:
                    vehicle = createElectricMotorcycle();
                case eVehiclesTypes.Track:
                    vehicle = createTrack();
                    break;
                case eVehiclesTypes.ElectricCar:
                    vehicle = createElectricCar();
                    break;
                default:
                    throw new AppException($"Vehicle type [{i_VehicleType.ToString()}] does not exist", ErrorCode.VehicleTypeNotExist);
            }

            return vehicle;
        }

        public Car createCar(List<FieldDescriptor> i_ObjectSchema)
        {
            return new Car(createFuelTank(Conf.CarFuelTankSize, Conf.CarBaseFuelType), i_ObjectSchema["color"].Value, i_ObjectSchema[1].Value);
        }

        public Car createElectricCar(eColor i_Color, int i_NumOfDoors)
        {
            return new Car(getNewBattery(Conf.CarMaxChargeTime), i_Color, i_NumOfDoors);
        }

        private FuelTank createFuelTank(float i_FuelCapacity, eFuelType i_EnergyType)
        {
            return new FuelTank(i_FuelCapacity, i_EnergyType);
        }

        private ElectricBattery createBattery(float i_ChargeTimeCapacity)
        {
            return new ElectricBattery(i_ChargeTimeCapacity);
        }
    }
}
