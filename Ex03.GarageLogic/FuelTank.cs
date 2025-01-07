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
        private eFuelType m_EnergyType;
        public FuelTank(float i_FuelCapacity, eFuelType i_EnergyType) : base(i_FuelCapacity)
        {
            m_EnergyType = i_EnergyType;
        }

        public eFuelType EnergyType
        {
            get { return m_EnergyType; }
        }

        public override void Fill(float i_FuelAmount, eFuelType i_FuelType)
        {
            ///this funciton adds fuel to the tank as requested
            ///as long as the tank is not over flows
            m_EnergyType = i_FuelType;
            base.Fill(i_FuelAmount);
        }
    }
}
