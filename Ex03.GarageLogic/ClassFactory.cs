using System.Dynamic;

namespace Ex03.GarageLogic
{
    public class ClassFactory
    {

        public Garage CreateGarage()
        {
            return new Garage();
        }
        public Car GetNewCar(eColor i_Color, int i_NumOfDoors)
        {
            return new Car(getNewFuelTank(Conf.CarFuelTankSize, Conf.CarBaseFuelType), i_Color, i_NumOfDoors);
        }

        public Car GetNewElectricCar(eColor i_Color, int i_NumOfDoors)
        {
            return new Car(getNewBattery(Conf.CarMaxChargeTime), i_Color, i_NumOfDoors);
        }

        private FuelTank getNewFuelTank(float i_FuelCapacity, eFuelType i_EnergyType)
        {
            return new FuelTank(i_FuelCapacity, i_EnergyType);
        }

        private ElectricBattery getNewBattery(float i_ChargeTimeCapacity)
        {
            return new ElectricBattery(i_ChargeTimeCapacity);
        }
    }
}
