using System;

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

        public class ValueOutOfRangeException : Exception
        {
            public float MaxValue { get; }
            public float MinValue { get; }

            public ValueOutOfRangeException(float maxValue, float minValue)
            {
                MaxValue = maxValue;
                MinValue = minValue;
            }
        }


        public virtual void Fill(float amounttofill)
        {
            //this funciton adds combustion material to the tank untill it is full
            if (amounttofill + m_CurrAmount <= m_MaxCapacity)
            {
                m_CurrAmount += amounttofill;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxCapacity, 0);
            }
        }
    }
}
