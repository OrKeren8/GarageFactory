namespace Ex03.GarageLogic
{
    public enum eEnergyType
    {
        Electricity,
        Solar,
        Octan95,
        Octan96,
        Octan98
    }
    internal class EnergyTank
    {
        private float m_CurrAmount;
        private float m_MaxCapacity;
        private eEnergyType m_EnergyType;

        public EnergyTank(float i_MaxCapacity, eEnergyType i_EnergyType)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrAmount = 0;
            m_EnergyType = i_EnergyType;
        }

        public eEnergyType EnergyType
        {
            get { return m_EnergyType; }
        }

        public void AddEnergy(float i_EnergyAmountToAdd)
        {
            //this funciton adds combustion material to the tank untill it is full

        }
    }
}
