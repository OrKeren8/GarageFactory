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
        internal float CurrAmount {  get; set; }
        internal float MaxCapacity { get; private set; }

        public EnergyTank()
        {
            CurrAmount = 0;
        }

        public virtual void Init(Dictionary<string, FieldDescriptor> i_Schema)
        {
            MaxCapacity = (float)i_Schema["Energy Tank Max Amount"].Value;
            Fill((float)i_Schema["Current Energy Amount"].Value);
        }

        public virtual void Fill(float i_Amounttofill)
        {
            //this funciton adds combustion material to the tank untill it is full
            if (CurrAmount + i_Amounttofill > MaxCapacity)
            {
                throw new Utils.Exceptions.ValueOutOfRangeException(MaxCapacity, 0, "max capacity exceed");
            }
            else
            {
            CurrAmount += i_Amounttofill;
            }
        }

        public virtual void Fill(float i_FuelAmount, eFuelType i_FuelType)
        {
            Fill(i_FuelAmount);
        }

        public virtual Dictionary<string, FieldDescriptor> GetSchema()
        {
            Dictionary<string, FieldDescriptor> Schema = new Dictionary<string, FieldDescriptor>();

            Schema["Current Energy Amount"] = new FieldDescriptor { StringDescription = "Current Energy Amount", Type = typeof(float), IsRequired = true, Value = this.CurrAmount};
            Schema["Energy Tank Max Amount"] = new FieldDescriptor { StringDescription = "Energy Tank Max Amount", Type = typeof(float), IsRequired = false, Value =this.MaxCapacity};

            return Schema;
        }

        public abstract eEnergyTankType GetType();
    }
}
