using System.Collections.Generic;
using Utils;

namespace Ex03.GarageLogic
{
    public enum eEnergyTankType
    {
        FuelTank,
        ElectricBattery
    }

    public abstract class EnergyTank
    {
        internal float m_CurrAmount;
        internal float m_MaxCapacity;
        

        /*public EnergyTank(float i_MaxCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrAmount = 0;
            
        }*/

        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            m_CurrAmount = (float)i_Schema["Current Energy Amount"].Value;
            m_MaxCapacity = (float)i_Schema["Max Amount"].Value;
        }

        public abstract Dictionary<string, string> GetInfo();
        
        public virtual void Fill(float i_Amounttofill)
        {
            //this funciton adds combustion material to the tank untill it is full
            if (m_CurrAmount + i_Amounttofill > m_MaxCapacity)
            {
                throw new Utils.Exceptions.ValueOutOfRangeException(m_MaxCapacity, 0);
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

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> energyTankSchema = new Dictionary<string, FieldDescriptor>();

            energyTankSchema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current Energy Amount", Type = typeof(float), IsRequired = true };
            energyTankSchema["Max Amount"] = new FieldDescriptor { StringDescription = "Max Amount", Type = typeof(float), IsRequired = true };

            return energyTankSchema;
        }

        public abstract eEnergyTankType GetType();
    }
}
