namespace Ex03.GarageLogic
{
    internal class ElectricBattery : EnergyTank
    {
        public ElectricBattery(float i_BaterryCapacity) : base(i_BaterryCapacity, eEnergyType.Electricity)
        {
        }
    }
}
