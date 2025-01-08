namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {

        public Car GetNewCar(eColor i_Color, int i_NumOfDoors)
        {
            return new Car(getNewFuelTank(Conf.CarFuelTankSize, Conf.CarBaseFuelType), i_Color, i_NumOfDoors);
        }

        private FuelTank getNewFuelTank(float i_FuelCapacity, eFuelType i_EnergyType)
        {
            return new FuelTank(i_FuelCapacity, i_EnergyType);
        }
    }
}
