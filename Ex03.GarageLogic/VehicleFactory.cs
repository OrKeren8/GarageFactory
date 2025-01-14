using static Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic
{
    public enum eVehiclesTypes
    {
        Motorcycle,
        Track,
        Car
    }

    public class VehicleFactory
    {
        public Garage CreateGarage()
        {
            return new Garage();
        }

        public Vehicle CreateVehicle(eVehiclesTypes i_VehicleType)
        {
            ///creates a vehicle by all of the vehicles types in the application
            ///
            Vehicle vehicle;

            switch (i_VehicleType)
            {
                case eVehiclesTypes.Motorcycle:
                    vehicle = createMotorcycle();
                    break;
                case eVehiclesTypes.Track:
                    vehicle = createTrack();
                    break;
                case eVehiclesTypes.Car:
                    vehicle = createCar();
                    break;
                default:
                    throw new AppException($"Vehicle type [{i_VehicleType.ToString()}] does not exist", ErrorCode.VehicleTypeNotExist);
            }

            return vehicle;
        }

        public Car createCar(eColor i_Color, int i_NumOfDoors)
        {
            return new Car(getNewFuelTank(Conf.CarFuelTankSize, Conf.CarBaseFuelType), i_Color, i_NumOfDoors);
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
