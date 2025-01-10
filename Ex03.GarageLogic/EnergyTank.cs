using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic
{
    
    public abstract class EnergyTank
    {
        internal float m_CurrAmount;
        internal float m_MaxCapacity;
        

        public EnergyTank(float i_MaxCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrAmount = 0;
            
        }

        public abstract Dictionary<string, string> GetInfo();
        
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

        public virtual void Fill(float i_FuelAmount, eFuelType i_FuelType)
        {
            Fill(i_FuelAmount);
        }
    }
}
