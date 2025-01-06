namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Solar,
        Octan95,
        Octan96,
        Octan98
    }

    internal class FuelTank : EnergyTank
    {
        private eFuelType m_FuelType;
        
        public FuelTank(eFuelType i_FuelType, float i_FuelCapacity) : base(i_FuelCapacity)
        {
            m_FuelType = i_FuelType;
        }
    }
}
