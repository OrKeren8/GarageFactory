namespace Ex03.GarageLogic
{
    
    internal class EnergyTank
    {
        private float m_CurrAmount;
        private float m_MaxCapacity;
        

        public EnergyTank(float i_MaxCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrAmount = 0;
            
        }

       

        public virtual void Fill()
        {
            //this funciton adds combustion material to the tank untill it is full

        }
    }
}
