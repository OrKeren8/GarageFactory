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

        public override void Fill()
        {
            //this funciton adds combustion material to the tank untill it is full

        }
    }
}
