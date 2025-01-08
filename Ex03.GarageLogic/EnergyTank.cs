using System;
using static Ex03.GarageLogic.Utils;

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

        


        public virtual void Fill(float i_Amounttofill)
        {
            //this funciton adds combustion material to the tank untill it is full
            if (m_CurrAmount + i_Amounttofill > m_MaxCapacity)
            {
                throw new ValueOutOfRangeException(m_MaxCapacity, 0);
            }
            else
            {
            m_CurrAmount += i_Amounttofill;
            }
        }
    }
}
