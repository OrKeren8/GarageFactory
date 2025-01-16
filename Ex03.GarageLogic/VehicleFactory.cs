using System;
using System.Collections.Generic;

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
        public object Value { get; set; }
        public bool IsRequired { get; set; }
    }

    public class VehicleFactory
    {
        public Garage Garage { get; } = new Garage();

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
        public Dictionary<string, FieldDescriptor> CreateVehicle(eVehiclesTypes i_VehicleType, string I_LicenseNumber)
        {
            Vehicle vehicle;
            Dictionary<string, FieldDescriptor> schema;

            switch (i_VehicleType)
            {
                case eVehiclesTypes.Car:
                    vehicle = new Car(I_LicenseNumber, createWheelsList(Conf.CarAmountOfWheels), createEnergyTank(eEnergyTankType.FuelTank));
                    schema = fillDefaultCarData(vehicle.GetSchema());
                    break;
                case eVehiclesTypes.ElectricCar:
                    vehicle = new Car(I_LicenseNumber, createWheelsList(Conf.CarAmountOfWheels), createEnergyTank(eEnergyTankType.ElectricBattery));
                    schema = fillDefaultElectricCarData(vehicle.GetSchema());
                    break;
                case eVehiclesTypes.Motorcycle:
                    vehicle = new Motorcycle(I_LicenseNumber, createWheelsList(Conf.MotorcycleAmountOfWheels), createEnergyTank(eEnergyTankType.FuelTank));
                    schema = fillDefaultMotorcycleData(vehicle.GetSchema());
                    break;
                case eVehiclesTypes.ElectricMotorcycle:
                    vehicle = new Motorcycle(I_LicenseNumber, createWheelsList(Conf.MotorcycleAmountOfWheels), createEnergyTank(eEnergyTankType.ElectricBattery));
                    schema = fillDefaultElectricMotorcycleData(vehicle.GetSchema());
                    break;
                case eVehiclesTypes.Track:
                    vehicle = new Track(I_LicenseNumber, createWheelsList(Conf.TrackAmountOfWheels), createEnergyTank(eEnergyTankType.FuelTank));
                    schema = fillDefaultTrackData(vehicle.GetSchema());
                    break;
                default:
                    throw new Utils.Exceptions.AppException($"Vehicle type [{i_VehicleType.ToString()}] does not exist", Utils.Exceptions.ErrorCode.VehicleTypeNotExist);
            }


            Garage.AddVehicle(vehicle);

            return schema;
        }

        public void InitVehicle(string i_LicenseNumber, Dictionary<string, FieldDescriptor> i_VehicleDataSchema)
        {
            this.Garage.InitVehicle(i_LicenseNumber, i_VehicleDataSchema);
        }

        private List<Wheel> createWheelsList(int i_NumOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheels.Add(new Wheel());
            }

            return wheels;
        }

        private EnergyTank createEnergyTank(eEnergyTankType i_Type)
        {

            if (i_Type == eEnergyTankType.FuelTank)
            {
                return new FuelTank();
            }

            return new ElectricBattery();
        }

        private Dictionary<string, FieldDescriptor> fillDefaultCarData(Dictionary<string, FieldDescriptor> i_Schema)
        {
            i_Schema["Energy Tank Max Amount"].Value = Conf.CarFuelTankSize;
            i_Schema["Fuel Type"].Value = Conf.CarDefaultFuelType;
            i_Schema["Max Air Pressure"].Value = Conf.CarMaxAirPressure;

            return i_Schema;
        }

        private Dictionary<string, FieldDescriptor> fillDefaultElectricCarData(Dictionary<string, FieldDescriptor> i_Schema)
        {
            i_Schema["Energy Tank Max Amount"].Value = Conf.ElectricCarMaxChargeTime;
            i_Schema["Max Air Pressure"].Value = Conf.CarMaxAirPressure;

            return i_Schema;
        }

        private Dictionary<string, FieldDescriptor> fillDefaultMotorcycleData(Dictionary<string, FieldDescriptor> i_Schema)
        {
            i_Schema["Energy Tank Max Amount"].Value = Conf.MotorcycleMaxFuelAmount;
            i_Schema["Fuel Type"].Value = Conf.MotorcycleDefaultFuelType;
            i_Schema["Max Air Pressure"].Value = Conf.MotorcycleMaxtAirPressure;
            
            return i_Schema;
        }

        private Dictionary<string, FieldDescriptor> fillDefaultElectricMotorcycleData(Dictionary<string, FieldDescriptor> i_Schema)
        {
            i_Schema["Energy Tank Max Amount"].Value = Conf.ElectricMotorcycleMaxBatteryTime;
            i_Schema["Max Air Pressure"].Value = Conf.MotorcycleMaxtAirPressure;

            return i_Schema;
        }

        private Dictionary<string, FieldDescriptor> fillDefaultTrackData(Dictionary<string, FieldDescriptor> i_Schema)
        {
            i_Schema["Energy Tank Max Amount"].Value = Conf.TrackFuelTankSize;
            i_Schema["Fuel Type"].Value = Conf.TrackDefaultFuelType;
            i_Schema["Max Air Pressure"].Value = Conf.trackMaxtAirPressure;

            return i_Schema;
        }
    }
}

